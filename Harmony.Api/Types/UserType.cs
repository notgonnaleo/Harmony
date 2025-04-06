using Harmony.Api.Entities;
using Harmony.Api.Resolvers;
using HotChocolate.Types;

namespace Harmony.Api.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(u => u.Id);
            descriptor.Field(u => u.Username);

            descriptor
                .Field("totalLikesGiven")
                .ResolveWith<UserResolver>(r => r.GetTotalLikesGivenAsync(default!))
                .Type<IntType>();
        }
    }
}
