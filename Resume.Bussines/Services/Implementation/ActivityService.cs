using Resume.Bussines.Services.Interface;
using Resume.DAL.Models.Activity;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
    public class ActivityService : IActivityService
    {
        #region Fields

        private readonly IActivityRepository _activityRepository;


        #endregion

        #region Constructor

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<CreateActivityResult> CreateAsync(CreateActivityViewModel model)
        {
            Activity activity = new Activity()
            {
                CreateDate = DateTime.Now,
                Description = model.Description,
                Icon = model.Icon,
                Title = model.Title
            };

            await _activityRepository.InsertAsync(activity);
            await _activityRepository.SaveAsync();

            return CreateActivityResult.Success;
        }

        #endregion

        public Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model)
        {
            return _activityRepository.FilterAsync(model);
        }

		public async Task<List<ActivityDetailsViewModel>> GetAllInfo()
		{
            return await _activityRepository.GetAllInfo();
		}

		public async Task<EditActivityViewModel?> GetInfoByIdAsync(int id)
        {
            return await _activityRepository.GetInfoByIdAsync(id);
        }

        public async Task<EditActivityResult> UpdateAsync(EditActivityViewModel model)
        {
            var activity = await _activityRepository.GetByIdAsync(model.Id);

            if (activity == null)
                return EditActivityResult.ActivityNotFound;

            activity.Title = model.Title;
            activity.Description = model.Description;
            activity.Icon = model.Icon;

            _activityRepository.Update(activity);
            await _activityRepository.SaveAsync();

            return EditActivityResult.Success;
        }
    }
}
