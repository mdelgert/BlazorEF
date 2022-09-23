using BlazorEF.Shared.Services;

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
    
    [Fact]
    public async Task CreateTest()
    {
        await _noteService.CreateFakes(BatchSize);
    }

    [Fact]
    public async Task FindById()
    {
        var fakeNote = await _noteService.CreateFake();
        var note = await _noteService.FindById(fakeNote.NoteId);
        Assert.NotNull(note);
        _testOutputHelper.WriteLine($"NoteId={fakeNote.NoteId} title={fakeNote.Title}");
    }
    
    [Fact]
    public async Task ReadAllTest()
    {
        await _noteService.CreateFakes(BatchSize);
        var notes = await _noteService.ReadAll();
    
        foreach (var note in notes.Where(note => note != null))
        {
            if (note != null) _testOutputHelper.WriteLine($"NoteId={note.NoteId} Title={note.Title}");
        }
    }
    
    [Fact]
    public async Task UpdateTest()
    {
        await _noteService.CreateFakes(BatchSize);
    
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
        await _noteService.CreateFakes(BatchSize);
    
        var notes = await _noteService.ReadAll();
    
        foreach (var note in notes.Where(note => note != null))
        {
            if (note == null) continue;
            await _noteService.Delete(note.NoteId);
            _testOutputHelper.WriteLine($"Deleting NoteId={note.NoteId}");
        }
    }
}
