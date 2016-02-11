using System;

namespace ItemTouchHelperSampleAndroid.DataLayer.DataObjects
{
    public class Task
    {
        public Contact FromContact { get; }
        public string Value;
        public DateTime DateTime;

        public Task(Contact fromContact)
        {
            FromContact = fromContact;
        }
    }
}