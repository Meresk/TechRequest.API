using Microsoft.EntityFrameworkCore;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly Context _dbContext;

        public RoleRepository(Context context)
        {
            _dbContext = context;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleId == id);

            if (role == null)
            {
                return null;
            }

            return role;
        }
    }
}
