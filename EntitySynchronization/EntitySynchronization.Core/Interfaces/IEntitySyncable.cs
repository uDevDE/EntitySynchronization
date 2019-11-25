
using EntitySynchronization.Core.Attributes;

namespace EntitySynchronization.Core.Interfaces
{
    public interface IEntitySyncable
    {
        [EntitySyncId]
        System.Guid Id { get; }

        void OnEntityPropertyChanged<T>(T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null);
    }
}
