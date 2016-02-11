using System.Collections.Generic;
using ItemTouchHelperSampleAndroid.DataLayer.DataObjects;

namespace ItemTouchHelperSampleAndroid.DataLayer
{
    public interface IRepository
    {
        IEnumerable<Contact> GetContacts();
        IEnumerable<Task> GetTasks(Contact contact);
        IEnumerable<Note> GetNotes(Contact contact);
    }
}