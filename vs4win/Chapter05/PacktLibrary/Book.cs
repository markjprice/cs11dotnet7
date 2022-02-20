namespace Packt.Shared;

public class Book
{
  // required is not working in .NET 7 Preview 1
  public /* required */ string? Isbn { get; set; }
  public string? Title { get; set; }
}
