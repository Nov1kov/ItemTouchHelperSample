using System.Collections.Generic;
using ItemTouchHelperSampleAndroid.DataLayer.DataObjects;

namespace ItemTouchHelperSampleAndroid.DataLayer
{
    public class DataProvider
    {
        private readonly IRepository _repository;

        public DataProvider()
        {
            _repository = new MockRepository();
        }

        public IList<Contact> GetContacts()
        {
            return new List<Contact>(_repository.GetContacts());
        }

        public IList<Task> GetTasks(Contact contact)
        {
            return new List<Task>(_repository.GetTasks(contact));
        }

        public IList<Note> GetNotes(Contact contact)
        {
            return new List<Note>(_repository.GetNotes(contact));
        }
    }
}