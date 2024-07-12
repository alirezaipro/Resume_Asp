using System.ComponentModel.DataAnnotations;
using Azure;
using Resume.DAL.ViewModels.Common;

namespace Resume.DAL.ViewModels.Education;

public class FilterEducationViewModel:BasePaging<EducationViewModel>
{
    [Display(Name = "عنوان")]
    public string? Title { get; set; }

    [Display(Name = "تاریخ از")]
    public DateOnly? Start { get; set; }

    [Display(Name = "تاریخ تا")]
    public DateOnly? End { get; set; }
}