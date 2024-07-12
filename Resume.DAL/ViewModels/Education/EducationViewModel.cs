namespace Resume.DAL.ViewModels.Education;

public class EducationViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateOnly Start { get; set; }

    public DateOnly? End { get; set; }

    public string Description { get; set; }

    public DateTime CreateDate { get; set; }
}