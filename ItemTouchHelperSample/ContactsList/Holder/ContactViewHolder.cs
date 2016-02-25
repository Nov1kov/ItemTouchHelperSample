using System;
using Android.Content.Res;
using Android.Support.V4.Content;
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
        public TextView TextName { get; set; }
        public TextView TextInfo { get; set; }
        public ImageView ContactImageView { get; set; }
        public ImageView ContactCheck { get; set; }

        private View BackgroundView { get; }
        private View FrontView { get; }
        private View NoteTextView { get; }
        private View TaskTextView { get; }

        private const int MoveDist = 10;

        enum Moving
        {
            Left, Right, Unknown
        }

        private Moving _holderMove;

        public ContactViewHolder(View view, Action<int> listener)
            : base(view)
        {
            ContactImageView = view.FindViewById<ImageView>(Resource.Id.contactImageView);
            ContactCheck = view.FindViewById<ImageView>(Resource.Id.contactCheck);
            TextName = view.FindViewById<TextView>(Resource.Id.textName);
            TextInfo = view.FindViewById<TextView>(Resource.Id.textInfo);
            FrontView = view.FindViewById<View>(Resource.Id.frontView);
            BackgroundView = view.FindViewById<View>(Resource.Id.backgroundView);
            
            FrontView.Background = ContextCompat.GetDrawable(view.Context, Resource.Drawable.contact_item_gradient_right);
            _holderMove = Moving.Unknown;

            NoteTextView = view.FindViewById<View>(Resource.Id.noteImageView);
            TaskTextView = view.FindViewById<View>(Resource.Id.taskImageView);
            view.Click += (sender, e) => listener(base.AdapterPosition);
        }

        public void MoveFrontView(float x)
        {
            if (x < -MoveDist && (_holderMove == Moving.Right || _holderMove == Moving.Unknown))
            {

                if (_holderMove == Moving.Unknown)
                {
                    _holderMove = Moving.Left;
                    ResetAnimation();
                }
                else
                {
                    _holderMove = Moving.Left;
                    SwitchColorBackGround();
                }
            }
            else if (x > MoveDist && (_holderMove == Moving.Left || _holderMove == Moving.Unknown))
            {
                if (_holderMove == Moving.Unknown)
                {
                    _holderMove = Moving.Right;
                    ResetAnimation();
                }
                else
                {
                    _holderMove = Moving.Right;
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
            switch (_holderMove)
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
            _holderMove = Moving.Unknown;
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

        public void SwipeHolder(int p0)
        {
            //UnSelectedHolderSwipe();
            //ViewCompat.SetTranslationX(FrontView, 0);
            //TranslateAnimation animation = new TranslateAnimation(ViewCompat.GetTranslationX(BackgroundView), 0, 0, 0);
            //BackgroundView.StartAnimation(animation);
            //ViewCompat.Animate(BackgroundView).TranslationX(0);
        }
    }
}