using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Widget;
using ItemTouchHelperSampleAndroid.ContactsList;
using ItemTouchHelperSampleAndroid.DataLayer.DataObjects;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ItemTouchHelperSampleAndroid
{
    [Activity(Label = "@string/MainActivityLabel", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IContactsListSwipe
    {

        private BaseApp App => (BaseApp) Application;
        private Toolbar _toolbar;
        private ContactsListAdapter _adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (_toolbar != null)
            {
                SetSupportActionBar(_toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
                _toolbar.NavigationClick += delegate
                {
                    OnBackPressed();
                };
            }

            _adapter = new ContactsListAdapter(this);
            _adapter.ItemClick += OnItemClick;

            var contactsListView = FindViewById<RecyclerView>(Resource.Id.contactsListView);
            contactsListView.SetAdapter(_adapter);
            contactsListView.SetLayoutManager(new LinearLayoutManager(contactsListView.Context));

            ItemTouchHelper.Callback callback = new ContactsListCallBacks(_adapter, this);
            ItemTouchHelper itemTouchHelper = new ItemTouchHelper(callback);
            itemTouchHelper.AttachToRecyclerView(contactsListView);
            contactsListView.SetItemAnimator(new DefaultItemAnimator());
        }

        protected override void OnStart()
        {
            base.OnStart();
            _adapter.UpdateList(App.DataProvider.GetContacts());
        }

        void OnItemClick(object sender, int id)
        {
                
        }

        public void SwipeLeft(int itemId)
        {
            Toast.MakeText(this, "тут мы улетаем в другой экран", ToastLength.Short).Show();
           // _adapter.NotifyItemChanged(itemId);
        }

        public void SwipeRight(int itemId)
        {
            Toast.MakeText(this, "тут мы улетаем в другой экран", ToastLength.Short).Show();
            //_adapter.NotifyItemChanged(itemId);
        }
    }
}

