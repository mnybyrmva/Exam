using Microsoft.EntityFrameworkCore;
using Studio.Data;
using Studio.Models;

namespace Studio.Services
{
    public class NormalLayoutService
    {
        private readonly DataContext _dataContext;

        public NormalLayoutService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Setting>> GetSetting()
        {
            return await _dataContext.settings.ToListAsync();
        }
    }
}
