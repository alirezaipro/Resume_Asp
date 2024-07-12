using Resume.DAL.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Interface
{
    public interface IActivityService
    {
        Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);

        Task<CreateActivityResult> CreateAsync(CreateActivityViewModel model);

        Task<EditActivityResult> UpdateAsync(EditActivityViewModel model);

        Task<EditActivityViewModel?> GetInfoByIdAsync(int id);

        Task<List<ActivityDetailsViewModel>> GetAllInfo();
    }
}
