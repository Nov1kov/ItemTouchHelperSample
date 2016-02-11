namespace ItemTouchHelperSampleAndroid.DataLayer.DataObjects
{
    public class Note
    {
        public Contact FromContact { get; }
        public string Value;

        public Note(Contact fromContact)
        {
            FromContact = fromContact;
        }
    }
}