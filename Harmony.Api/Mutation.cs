using Harmony.Api.Contexts;
using Harmony.Api.Entities;
using Harmony.Api.Mutations;

namespace Harmony.Api
{
    public class Mutation
    {
        public async Task<Song> AddSong([Service] AppDbContext context, string title, int duration, int userId)
        {
            var songMutation = new SongMutation();
            return await songMutation.AddSong(context, title, duration, userId);
        }

        public async Task<Interaction> LikeSong([Service] AppDbContext context, int userId, int songId)
        {
            var interactionMutation = new InteractionMutation();
            return await interactionMutation.LikeSong(context, userId, songId);
        }

        public async Task<Interaction> RepostSong([Service] AppDbContext context, int userId, int songId)
        {
            var interactionMutation = new InteractionMutation();
            return await interactionMutation.RepostSong(context, userId, songId);
        }
    }
}
