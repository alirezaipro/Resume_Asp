using Resume.DAL.Models.Education;
using Resume.DAL.ViewModels.Education;

namespace Resume.DAL.Repositories.Interface;

public interface IEducationRepository
{
    Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model);

    Task InsertAsync(Education education);

    Task SaveAsync();

    Task<Education> GetByIdAsync(int id);

    void Update(Education education);

    Task<EditEducationViewModel> GetForEditByIdAsync(int id);
}