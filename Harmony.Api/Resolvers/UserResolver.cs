using Harmony.Api.Contexts;
using Harmony.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harmony.Api.Resolvers
{
    public class UserResolver
    {
        private readonly AppDbContext _context;

        public UserResolver(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalLikesGivenAsync([Parent] User user)
        {
            return await _context.Interactions
                .Where(i => i.UserId == user.Id && i.InteractionType == InteractionType.Like)
                .CountAsync();
        }
    }
}
