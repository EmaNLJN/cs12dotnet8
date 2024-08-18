using System.Text.RegularExpressions; // to use [GeneratedRegex].

partial class Program
{
  [GeneratedRegex(DigitsOnlyText, RegexOptions.IgnoreCase)]
  private static partial Regex DigitsOnly();

  [GeneratedRegex(CommaSeparatorText, RegexOptions.IgnoreCase)]
  private static partial Regex CommaSeparator();
}
