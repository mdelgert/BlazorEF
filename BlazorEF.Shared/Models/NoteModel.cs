using System.ComponentModel.DataAnnotations;

namespace BlazorEF.Shared.Models;

public class NoteModel
{
    [Key]
    public string NoteId { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
