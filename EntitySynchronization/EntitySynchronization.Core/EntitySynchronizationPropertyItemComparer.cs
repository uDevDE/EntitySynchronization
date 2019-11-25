using System.Collections.Generic;

namespace EntitySynchronization.Core
{
    public class EntitySynchronizationPropertyItemComparer : IEqualityComparer<EntitySynchronizationPropertyItem>
    {
        public bool Equals(EntitySynchronizationPropertyItem x, EntitySynchronizationPropertyItem y) => x.Identifier == y.Identifier;
        public int GetHashCode(EntitySynchronizationPropertyItem obj) => obj.Identifier.GetHashCode();
    }
}
