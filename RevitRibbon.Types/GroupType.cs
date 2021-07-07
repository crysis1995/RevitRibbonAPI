using HotChocolate;
using HotChocolate.Types;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using System.Linq;

namespace RevitRibbon.Types
{
    public class GroupType : ObjectType<Group>
    {
        protected override void Configure(IObjectTypeDescriptor<Group> descriptor)
        {
            descriptor.Description("Table of Revit elements group with type of element if needed");

            descriptor.Field(x => x.Created).Ignore();
            descriptor.Field(x => x.CreatedBy).Ignore();
            descriptor.Field(x => x.LastModified).Ignore();
            descriptor.Field(x => x.LastModifiedBy).Ignore();

            descriptor.Field(x => x.Type)
                .Description("Type of element for example P for Floors");
            descriptor.Field(x => x.IsNullable)
                .Description("If false WB_Classification will break on elements without this parameter");

            descriptor.Field(x => x.Parameters)
                .ResolveWith<Resolvers>(m => m.GetParameters(default!, default!))
                .UseDbContext<RevitRibbonContext>()
                .Description("Get associated parameters");
        }

        private class Resolvers
        {
            public IQueryable<Parameter> GetParameters(Group group, [ScopedService] RevitRibbonContext context)
            {
                return context.Parameters.Where(x => x.GroupId == group.Id);
            }
        }
    }
}