
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;



namespace VirtualEvent.Droid
{
	[Activity(Label = "JWPlayerActivity",  Theme = "@style/Theme.AppCompat.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
	public class JWPlayerActivity : Activity
	{
		string streamUrl = "";
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			streamUrl = Intent.GetStringExtra("videoUrl");
			// Create your application here
			SetContentView(Resource.Layout.activity_jw_player);
			WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
			localWebView.SetWebViewClient (new WebViewClient());
			localWebView.SetWebChromeClient(new WebChromeClient());
			localWebView.Settings.SetPluginState(WebSettings.PluginState.On);
			localWebView.Settings.JavaScriptEnabled=(true);
			localWebView.Settings.UseWideViewPort = (true);
			localWebView.Settings.LoadWithOverviewMode = (true);
			//localWebView.LoadUrl("http://138.91.253.129/virtualevent.App/Media/PlayVideo?EventId=124");
			localWebView.LoadUrl(streamUrl);




//JWPlayerFragment fragment = (JWPlayerFragment)getFragmentManager().findFragmentById(R.id.playerFragment);

// Get a handle to the JWPlayerView
//JWPlayerView playerView = fragment.getPlayer();

// Create a PlaylistItem
//PlaylistItem video = new PlaylistItem("http://ttmediaservices01.streaming.mediaservices.windows.net/ddf81c65-26b1-4cb7-88c1-c32d83c28bc1/TimelessToday_Open_Top_720.ism/manifest(format=mpd-time-csf)");

//playerView.setControls(false);
        //PlaylistItem pi = new PlaylistItem.Builder()
				//.file("http://ttmediaservices01.streaming.mediaservices.windows.net/076699f6-a7ba-4c7c-b269-a7d4f715174c/Essential_Insights_RTP_Interview_Full_900mb.ism/manifest(format=m3u8-aapl-v3)")
				//.title("MyVideo")
				//.description("Testing video.")
				//.build();

// Load a stream into the player
//playerView.load(pi);
        //playerView.play();
		}
	}
}
