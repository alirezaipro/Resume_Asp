using Resume.DAL.Models.Activity;
using Resume.DAL.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IActivityRepository
    {
        Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);

        Task InsertAsync(Activity activity);

        void Update(Activity activity);

        Task SaveAsync();

        Task<EditActivityViewModel?> GetInfoByIdAsync(int id);

        Task<Activity?> GetByIdAsync(int id);

        Task<List<ActivityDetailsViewModel>> GetAllInfo();

	}
}
