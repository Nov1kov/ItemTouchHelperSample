namespace ItemTouchHelperSampleAndroid.ContactsList.Holder
{
    public interface IContactViewHolder
    {
        void MoveFrontView(float x);
        void SelectedHolderSwipe();
        void UnSelectedHolderSwipe();
        void SwipeHolder(int p0);
    }
}