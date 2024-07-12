using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.Education;

namespace Resume.Web.Components;

public class EducationViewComponent : ViewComponent
{
    #region Fields

    private readonly IEducationService _educationService;

    #endregion

    #region Constructor

    public EducationViewComponent(IEducationService educationService)
    {
        _educationService = educationService;
    }

    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _educationService.FilterAsync(new FilterEducationViewModel()
        {
        });

        return View("Education", model);
    }

    #endregion
}