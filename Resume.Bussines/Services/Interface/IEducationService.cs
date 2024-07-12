using Resume.DAL.ViewModels.Education;

namespace Resume.Bussines.Services.Interface;

public interface IEducationService
{
    Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model);

    Task<CreateEducationResult> CreateAsync(CreateEducationViewModel model);

    Task<EditEducationResult> EditAsync(EditEducationViewModel model);

    Task<EditEducationViewModel> GetForEditByIdAsync(int id);
}