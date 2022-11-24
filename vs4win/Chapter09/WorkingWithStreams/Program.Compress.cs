using System.IO.Compression; // BrotliStream, GZipStream, CompressionMode
using System.Xml; // XmlWriter, XmlReader

using static System.Environment; // CurrentDirectory
using static System.IO.Path; // Combine

partial class Program
{
  static void Compress(string algorithm = "gzip")
  {
    // define a file path using algorithm as file extension
    string filePath = Combine(
      CurrentDirectory, $"streams.{algorithm}");

    FileStream file = File.Create(filePath);
    Stream compressor;
    if (algorithm == "gzip")
    {
      compressor = new GZipStream(file, CompressionMode.Compress);
    }
    else
    {
      compressor = new BrotliStream(file, CompressionMode.Compress);
    }

    using (compressor)
    {
      using (XmlWriter xml = XmlWriter.Create(compressor))
      {
        xml.WriteStartDocument();
        xml.WriteStartElement("callsigns");
        foreach (string item in Viper.Callsigns)
        {
          xml.WriteElementString("callsign", item);
        }
      }
    } // also closes the underlying stream

    // output all the contents of the compressed file
    WriteLine("{0} contains {1:N0} bytes.",
      filePath, new FileInfo(filePath).Length);
    
    WriteLine("The compressed contents:");
    WriteLine(File.ReadAllText(filePath));

    // read a compressed file
    WriteLine("Reading the compressed XML file:");
    file = File.Open(filePath, FileMode.Open);
    Stream decompressor;
    if (algorithm == "gzip")
    {
      decompressor = new GZipStream(
        file, CompressionMode.Decompress);
    }
    else
    {
      decompressor = new BrotliStream(
        file, CompressionMode.Decompress);
    }

    using (decompressor)
    {
      using (XmlReader reader = XmlReader.Create(decompressor))
      {
        while (reader.Read())
        {
          // check if we are on an element node named callsign
          if ((reader.NodeType == XmlNodeType.Element)
            && (reader.Name == "callsign"))
          {
            reader.Read(); // move to the text inside element
            WriteLine($"{reader.Value}"); // read its value
          }
        }
      }
    }
  }
}
