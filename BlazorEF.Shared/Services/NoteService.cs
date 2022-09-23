using Bogus;
using Bogus.DataSets;
using BlazorEF.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorEF.Shared.Services;

public interface INoteService
{
    Task<List<NoteModel>> ShowAllNotes(string search, int pageNumber, int pageSize);
    Task<int> GetCount(string search);
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

    public Task<List<NoteModel>> ShowAllNotes(string search, int pageNumber, int pageSize)
    {
        var queryable = (from notes in _dbContext.Notes.AsNoTracking()
                orderby notes.NoteId descending
                select notes
            ).AsQueryable();
        
        if (!string.IsNullOrEmpty(search))
        {
            queryable = queryable.Where(m => m.Title != null && m.Title.Contains(search));
        }

        var result = queryable.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        
        return Task.FromResult(result);
    }
    
    public Task<int> GetCount(string search)
    {
        var queryable = (from notes in _dbContext.Notes.AsNoTracking()

                orderby notes.NoteId descending
                select notes
            ).AsQueryable();


        if (!string.IsNullOrEmpty(search))
        {
            queryable = queryable.Where(m => m.Title != null && m.Title.Contains(search));
        }

        return Task.FromResult(queryable.Count());
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
