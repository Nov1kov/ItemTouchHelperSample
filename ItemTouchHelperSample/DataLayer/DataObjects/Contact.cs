using System.Collections.Generic;

namespace ItemTouchHelperSampleAndroid.DataLayer.DataObjects
{
    public class Contact
    {
        public int Id { get; }

        public string Title { get; set; }
        public string CompanyIs { get; set; }
        public byte[] Icon { get; set; }
        public bool IsActive { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Note> Notes { get; set; }

        public Contact()
        {
            Id = 0;
            Notes = new List<Note>();
            Tasks = new List<Task>();
        }
    }
}