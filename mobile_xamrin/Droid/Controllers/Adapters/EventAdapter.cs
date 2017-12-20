
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Core;
using Java.Lang;
using VirtualEvent.Droid.Helper;

namespace VirtualEvent.Droid
{

public class EventAdapter : RecyclerView.Adapter, View.IOnClickListener
	{
		ImageLoader imageLoader;
		List<EventList> mList;
		Activity activity;

		DisplayImageOptions options;


		public EventAdapter(List<EventList> list, Activity CurrentActivity) {
			mList = list;
			activity = CurrentActivity;
			imageLoader = ImageLoader.Instance;
			imageLoader.Init(ImageLoaderConfiguration.CreateDefault(activity));
			options = new DisplayImageOptions.Builder()
		.CacheInMemory(true)
		.CacheOnDisk(true).Build();

		}

		public override int ItemCount
		{
			get
			{
				return mList.Count;
			}
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			PropertyViewHolder vh = holder as PropertyViewHolder;
			vh.txtvwTitle.Text = mList[position].Title;
			vh.txtvwDate.Text = mList[position].DateOfEvent.ToLocalTime().ToString(DroidConstant.DATE_FORMAT);
			vh.txtvwVenue.Text = mList[position].Description;
			vh.mainLyt.SetTag(Resource.String.pos, position);

			// Load image
			if (!string.IsNullOrEmpty(mList[position].MediaUrl)){
				imageLoader.DisplayImage(mList[position].MediaUrl, vh.imgvwEvent);
			}
			else {
				vh.imgvwEvent.SetImageResource(Resource.Drawable.list_placeholder);	
			}

			if (!string.IsNullOrEmpty(Convert.ToString(mList[position].EnrolmentDate)) && mList[position].IsEnrolled){
				vh.txtvwEnrollDate.Text = "Enrollment: "+mList[position].DateOfEvent.ToLocalTime().ToString(DroidConstant.DATE);
				vh.txtvwEnrollDate.Visibility= ViewStates.Visible;	
			} else {
					vh.txtvwEnrollDate.Visibility= ViewStates.Gone;
				vh.txtvwEnrollDate.Text = "";

			}
		}

		public void OnClick(View v)
		{
			int pos =Integer.ParseInt((Integer)v.GetTag(Resource.String.pos)+"");
			var activity2 = new Intent(activity, typeof(EventDetailActivity));
			activity2.PutExtra ("eventId", mList[pos].EventId);
			activity.StartActivity(activity2);


		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_event, parent, false);
			PropertyViewHolder vh = new PropertyViewHolder(itemView);
			vh.mainLyt.SetOnClickListener(this);
			return vh;
		}

		public void UpdateList(List<EventList> list) {
			mList.AddRange(list);
			NotifyDataSetChanged(); 
		}
	
		public class PropertyViewHolder : RecyclerView.ViewHolder//, View.IOnClickListener
		{
			public LinearLayout mainLyt { get; private set; }
			public ImageView imgvwEvent { get; private set; }
			public TextView txtvwTitle { get; private set; }
			public TextView txtvwDate { get; private set; }
			public TextView txtvwVenue { get; private set; }
			public TextView txtvwEnrollDate { get; private set; }
	
			
			public PropertyViewHolder(View itemView) : base(itemView)
			{
				mainLyt= (LinearLayout)itemView.FindViewById(Resource.Id.main_layt);
				imgvwEvent = (ImageView)itemView.FindViewById(Resource.Id.imgvw_event);
				txtvwTitle = (TextView)itemView.FindViewById(Resource.Id.txtvw_title);
				txtvwDate = (TextView)itemView.FindViewById(Resource.Id.txtvw_date);
				txtvwVenue = (TextView)itemView.FindViewById(Resource.Id.txtvw_venue);
				txtvwEnrollDate= (TextView)itemView.FindViewById(Resource.Id.txtvw_enroll_date);


			}
		 }
	}
}
