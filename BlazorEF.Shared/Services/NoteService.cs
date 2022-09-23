using Bogus;
using Bogus.DataSets;
using BlazorEF.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorEF.Shared.Services;

public interface INoteService
{
    Task CreateFakes(int batchSize);
    Task<NoteModel> CreateFake();
    Task<NoteModel> Create(NoteModel note);
    Task<NoteModel> FindById(string id);
    Task<List<NoteModel>> ReadAll();
    Task<NoteModel> Update(NoteModel note);
    Task Delete(string id);
}

public class NoteService : INoteService
{
    private readonly DataContext _dbContext;

    public NoteService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateFakes(int batchSize)
    {
        for (var i = 1; i <= batchSize; i++)
        {
            await CreateFake();
        }
    }

    public async Task<NoteModel> CreateFake()
    {
        var faker = new Faker();
        var noteModel = new NoteModel
        {
            Title = faker.Lorem.Word(),
            Message = faker.Lorem.Paragraph()
        };
        var note = await Create(noteModel);
        return note;
    }
    
    public async Task<NoteModel> Create(NoteModel note)
    {
        note.NoteId = Guid.NewGuid().ToString();
        var id = _dbContext.Notes.Add(note);
        await _dbContext.SaveChangesAsync();
        return note;
    }

    public async Task<NoteModel> FindById(string id)
    {
        var note = await _dbContext.Notes.FindAsync(id);
        return note;
    }

    public Task<List<NoteModel>> ReadAll()
    {
        var notes = _dbContext.Notes.ToList();
        return Task.FromResult(notes);
    }

    public async Task<NoteModel> Update(NoteModel note)
    {
        _dbContext.Entry(note).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return note;
    }

    public async Task Delete(string id)
    {
        var note = await _dbContext.Notes.FindAsync(id);
        if (note != null) _dbContext.Notes.Remove(note);
        await _dbContext.SaveChangesAsync();
    }

}
