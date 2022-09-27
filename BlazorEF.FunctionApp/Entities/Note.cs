using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorEF.FunctionApp.Entities
{
    public class Note
    {
        [Key]
        public string NoteId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}