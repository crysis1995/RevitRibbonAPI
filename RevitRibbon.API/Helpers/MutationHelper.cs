using RevitRibbon.Database.Common;
using System.Linq;

namespace RevitRibbon.API.Helpers
{
    internal static class MutationHelper
    {
        public static void UpdateEntity<TEntity, Tinput>(this TEntity entity, Tinput input) where TEntity : IEntity
        {
            foreach (var prop in input.GetType().GetProperties().Where(x => x.GetValue(input) is not null))
            {
                entity.GetType().GetProperty(prop.Name).SetValue(entity, prop.GetValue(input));
            }
        }
    }
}