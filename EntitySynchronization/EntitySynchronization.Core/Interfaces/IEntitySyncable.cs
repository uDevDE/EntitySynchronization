
using EntitySynchronization.Core.Attributes;

namespace EntitySynchronization.Core.Interfaces
{
    public interface IEntitySyncable
    {
        [EntitySyncId]
        System.Guid Identifier { get; }
    }
}
