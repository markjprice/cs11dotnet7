using System.Text.Json; // JsonSerializer

using static System.Environment;
using static System.IO.Path;

Book mybook = new(title:
  "C# 11 and .NET 7 - Modern Cross-Platform Development Fundamentals")
{
  Author = "Mark J Price",
  PublishDate = new(year: 2022, month: 11, day: 8),
  Pages = 823,
  Created = DateTimeOffset.UtcNow,
};

JsonSerializerOptions options = new()
{
  /*
  IncludeFields = true, // includes all fields
  PropertyNameCaseInsensitive = true,
  WriteIndented = true,
  PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
  */
};

string filePath = Combine(CurrentDirectory, "mybook.json");

using (Stream fileStream = File.Create(filePath))
{
  JsonSerializer.Serialize<Book>(
    utf8Json: fileStream, value: mybook, options);
}

WriteLine("Written {0:N0} bytes of JSON to {1}",
  arg0: new FileInfo(filePath).Length,
  arg1: filePath);
WriteLine();

// display the serialized object graph 
WriteLine(File.ReadAllText(filePath));
