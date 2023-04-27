using Microsoft.EntityFrameworkCore;
using xCore.Contexts;
using xCore.Models.Entities;

namespace xCore.Repositories
{
    public class AuthorsRepository
    {
        private readonly DataContext _context;

        public AuthorsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            
            return await _context.Authors.ToListAsync();
        }
    }
}
