using BlazorEF.Shared.Services;

namespace BlazorEF.ConsoleApp;

public class EntryPoint
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EntryPoint> _logger;
    private readonly INoteService _noteService;

    public EntryPoint(IConfiguration configuration, ILogger<EntryPoint> logger, INoteService noteService)
    {
        _configuration = configuration;
        _logger = logger;
        _noteService = noteService;
    }

    public async void Run(string[] args)
    {
        var settings = _configuration.GetRequiredSection("Settings").Get<Settings>();

        //_logger.LogInformation("KeyOne={KeyOne} KeyTwo={KeyTwo} NestedSettings={KeyThree}", settings.KeyOne.ToString(),
        //    settings.KeyTwo.ToString(), settings.KeyThree.Message);

        // See https://aka.ms/new-console-template for more information

        //Console.WriteLine("Hello World!");

        // _logger.LogInformation("Hello logger!");
        //
        // foreach (var arg in args)
        // {
        //     _logger.LogInformation($"arg={arg}");
        // }

        _logger.LogInformation("Creating fakes begin.");
        await _noteService.CreateFakes(100);
        _logger.LogInformation("Creating fakes end.");
    }
}