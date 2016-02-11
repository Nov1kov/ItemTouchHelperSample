namespace ItemTouchHelperSampleAndroid.ContactsList
{
    public interface IItemTouchHelperAdapter
    {
        void OnItemMove(int fromPosition, int toPosition);
        void OnItemDismiss(int position);
    }
}