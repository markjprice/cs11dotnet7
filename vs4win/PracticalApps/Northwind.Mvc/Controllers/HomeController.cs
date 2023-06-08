using Microsoft.AspNetCore.Mvc; // Controller, IActionResult
using Northwind.Mvc.Models; // ErrorViewModel
using System.Diagnostics; // Activity
using Microsoft.AspNetCore.Authorization; // [Authorize]
using Packt.Shared; // NorthwindContext
using Microsoft.EntityFrameworkCore; // Include and ToListAsync extension methods

namespace Northwind.Mvc.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindContext db;
    private readonly IHttpClientFactory clientFactory;

    public HomeController(ILogger<HomeController> logger,
      NorthwindContext injectedContext,
      IHttpClientFactory httpClientFactory)
    {
      _logger = logger;
      db = injectedContext;
      clientFactory = httpClientFactory;
    }

    [ResponseCache(Duration = 10 /* seconds */,
      Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Index()
    {
      _logger.LogError("This is a serious error (not really!)");
      _logger.LogWarning("This is your first warning!");
      _logger.LogWarning("Second warning!");
      _logger.LogInformation("I am in the Index method of the HomeController.");

      HomeIndexViewModel model = new
      (
        VisitorCount: Random.Shared.Next(1, 1001),
        Categories: await db.Categories.ToListAsync(),
        Products: await db.Products.ToListAsync()
      );

      try
      {
        HttpClient client = clientFactory.CreateClient(
          name: "Minimal.WebApi");

        HttpRequestMessage request = new(
          method: HttpMethod.Get, requestUri: "weatherforecast");

        HttpResponseMessage response = await client.SendAsync(request);

        ViewData["weather"] = await response.Content
          .ReadFromJsonAsync<WeatherForecast[]>();
      }
      catch (Exception ex)
      {
        _logger.LogWarning(
          $"The Minimal.WebApi service is not responding. Exception: {ex.Message}");

        ViewData["weather"] = Enumerable.Empty<WeatherForecast>().ToArray();
      }

      return View(model); // pass model to view
    }

    [Route("private")]
    [Authorize(Roles = "Administrators")]
    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> ProductDetail(int? id, string alertstyle = "success")
    {
      ViewData["alertstyle"] = alertstyle;

      if (!id.HasValue)
      {
        return BadRequest("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
      }

      Product? model = await db.Products.Include(p => p.Category)
        .SingleOrDefaultAsync(p => p.ProductId == id);

      if (model is null)
      {
        return NotFound($"ProductId {id} not found.");
      }

      return View(model); // pass model to view and then return result
    }

    public IActionResult ModelBinding()
    {
      return View(); // the page with a form to submit
    }

    [HttpPost] // use this action method to process POSTs
    public IActionResult ModelBinding(Thing thing)
    {
      HomeModelBindingViewModel model = new(
        Thing: thing, HasErrors: !ModelState.IsValid,
        ValidationErrors: ModelState.Values
          .SelectMany(state => state.Errors)
          .Select(error => error.ErrorMessage)
      );
      return View(model);
    }

    public IActionResult ProductsThatCostMoreThan(decimal? price)
    {
      if (!price.HasValue)
      {
        return BadRequest("You must pass a product price in the query string, for example, /Home/ProductsThatCostMoreThan?price=50");
      }

      IEnumerable<Product> model = db.Products
        .Include(p => p.Category)
        .Include(p => p.Supplier)
        .Where(p => p.UnitPrice > price);

      if (!model.Any())
      {
        return NotFound(
          $"No products cost more than {price:C}.");
      }

      ViewData["MaxPrice"] = price.Value.ToString("C");

      return View(model); // pass model to view
    }

    public async Task<IActionResult> Customers(string? country = null)
    {
      string uri;

      if (string.IsNullOrEmpty(country))
      {
        ViewData["Title"] = "All Customers Worldwide";
        uri = "api/customers";
      }
      else
      {
        ViewData["Title"] = $"Customers in {country}";
        uri = $"api/customers/?country={country}";
      }

      HttpClient client = clientFactory.CreateClient(
        name: "Northwind.WebApi");

      HttpRequestMessage request = new(
        method: HttpMethod.Get, requestUri: uri);

      HttpResponseMessage response = await client.SendAsync(request);

      IEnumerable<Customer>? model = await response.Content
        .ReadFromJsonAsync<IEnumerable<Customer>>();

      if (model is not null)
      {
        model = model.OrderBy(c => c.CustomerId);
      }

      return View(model);
    }

    // GET /Home/AddCustomer
    public IActionResult AddCustomer()
    {
      ViewData["Title"] = "Add Customer";
      return View();
    }

    // POST /Home/AddCustomer
    // A Customer object in the request body.
    [HttpPost]
    public async Task<IActionResult> AddCustomer(Customer customer)
    {
      HttpClient client = clientFactory.CreateClient(
        name: "Northwind.WebApi");

      HttpResponseMessage response = await client.PostAsJsonAsync(
        requestUri: "api/customers", value: customer);

      // Optionally, get the created customer back as JSON
      // so the user can see the assigned ID, for example.
      Customer? model = await response.Content
        .ReadFromJsonAsync<Customer>();

      if (response.IsSuccessStatusCode)
      {
        TempData["success-message"] = "Customer successfully added.";
      }
      else
      {
        TempData["error-message"] = "Customer was NOT added.";
      }

      // Show the full customers list to see if it was added.
      return RedirectToAction("Customers");
    }

    // GET /Home/DeleteCustomer
    public async Task<IActionResult> DeleteCustomer(string customerId)
    {
      HttpClient client = clientFactory.CreateClient(
        name: "Northwind.WebApi");

      Customer? customer = await client.GetFromJsonAsync<Customer>(
        requestUri: $"api/customers/{customerId}");

      ViewData["Title"] = "Delete Customer";

      return View(customer);
    }

    // POST /Home/DeleteCustomer
    // A CustomerId in the request body e.g. ALFKI.
    [HttpPost]
    [Route("home/deletecustomer")]
    // Action method name must have a different name from the GET method
    // due to C# not allowing duplicate method signatures.
    public async Task<IActionResult> DeleteCustomerPost(string customerId)
    {
      HttpClient client = clientFactory.CreateClient(
        name: "Northwind.WebApi");

      HttpResponseMessage response = await client.DeleteAsync(
        requestUri: $"api/customers/{customerId}");

      if (response.IsSuccessStatusCode)
      {
        TempData["success-message"] = "Customer successfully deleted.";
      }
      else
      {
        TempData["error-message"] = $"Customer {customerId} was NOT deleted.";
      }

      // Show the full customers list to see if it was deleted.
      return RedirectToAction("Customers");
    }

    [Route("category/{id}")]
    public async Task<IActionResult> CategoryDetail(int? id)
    {
      if (!id.HasValue)
      {
        return BadRequest("You must pass a category ID in the route, for example, /Home/CategoryDetail/6");
      }

      Category? model = await db.Categories.Include(p => p.Products)
        .SingleOrDefaultAsync(p => p.CategoryId == id);

      if (model is null)
      {
        return NotFound($"CategoryId {id} not found.");
      }

      return View(model); // pass model to view and then return result
    }
  }
}