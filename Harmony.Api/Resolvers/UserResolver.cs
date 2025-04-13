using Harmony.Api.Contexts;
using Harmony.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harmony.Api.Resolvers
{
    public class UserResolver
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UserResolver(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Song>> GetUserLikedSongs([Parent] User user)
        {
            var context = _contextFactory.CreateDbContext();
            var likedSongs = await context.Interactions.Where(x => x.UserId == user.Id && x.InteractionTypeId == (int)InteractionType.Like).ToListAsync();
            var songsInfo = await context.Songs.Where(x => likedSongs.Select(l => l.SongId).Contains(x.Id)).ToListAsync();
            return songsInfo ?? new List<Song>();
        }

        public async Task<IEnumerable<Models.Song>> GetUserUploadedSongs([Parent] User user)
        {
            var context = _contextFactory.CreateDbContext();

            var userUploadedSongs = new List<Models.Song>();
            var songs = await context.Songs
                .Where(s => s.ArtistId == user.Id)
                .ToListAsync();

            foreach (var song in songs)
            {
                var artist = context.Users.FirstOrDefault(x => x.Id == song.ArtistId);
                if(artist is null)
                {
                    continue;
                }

                var interactions = context.Interactions.Where(x => x.SongId == song.Id);
                userUploadedSongs.Add(new Models.Song()
                {
                    Id = song.Id,
                    Title = song.Title,
                    Duration = song.Duration,
                    Likes = interactions.Select(x => new Models.Interaction()
                    {
                        SongId = x.SongId,
                        Active = x.Active,
                        InteractionTypeId = x.InteractionTypeId,
                        CreatedAt = x.CreatedAt,
                        ModifiedAt = x.ModifiedAt,
                        UserId = x.UserId
                    })
                    .Where(x => x.InteractionTypeId == (int)InteractionType.Like)
                    .ToList(),
                    Reposts = interactions.Select(x => new Models.Interaction()
                    {
                        SongId = x.SongId,
                        Active = x.Active,
                        InteractionTypeId = x.InteractionTypeId,
                        CreatedAt = x.CreatedAt,
                        ModifiedAt = x.ModifiedAt,
                        UserId = x.UserId
                    })
                    .Where(x => x.InteractionTypeId == (int)InteractionType.Repost)
                    .ToList(),
                    Artist = new Models.User()
                    {
                        Id = artist.Id,
                        Username = artist.Username,
                        DisplayName = artist.DisplayName,
                        EmailAddress = artist.EmailAddress,
                        Followers = artist.Followers,
                        Verified = artist.Verified,
                        CreatedAt = artist.CreatedAt,
                        ModifiedAt = artist.ModifiedAt
                    },
                });
            }
            return userUploadedSongs;
        }
    }
}
