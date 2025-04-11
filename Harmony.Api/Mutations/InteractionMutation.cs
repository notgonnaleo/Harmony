using Harmony.Api.Contexts;
using Harmony.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harmony.Api.Mutations
{
    public class InteractionMutation
    {
        public async Task<Interaction> LikeSong([Service] AppDbContext context, int userId, int songId)
        {
            var songExist = await context.Songs.Where(x => x.Id == songId).FirstOrDefaultAsync();
            if (songExist == null)
                throw new Exception("Song not found.");

            var exists = await context.Interactions.AnyAsync(i =>
                i.UserId == userId &&
                i.SongId == songId &&
                i.InteractionTypeId == (int)InteractionType.Like);

            if (exists)
                throw new Exception("User already liked this song.");

            var interaction = new Interaction
            {
                UserId = userId,
                SongId = songId,
                InteractionTypeId = (int)InteractionType.Like,
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
                i.InteractionTypeId == (int)InteractionType.Repost);

            if (exists)
                throw new Exception("User already reposted this song.");

            var interaction = new Interaction
            {
                UserId = userId,
                SongId = songId,
                InteractionTypeId = (int)InteractionType.Repost,
                CreatedAt = DateTime.UtcNow
            };

            context.Interactions.Add(interaction);
            await context.SaveChangesAsync();

            return interaction;
        }
    }
}
