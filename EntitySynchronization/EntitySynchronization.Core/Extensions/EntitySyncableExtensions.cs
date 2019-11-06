using System;

using EntitySynchronization.Core.Interfaces;

namespace EntitySynchronization.Core.Extensions
{
    public static class EntitySyncableExtensions
    {
        public static Guid CreateIdentifier(this IEntitySyncable entity) => Guid.NewGuid();
    }
}
