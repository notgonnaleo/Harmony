using Harmony.Api.Contexts;
using Harmony.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harmony.Api.Mutations
{
    public class InteractionMutation
    {
        public async Task<Interaction> LikeSong([Service] AppDbContext context, int userId, int songId)
        {
            var exists = await context.Interactions.AnyAsync(i =>
                i.UserId == userId &&
                i.SongId == songId &&
                i.InteractionType == InteractionType.Like);

            if (exists)
                throw new Exception("User already liked this song.");

            var interaction = new Interaction
            {
                UserId = userId,
                SongId = songId,
                InteractionType = InteractionType.Like,
                CreatedAt = DateTime.UtcNow
            };

            context.Interactions.Add(interaction);
            await context.SaveChangesAsync();

            return interaction;
        }

        public async Task<Interaction> RepostSong([Service] AppDbContext context, int userId, int songId)
        {
            var exists = await context.Interactions.AnyAsync(i =>
                i.UserId == userId &&
                i.SongId == songId &&
                i.InteractionType == InteractionType.Repost);

            if (exists)
                throw new Exception("User already reposted this song.");

            var interaction = new Interaction
            {
                UserId = userId,
                SongId = songId,
                InteractionType = InteractionType.Repost,
                CreatedAt = DateTime.UtcNow
            };

            context.Interactions.Add(interaction);
            await context.SaveChangesAsync();

            return interaction;
        }
    }
}
