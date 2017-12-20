
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.Lang;
using VirtualEvent.Droid.Helper;

namespace VirtualEvent.Droid
{

	public class NotificationAdatper : RecyclerView.Adapter, View.IOnClickListener
	{
		List<Notification> mList;
		Activity activity;

		public NotificationAdatper(List<Notification> list, Activity CurrentActivity) {
			mList = list;
			activity = CurrentActivity;


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
			vh.txtvwNotification.Text = mList[position].Question;
			vh.txtvwDate.Text = mList[position].DateOfEvent.ToString(DroidConstant.DATE);
			vh.txtvwTime.Text = mList[position].DateOfEvent.ToLocalTime().ToString(DroidConstant.TIME);;
			vh.txtvwEventName.Text = mList[position].EventTitle;
			vh.mainLyt.SetTag(Resource.String.pos, position);

		

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
			View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_notification, parent, false);
			PropertyViewHolder vh = new PropertyViewHolder(itemView);
			vh.mainLyt.SetOnClickListener(this);
			return vh;
		}

		public void UpdateList(List<Notification> list) {
			mList.AddRange(list);
			NotifyDataSetChanged(); 
		}
	
		public class PropertyViewHolder : RecyclerView.ViewHolder//, View.IOnClickListener
		{
			public LinearLayout mainLyt { get; private set; }
			public TextView txtvwNotification { get; private set; }
			public TextView txtvwEventName { get; private set; }
			public TextView txtvwDate { get; private set; }
			public TextView txtvwTime { get; private set; }
	
			
			public PropertyViewHolder(View itemView) : base(itemView)
			{
				mainLyt= (LinearLayout)itemView.FindViewById(Resource.Id.main_layt);
				txtvwNotification = (TextView)itemView.FindViewById(Resource.Id.txtvwNotification);
				txtvwEventName = (TextView)itemView.FindViewById(Resource.Id.txtvwEventName);
				txtvwDate = (TextView)itemView.FindViewById(Resource.Id.txtvwDate);
				txtvwTime= (TextView)itemView.FindViewById(Resource.Id.txtvwTime);


			}
		 }
	}
}
