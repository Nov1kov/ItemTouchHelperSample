using System;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace ItemTouchHelperSampleAndroid.ContactsList.Holder
{
    public class ContactViewHolder : RecyclerView.ViewHolder,
         IContactViewHolder
    {
        public TextView textName { get; set; }
        public TextView textInfo { get; set; }
        public ImageView contactImageView { get; set; }
        public ImageView contactCheck { get; set; }

        private View BackgroundView { get; set; }
        private View FrontView { get; set; }
        private TextView NoteTextView { get; set; }
        private TextView TaskTextView { get; set; }

        enum Moving
        {
            Left, Right, Unknown
        }

        private Moving HolderMove;

        public ContactViewHolder(View view, Action<int> listener)
            : base(view)
        {
            contactImageView = view.FindViewById<ImageView>(Resource.Id.contactImageView);
            contactCheck = view.FindViewById<ImageView>(Resource.Id.contactCheck);
            textName = view.FindViewById<TextView>(Resource.Id.textName);
            textInfo = view.FindViewById<TextView>(Resource.Id.textInfo);
            FrontView = view.FindViewById<View>(Resource.Id.frontView);
            BackgroundView = view.FindViewById<View>(Resource.Id.backgroundView);

            FrontView.Background = view.Context.Resources.GetDrawable(
                Resource.Drawable.contact_item_gradient_right);
            HolderMove = Moving.Unknown;

            NoteTextView = view.FindViewById<TextView>(Resource.Id.noteTextView);
            TaskTextView = view.FindViewById<TextView>(Resource.Id.taskTextView);
            view.Click += (sender, e) => listener(base.AdapterPosition);
        }

        public void MoveFrontView(float x)
        {
            if (x < 0 && (HolderMove == Moving.Right || HolderMove == Moving.Unknown))
            {

                if (HolderMove == Moving.Unknown)
                {
                    HolderMove = Moving.Left;
                    ResetAnimation();
                }
                else
                {
                    HolderMove = Moving.Left;
                    SwitchColorBackGround();
                }
            }
            else if (x > 0 && (HolderMove == Moving.Left || HolderMove == Moving.Unknown))
            {
                if (HolderMove == Moving.Unknown)
                {
                    HolderMove = Moving.Right;
                    ResetAnimation();
                }
                else
                {
                    HolderMove = Moving.Right;
                    SwitchColorBackGround();
                }
            }

            ViewCompat.SetTranslationX(FrontView, x);
        }

        private void ResetAnimation()
        {
            SetBackGroundColor();
            Animation alphaAnim2 = new AlphaAnimation(0, 1);
            alphaAnim2.Duration = 300;
            BackgroundView.StartAnimation(alphaAnim2);
        }

        private void SwitchColorBackGround()
        {
            Animation alphaAnim1 = new AlphaAnimation(1, 0);
            alphaAnim1.Duration = 300;
            alphaAnim1.AnimationEnd += (sender, args) =>
            {
                ResetAnimation();
            };
            BackgroundView.StartAnimation(alphaAnim1);
        }

        private void SetBackGroundColor()
        {
            BackgroundView.Visibility = ViewStates.Visible;
            switch (HolderMove)
            {
                case Moving.Left:
                    NoteTextView.Visibility = ViewStates.Invisible;
                    TaskTextView.Visibility = ViewStates.Visible;
                    BackgroundView.SetBackgroundResource(Android.Resource.Color.HoloBlueDark);
                    FrontView.SetBackgroundResource(Resource.Drawable.contact_item_gradient_left);
                    break;
                case Moving.Right:
                    NoteTextView.Visibility = ViewStates.Visible;
                    TaskTextView.Visibility = ViewStates.Invisible;
                    BackgroundView.SetBackgroundResource(Android.Resource.Color.HoloRedDark);
                    FrontView.SetBackgroundResource(Resource.Drawable.contact_item_gradient_right);
                    break;
            }
        }

        public void SelectedHolderSwipe()
        {
            HolderMove = Moving.Unknown;
        }

        public void UnSelectedHolderSwipe()
        {
            Animation alphaAnim = new AlphaAnimation(1, 0);
            alphaAnim.Duration = 300;
            alphaAnim.AnimationEnd += (sender, args) =>
            {
                BackgroundView.Visibility = ViewStates.Gone;
            };
            BackgroundView.StartAnimation(alphaAnim);

        }

    }
}