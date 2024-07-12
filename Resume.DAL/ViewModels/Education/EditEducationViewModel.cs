using System.ComponentModel.DataAnnotations;

namespace Resume.DAL.ViewModels.Education;

public class EditEducationViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد.")]

    public string Title { get; set; }

    [Display(Name = "تاریخ از")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public DateOnly Start { get; set; }

    [Display(Name = "تاریخ تا")] 
    public DateOnly? End { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(800, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد.")]
    public string Description { get; set; }
}

public enum EditEducationResult
{
    Success,
    EducationNotFound,
    Error
}