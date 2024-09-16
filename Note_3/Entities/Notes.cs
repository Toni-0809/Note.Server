
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Note_3.Entities
{
    public class Notes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Entry { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int NoteListId {  get; set; }
        public NoteList? NoteList { get; set; }

    } 
}