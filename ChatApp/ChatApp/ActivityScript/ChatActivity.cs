using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Text;
using Android.Views;
using Android.Widget;
using static Android.App.ActionBar;

namespace ChatApp.ActivityScript
{
    [Activity(Label = "ChatActivity")]
    public class ChatActivity : Activity
    {
        private bool SwapLeftRight = true;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_chat);
            // Create your application here

            var textTyper = FindViewById<EditText>(Resource.Id.forms_centralfragments_chat_chat_editText);

            var btnAdd = FindViewById<Button>(Resource.Id.forms_centralfragments_chat_chat_sendButton);
            btnAdd.Click += (sender, args) =>
            {
                SwapLeftRight = !SwapLeftRight;
                var textView = new TextView(this)
                {
                    Text = textTyper.Text + "xxx",
                };
                textView.Gravity = SwapLeftRight == true ? GravityFlags.Right : GravityFlags.Left;

                textView.SetWidth(ViewGroup.LayoutParams.MatchParent);
                textView.SetForegroundGravity(GravityFlags.Right);

                var linLayout = FindViewById<LinearLayout>(Resource.Id.linLayout);
                linLayout.AddView(textView);
            };
        }
    }
}