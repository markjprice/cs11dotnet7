using System.Diagnostics.CodeAnalysis; // [StringSyntax]

partial class Program
{
  [StringSyntax(StringSyntaxAttribute.DateTimeFormat)]
  const string fullDateTime = "dddd, d MMMM yyyy";

  [StringSyntax(StringSyntaxAttribute.Regex)]
  const string digitsOnlyText = @"^\d+$";

  [StringSyntax(StringSyntaxAttribute.Regex)]
  const string commaSeparatorText = 
    "(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)";
}