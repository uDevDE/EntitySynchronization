using System;
using System.Collections.Generic;

namespace EntitySynchronization.Core
{
    public class EntitySynchronizationPropertyItemCollection
    {
        public HashSet<EntitySynchronizationPropertyItem> EntitySynchronizationProperties { get; private set; }

        public EntitySynchronizationPropertyItemCollection()
        {
            EntitySynchronizationProperties = new HashSet<EntitySynchronizationPropertyItem>(new EntitySynchronizationPropertyItemComparer());
        }

        public bool Add(EntitySynchronizationPropertyItem entitySynchronizationPropertyItem) => 
            EntitySynchronizationProperties.Add(entitySynchronizationPropertyItem);
    }
}
