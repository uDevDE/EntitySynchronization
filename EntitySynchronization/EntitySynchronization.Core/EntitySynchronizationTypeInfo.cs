using System;
using System.Collections.Generic;

namespace EntitySynchronization.Core
{
    public class EntitySynchronizationTypeInfo
    {
        public HashSet<Guid> Identifiers { get; private set; }
        public HashSet<Type> Types { get; private set; }

        public EntitySynchronizationTypeInfo()
        {
            Identifiers = new HashSet<Guid>();
            Types = new HashSet<Type>();
        }

        public bool Add(Guid identifier) => Identifiers.Add(identifier);
        public bool Add(Type type) => Types.Add(type);
        public bool Remove(Guid identifier) => Identifiers.Remove(identifier);
        public bool Remove(Type type) => Types.Remove(type);
    }
}
