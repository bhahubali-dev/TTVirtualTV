
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Support.V7.Widget;
using Android.Views;
using VirtualEvent.Droid.Helper;

namespace VirtualEvent.Droid.Controllers.Fragments
{
	public class EventsFragment : BaseFragment
	{

		private EventAdapter eventAdapter;
		private RecyclerView mainRcyle;
		private IEventListService _IEventListService = null;
		private CustomProgress _objProgress;
		private List<EventList> result = null;
	
		public override async void InitilizeView(View view)
		{
			mainRcyle = (RecyclerView)view.FindViewById(Resource.Id.recylrvw_events);
			result = new List<EventList>(); 
			eventAdapter = new EventAdapter(result,Activity);
			LinearLayoutManager linearLayoutManager = new LinearLayoutManager(Activity);
			linearLayoutManager.Orientation = LinearLayoutManager.Vertical;
			mainRcyle.SetLayoutManager(linearLayoutManager);
			mainRcyle.SetAdapter(eventAdapter);

			_IEventListService = new EventListService();
			await GetEventList();
		
		}

		public override int SetLayout()
		{
			return Resource.Layout.fragment_main;
		}

#region GetPropertyEvent List
/// <summary>
/// Fetch Event 
/// </summary>
/// <returns>List</returns>
async Task<List<EventList>> GetEventList()
{
	
	if (AppUtils.IsNetwork())
	{
		var request = new EventRequest
		{
			PageNo = 1
		};
		_objProgress = new CustomProgress(Activity);
		var Authkey = StorageUtils<String>.GetPreferencesValue(DroidConstant.CurrentUser);
		var response = await _IEventListService.GetEventList(request, ServiceType.EventService, Authkey);
		_objProgress.DismissDialog();
		if (response != null)
		{
			if (response.IsSuccess && response.Result != null)
			{
				result = response.Result;
						if (result.Count == 0 && request.PageNo == 1)
						{
							//AppUtils.ShowToast(Activity, response.Message);
						}
						else {
							eventAdapter.UpdateList(result);
						}
			}
			else
			{
				//AppUtils.ShowToast(Activity, response.Message);
			}
		}
		else
		{
			//AppUtils.ShowToast(Activity, Resources.GetString(Resource.String.network_error));

		}
	}
	else
	{
		AppUtils.ShowToast(Activity, Resources.GetString(Resource.String.network_error));
		_objProgress.DismissDialog();
	}
	return result;
		}


		#endregion
	}
}
//http://138.91.253.129/virtualevent.App/Media/PlayVideo?EventId=124