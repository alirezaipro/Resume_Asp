using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Components
{
	public class MyActivityViewComponent : ViewComponent
	{

		#region Fields

		private readonly IActivityService _activityService;

		#endregion

		#region Constructor

		public MyActivityViewComponent(IActivityService activityService)
		{
			_activityService = activityService;
		}

		#endregion

		#region Method

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _activityService.GetAllInfo();
			return View("MyActivity", model);
		}

		#endregion
	}
}
