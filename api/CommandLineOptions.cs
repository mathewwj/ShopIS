using CommandLine;

namespace api;

public class CommandLineOptions
{
    [Option('i', "init-data", Required = false, Default = false, HelpText = "Initialize data.")]
    public bool InitData { get; set; }
}