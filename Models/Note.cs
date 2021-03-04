using System;
namespace Missioner.Models
{
    public class Note
    {
        public Int64 note_id { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public Int64 creator_id { get; set; }
    }
}
