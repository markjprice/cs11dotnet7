using System.Diagnostics;
using Microsoft.Extensions.Configuration;

string logPath = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.DesktopDirectory), "log.txt");

Console.WriteLine($"Writing to: {logPath}");

TextWriterTraceListener logFile = new(File.CreateText(logPath));

Trace.Listeners.Add(logFile);

// Text writer is buffered, so this option calls
// Flush() on all listeners after writing.
Trace.AutoFlush = true;

Debug.WriteLine("Debug says, I am watching!");
Trace.WriteLine("Trace says, I am watching!");

Console.WriteLine("Reading from appsettings.json in {0}",
  arg0: Directory.GetCurrentDirectory());

Console.WriteLine();
Console.WriteLine("--appsettings.json contents--");
Console.WriteLine(File.ReadAllText(Path.Combine(
  Directory.GetCurrentDirectory(), "appsettings.json")));

ConfigurationBuilder builder = new();

builder.SetBasePath(Directory.GetCurrentDirectory());

// Add the appsettings.json file to the processed configuration.
// Make reading this file mandatory so an exception will be thrown
// if the file is not found.
builder.AddJsonFile("appsettings.json",
  optional: false, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();

TraceSwitch ts = new(
  displayName: "PacktSwitch",
  description: "This switch is set via a JSON config.");

configuration.GetSection("PacktSwitch").Bind(ts);

// Output the trace switch level from appsettings.json.
Console.WriteLine($"Trace switch level: {ts.Level}");
Console.WriteLine($"Trace switch value: {ts.Value}");

Trace.WriteLineIf(ts.TraceError, "Trace error");
Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
Trace.WriteLineIf(ts.TraceInfo, "Trace information");
Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");

int unitsInStock = 12;
LogSourceDetails(unitsInStock > 10);

Console.WriteLine("Press enter to exit.");
Console.ReadLine();
