using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.Education;

namespace Resume.Web.Areas.Admin.Controllers;

public class EducationController : AdminBaseController
{
    #region Fields

    private readonly IEducationService _educationService;

    #endregion

    #region Constructor

    public EducationController(IEducationService educationService)
    {
        _educationService = educationService;
    }

    #endregion

    #region Actions

    #region List

    public async Task<IActionResult> List(FilterEducationViewModel filter)
    {
        var model = await _educationService.FilterAsync(filter);
        return View(model);
    }

    #endregion

    #region Create

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEducationViewModel model)
    {
        #region Validations

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        #endregion

        var result = await _educationService.CreateAsync(model);
        switch (result)
        {
            case CreateEducationResult.Success:
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                return RedirectToAction("List");

            case CreateEducationResult.Error:
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد.";
                break;
        }

        return View(model);
    }

    #endregion

    #region Edit

    public async Task<IActionResult> Edit(int id)
    {
        var model = await _educationService.GetForEditByIdAsync(id);

        if (model == null)
            return NotFound();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditEducationViewModel model)
    {
        #region Validations

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        #endregion

        var result = await _educationService.EditAsync(model);
        switch (result)
        {
            case EditEducationResult.Success:
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                return RedirectToAction("List");

            case EditEducationResult.Error:
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد.";
                break;

            case EditEducationResult.EducationNotFound:
                TempData[ErrorMessage] = "تحصیلات پیدا نشد.";
                break;
        }

        return View(model);
    }

    #endregion

    #endregion
}