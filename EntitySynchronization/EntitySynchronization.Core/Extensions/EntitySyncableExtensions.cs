using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EntitySynchronization.Core.Interfaces;

namespace EntitySynchronization.Core.Extensions
{
    public static class EntitySyncableExtensions
    {
        public static Guid CreateIdentifier(this IEntitySyncable entity) => Guid.NewGuid();

        public static void UpdateEntityPropertyValue<T>(this IEntitySyncable entity, T value, string propertyName)
        {
            var type = typeof(T);
            var propertyType = value.GetType();

            // ...
        }

        public static IList<Type> GetLoadableTypes(this Assembly[] assemblies)
        {
            if (assemblies == null) throw new ArgumentNullException("assemblies", "Assemblies is null");
            var result = new List<Type>();
            foreach (var asm in assemblies)
            {
                try
                {
                    result.AddRange(asm.GetTypes());
                }
                catch (ReflectionTypeLoadException e)
                {
                    result.AddRange(e.Types.Where(t => t != null));
                }
            }

            return result;
        }

    }
}
