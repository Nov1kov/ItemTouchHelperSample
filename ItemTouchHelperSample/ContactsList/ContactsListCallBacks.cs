using System.Threading;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using ItemTouchHelperSampleAndroid.ContactsList.Holder;
using Java.Lang;

namespace ItemTouchHelperSampleAndroid.ContactsList
{
    public class ContactsListCallBacks : ItemTouchHelper.Callback
    {
        private readonly IItemTouchHelperAdapter _adapter;
        private readonly IContactsListSwipe _swipeListener;

        public ContactsListCallBacks(IItemTouchHelperAdapter adapter, IContactsListSwipe swipeListener)
        {
            _adapter = adapter;
            _swipeListener = swipeListener;
        }

        public override void ClearView(RecyclerView p0, RecyclerView.ViewHolder viewHolder)
        {
            base.ClearView(p0, viewHolder);
            IContactViewHolder itemViewHolder = (IContactViewHolder)viewHolder;
            itemViewHolder.UnSelectedHolderSwipe();
        }

        public override int GetMovementFlags(RecyclerView p0, RecyclerView.ViewHolder p1)
        {
            int dragFlags = ItemTouchHelper.Up | ItemTouchHelper.Down;
            int swipeFlags = ItemTouchHelper.Start | ItemTouchHelper.End;
            return MakeMovementFlags(dragFlags, swipeFlags);
        }

        public override void OnChildDraw(Canvas p0, RecyclerView p1, RecyclerView.ViewHolder p2, float dX, float dY, int actionState, bool p6)
        {
            if (actionState == ItemTouchHelper.ActionStateSwipe)
            {
                IContactViewHolder viewHolder = (IContactViewHolder)p2;
                viewHolder.MoveFrontView(dX);
            }
            else
            {
                base.OnChildDraw(p0, p1, p2, dX, dY, actionState, p6);
            }
        }

        public override bool OnMove(RecyclerView p0,
            RecyclerView.ViewHolder p1,
            RecyclerView.ViewHolder p2)
        {
            _adapter.OnItemMove(p1.AdapterPosition, p2.AdapterPosition);
            return true;
        }

        public override void OnSelectedChanged(RecyclerView.ViewHolder viewHolder, int actionState)
        {
            if (actionState == ItemTouchHelper.ActionStateSwipe)
            {
                IContactViewHolder itemViewHolder = (IContactViewHolder)viewHolder;
                itemViewHolder.SelectedHolderSwipe();
            }
            base.OnSelectedChanged(viewHolder, actionState);
        }

        public override void OnSwiped(RecyclerView.ViewHolder p0, int p1)
        {
            
            if (p1 == ItemTouchHelper.Start)
            {
                _swipeListener.SwipeLeft(p0.AdapterPosition);
            }
            else if (p1 == ItemTouchHelper.End)
            {
                _swipeListener.SwipeRight(p0.AdapterPosition);
            }

            _adapter.OnItemDismiss(p0.AdapterPosition);
            /*
            Handler handler = new Handler();
            Runnable runnable = new Runnable(() =>
            {
                _adapter.OnItemDismiss(p0.AdapterPosition);
            });
            handler.PostDelayed(runnable, 300);*/

            IContactViewHolder itemViewHolder = (IContactViewHolder) p0;
            itemViewHolder.SwipeHolder(p1);
        }

        public override bool IsItemViewSwipeEnabled => true;

        public override bool IsLongPressDragEnabled => true;
    }

}