using System;
using System.Collections.Generic;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using ItemTouchHelperSampleAndroid.ContactsList.Holder;
using ItemTouchHelperSampleAndroid.DataLayer.DataObjects;

namespace ItemTouchHelperSampleAndroid.ContactsList
{
    public class ContactsListAdapter : RecyclerView.Adapter,
           IItemTouchHelperAdapter
    {

        public event EventHandler<int> ItemClick;
        private readonly Activity _activity;
        private IList<Contact> _contacts;

        public ContactsListAdapter(Activity activity)
            : base()
        {
            this._activity = activity;
        }

        public void UpdateList(IList<Contact> objects)
        {
            _contacts?.Clear();
            _contacts = objects;
            NotifyDataSetChanged();
        }

        public Contact GetItem(int position)
        {
            return _contacts[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int ItemCount => _contacts.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var h = holder as ContactViewHolder;
            var item = _contacts[position];

            //LayerDrawable l = new LayerDrawable();

            if (item.Icon == null)
            {
              
            }
            else
            {
      
            }

            h.ContactCheck.SetImageResource(item.IsActive ?
                Android.Resource.Drawable.PresenceOnline :
                Android.Resource.Drawable.PresenceOffline);

            h.TextName.Text = item.Title;
            h.TextInfo.Text = item.CompanyIs;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = _activity.LayoutInflater.Inflate(Resource.Layout.item_from_contact_list,
                                                        parent,
                                                        false);
            ContactViewHolder vh = new ContactViewHolder(view, OnClick);

            return vh;
        }

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        #region IItemTouchHelperAdapter

        public void OnItemMove(int fromPosition, int toPosition)
        {
            Contact prev = _contacts[fromPosition];
            _contacts.Remove(prev);
            _contacts.Insert(toPosition > fromPosition ? toPosition - 1 : toPosition, prev);
            NotifyItemMoved(fromPosition, toPosition);
        }

        public void OnItemDismiss(int position)
        {
            _contacts.RemoveAt(position);
            NotifyItemRemoved(position);
        }
        #endregion
    }
}