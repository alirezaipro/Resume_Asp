using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Activity;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class ActivityRepository : IActivityRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public ActivityRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model)
        {
            var query = _context.Activities.AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(a => EF.Functions.Like(a.Title, $"%{model.Title}%"));

            #endregion

            #region Order by

            query = query.OrderByDescending(a => a.CreateDate);

            #endregion

            #region Paging

            await model.Paging(query.Select(a => new ActivityDetailsViewModel()
            {
                CreateDate = a.CreateDate,
                Description = a.Description,
                Icon = a.Icon,
                Id = a.Id,
                Title = a.Title
            }));

            #endregion

            return model;
        }

		public async Task<List<ActivityDetailsViewModel>> GetAllInfo()
		{
            return await _context.Activities
                .Select(a => new ActivityDetailsViewModel()
                {
                    CreateDate = a.CreateDate,
                    Description = a.Description,
                    Icon = a.Icon,
                    Id = a.Id,
                    Title = a.Title
                })
                .ToListAsync();
		}

		public async Task<Activity?> GetByIdAsync(int id)
        {
            return await _context.Activities
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<EditActivityViewModel?> GetInfoByIdAsync(int id)
        {
            return await _context.Activities
                .Select(a => new EditActivityViewModel()
                {
                    Description = a.Description,
                    Icon = a.Icon,
                    Id = a.Id,
                    Title = a.Title
                })
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task InsertAsync(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Activity activity)
        {
            _context.Activities.Update(activity);
        }
    }
}
