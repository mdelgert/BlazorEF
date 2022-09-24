using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BlazorEF.ConsoleApp;

public class EntryPoint
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EntryPoint> _logger;

    public EntryPoint(IConfiguration configuration, ILogger<EntryPoint> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public void Run(String[] args)
    {
        // See https://aka.ms/new-console-template for more information
        
        //Console.WriteLine("Hello World!");
        
        _logger.LogInformation("Hello logger!");
        
        foreach (var arg in args)
        {
            _logger.LogInformation($"arg={arg}");
        }
        
    }
}
