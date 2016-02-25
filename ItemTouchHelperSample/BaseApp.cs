using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ItemTouchHelperSampleAndroid.DataLayer;

namespace ItemTouchHelperSampleAndroid
{
    [Application(Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    class BaseApp : Application
    {
        protected BaseApp(IntPtr javaReference, JniHandleOwnership transfer) : 
            base(javaReference, transfer)
        {
        }

        public BaseApp()
        {
        }

        public DataProvider DataProvider { get; private set; }

        public override void OnCreate()
        {
            base.OnCreate();
            DataProvider = new DataProvider();
        }
    }
}