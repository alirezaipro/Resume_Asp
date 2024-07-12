using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Education;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Education;

namespace Resume.DAL.Repositories.Implementation;

public class EducationRepository : IEducationRepository
{
    #region Fields

    private readonly ResumeContext _context;

    #endregion

    #region Constructor

    public EducationRepository(ResumeContext context)
    {
        _context = context;
    }

    #endregion

    public async Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model)
    {
        var query = _context.Educations
            .AsQueryable();

        #region Filters

        if (!string.IsNullOrEmpty(model.Title))
        {
            query = query.Where(e => e.Title.Contains(model.Title));
        }

        if (model.Start.HasValue)
        {
            query = query.Where(e => e.Start >= model.Start.Value);
        }

        if (model.End.HasValue)
        {
            query = query.Where(e => e.End <= model.End.Value);
        }

        #endregion

        query = query.OrderByDescending(e => e.CreateDate);

        #region Pagination

        await model.Paging(query.Select(e => new EducationViewModel()
        {
            Start = e.Start,
            Description = e.Description,
            End = e.End,
            Title = e.Title,
            Id = e.Id,
            CreateDate = e.CreateDate
        }));

        #endregion

        return model;
    }

    public async Task InsertAsync(Education education)
    {
        await _context.Educations.AddAsync(education);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Education> GetByIdAsync(int id)
    {
        return await _context.Educations
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public void Update(Education education)
    {
        _context.Educations.Update(education);
    }

    public async Task<EditEducationViewModel> GetForEditByIdAsync(int id)
    {
        return await _context.Educations
            .Select(e => new EditEducationViewModel
            {
                Id = e.Id,
                Title = e.Title,
                Start = e.Start,
                End = e.End,
                Description = e.Description
            })
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}