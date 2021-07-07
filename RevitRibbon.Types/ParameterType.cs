using HotChocolate;
using HotChocolate.Types;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using System.Linq;

namespace RevitRibbon.Types
{
    public class ParameterType : ObjectType<Parameter>
    {
        protected override void Configure(IObjectTypeDescriptor<Parameter> descriptor)
        {
            descriptor.Description("Table of related code to language description");

            descriptor.Field(x => x.Created).Ignore();
            descriptor.Field(x => x.CreatedBy).Ignore();
            descriptor.Field(x => x.LastModified).Ignore();
            descriptor.Field(x => x.LastModifiedBy).Ignore();

            descriptor.Field(x => x.RevitParam)
                .ResolveWith<Resolvers>(m => m.GetRevitParam(default!, default!))
                .UseDbContext<RevitRibbonContext>()
                .Description("Get associated Revit parameter");

            descriptor.Field(x => x.Group)
                .ResolveWith<Resolvers>(m => m.GetGroup(default!, default!))
                .UseDbContext<RevitRibbonContext>()
                .Description("Get associated group");
        }

        private class Resolvers
        {
            public Group GetGroup(Parameter parameter, [ScopedService] RevitRibbonContext context)
            {
                return context.Groups.FirstOrDefault(x => x.Id == parameter.GroupId);
            }

            public RevitParam GetRevitParam(Parameter parameter, [ScopedService] RevitRibbonContext context)
            {
                return context.RevitParams.FirstOrDefault(x => x.Id == parameter.RevitParamId);
            }
        }
    }
}