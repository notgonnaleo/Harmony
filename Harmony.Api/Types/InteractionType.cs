using Harmony.Api.Entities;

namespace Harmony.Api.Types
{
    public class InteractionType : ObjectType<Interaction>
    {
        protected override void Configure(IObjectTypeDescriptor<Interaction> descriptor)
        {
            descriptor.Name("InteractionType");
            
            descriptor.Field(i => i.UserId)
                .Description("The ID of the user who performed the interaction");
            
            descriptor.Field(i => i.SongId)
                .Description("The ID of the song that was interacted with");
            
            descriptor.Field(i => i.InteractionTypeId)
                .Description("The type of interaction (1 = Like, 2 = Repost)");
            
            descriptor.Field(i => i.Active)
                .Description("Whether the interaction is currently active");
            
            descriptor.Field(i => i.CreatedAt)
                .Description("When the interaction was created");
            
            descriptor.Field(i => i.ModifiedAt)
                .Description("When the interaction was last modified");
        }
    }
}