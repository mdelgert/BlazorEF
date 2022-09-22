using BlazorEF.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorEF.Shared.Services;

public interface INoteService
{
    Task<int> Create(NoteModel note);
    Task<NoteModel> FindById(int id);
    Task<List<NoteModel>> ReadAll();
    Task Update(NoteModel note);
    Task Delete(int id);
}

public class NoteService : INoteService
{
    private readonly DataContext _dbContext;

    public NoteService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Create(NoteModel note)
    {
        _dbContext.Notes.Add(note);
        var id = await _dbContext.SaveChangesAsync();
        return id;
    }

    public async Task<NoteModel> FindById(int id)
    {
        var note = await _dbContext.Notes.FindAsync(id);
        return note;
    }

    public Task<List<NoteModel>> ReadAll()
    {
        var notes = _dbContext.Notes.ToList();
        return Task.FromResult(notes);
    }

    public async Task Update(NoteModel note)
    {
        _dbContext.Entry(note).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var note = await _dbContext.Notes.FindAsync(id);
        if (note != null) _dbContext.Notes.Remove(note);
        await _dbContext.SaveChangesAsync();
    }

}
