using System;
using CommandLine;

public class Options
{
  [Option('s', "source", HelpText = "NuGet server source.", Default = "https://api.nuget.org/v3/")]
  public string Source { get; set; }
}