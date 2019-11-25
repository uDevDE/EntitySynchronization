using EntitySynchronization.Core.Extensions;
using EntitySynchronization.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EntitySynchronization.Core.Helpers
{
    public static class EntitySynchronizationHelper
    {
        public static IEnumerable<Type> GetClassesWithEntityInterface(Assembly[] assemblies) => 
            assemblies.GetLoadableTypes().Where(t => t.IsClass).Where(typeof(IEntitySyncable).IsAssignableFrom).ToList();

        public static bool IsAssignableFromEntityInterface(Type type) => 
            typeof(IEntitySyncable).IsAssignableFrom(type);

        public static IEnumerable<PropertyInfo> GetSubClassesWithEntityInterface(PropertyInfo[] propertyInfos) => 
            propertyInfos.Where(x => typeof(IEntitySyncable).IsAssignableFrom(x.PropertyType) == true).ToList();

    }
}
