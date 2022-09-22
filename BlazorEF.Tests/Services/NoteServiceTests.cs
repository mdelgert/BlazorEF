using BlazorEF.Shared.Models;
using BlazorEF.Shared.Services;
using Bogus;
using Bogus.DataSets;

namespace BlazorEF.Tests.Services;

public class NoteServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly INoteService _noteService;
    private const int BatchSize = 100;

    public NoteServiceTests(ITestOutputHelper testOutputHelper, INoteService noteService)
    {
        _testOutputHelper = testOutputHelper;
        _noteService = noteService;
    }

    private async Task CreateNotes()
    {
        for (var i = 1; i <= BatchSize; i++)
        {
            var faker = new Faker();
            var note = new NoteModel
            {
                Title = faker.Lorem.Word(),
                Message = faker.Lorem.Paragraph()
            };
            await _noteService.Create(note);
        }
    }
    
    [Fact]
    public async Task CreateTest()
    {
        await CreateNotes();
    }

    [Fact]
    public async Task FindById()
    {
        var faker = new Faker();
    
        var newNote = new NoteModel
        {
            Title = faker.Lorem.Word(),
            Message = faker.Lorem.Paragraph()
        };
    
        var savedNote = await _noteService.Create(newNote);
    
        var note = await _noteService.FindById(savedNote.NoteId);
    
        Assert.NotNull(note);
    
        _testOutputHelper.WriteLine($"NoteId={savedNote.NoteId} title={note?.Title}");
    
    }
    
    [Fact]
    public async Task ReadAllTest()
    {
        await CreateNotes();
    
        var notes = await _noteService.ReadAll();
    
        foreach (var note in notes.Where(note => note != null))
        {
            if (note != null) _testOutputHelper.WriteLine($"NoteId={note.NoteId} Title={note.Title}");
        }
    }
    
    [Fact]
    public async Task UpdateTest()
    {
        await CreateNotes();
    
        var notes = await _noteService.ReadAll();
    
        foreach (var note in notes.Where(note => note != null))
        {
            if (note == null) continue;
            note.Title += "-Updated";
            await _noteService.Update(note);
        }
    }
    
    [Fact]
    public async Task DeleteAllTest()
    {
        await CreateNotes();
    
        var notes = await _noteService.ReadAll();
    
        foreach (var note in notes.Where(note => note != null))
        {
            if (note == null) continue;
            await _noteService.Delete(note.NoteId);
            _testOutputHelper.WriteLine($"Deleting NoteId={note.NoteId}");
        }
    }
    
}
