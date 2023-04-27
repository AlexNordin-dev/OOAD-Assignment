using Microsoft.EntityFrameworkCore;
using xCore.Contexts;
using xCore.Models.Entities;

namespace xCore.Repositories
{
    public class TagsRepository
    {
        private readonly DataContext _context;

        public TagsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tag>> GetAllTags()
        {

            return await _context.Tags.ToListAsync();
        }
    }
}
