using Resume.DAL.Models.Common;

namespace Resume.DAL.Models.Education;

public class Education : BaseEntity<int>
{
    #region Properties

    public string Title { get; set; }

    public DateOnly Start { get; set; }

    public DateOnly? End { get; set; }

    public string Description { get; set; }

    #endregion
}