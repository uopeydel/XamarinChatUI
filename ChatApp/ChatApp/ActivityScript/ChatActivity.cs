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

            var textTyper = FindViewById<EditText>(Resource.Id.textMessageTyper);
            var linLayout = FindViewById<LinearLayout>(Resource.Id.linLayout);
            var btnAdd = FindViewById<Button>(Resource.Id.btnSend);
            var scrollChatView = FindViewById<ScrollView>(Resource.Id.messageScroll);

            btnAdd.Click += (sender, args) =>
            {
                SwapLeftRight = !SwapLeftRight;
                var textView = new TextView(this)
                {
                    Text = textTyper.Text,
                };
                textView.Gravity = SwapLeftRight == true ? GravityFlags.Right : GravityFlags.Left;

                textView.SetWidth(ViewGroup.LayoutParams.MatchParent);
                textView.SetForegroundGravity(GravityFlags.Right);


                linLayout.AddView(textView);
                scrollChatView.FullScroll(FocusSearchDirection.Down);

            };


            scrollChatView.ScrollChange += (sender, args) =>
            {
                if (sender is ScrollView scrollView)
                {
                    var hightOfFirstObject = scrollView.GetChildAt(0).Height;
                    var scrollBtn = hightOfFirstObject - scrollView.Height;
                    if (scrollBtn <= scrollView.ScrollY)
                    {
                        textTyper.Text = $"This is SCROLL bottom end; //hightOfFirstObject {hightOfFirstObject}  // scrollView Height {scrollView.Height}  // ScrollY {scrollView.ScrollY}";
                    } 

                } 
            };


        }
    }
}