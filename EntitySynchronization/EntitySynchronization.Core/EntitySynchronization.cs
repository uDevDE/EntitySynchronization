using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using EntitySynchronization.Core.Helpers;

namespace EntitySynchronization.Core
{
    public static class EntitySynchronization
    {
        public delegate void ErrorHandler(string errMsg, Exception ex);
        public static event ErrorHandler Error;

        public static bool Initialized = false;
        public static Dictionary<Type, EntitySynchronizationTypeInfo> EntityTypes { get; private set; }
        private static Dictionary<Type, EntitySynchronizationPropertyItemCollection> entitySyncProperties;

        public static Task Init()
        {
            return Task.Run(() => 
            {
                try
                {
                    var assemblyTypes = EntitySynchronizationHelper.GetClassesWithEntityInterface(AppDomain.CurrentDomain.GetAssemblies());
                    EntityTypes = FindSubClassesWithEntityInterface(assemblyTypes);
                    entitySyncProperties = new Dictionary<Type, EntitySynchronizationPropertyItemCollection>();

                    Initialized = EntityTypes != null ? true : false;
                }
                catch (Exception ex)
                {
                    Error?.Invoke("Can not initialize EntitySynchronization framework", ex);
                }
            });          
        }


        /// <summary>
        /// Finds all classes that assigns the IEntitySyncable interface
        /// </summary>
        /// <param name="assemblyTypes"></param>
        /// <returns></returns>
        private static Dictionary<Type, EntitySynchronizationTypeInfo> FindSubClassesWithEntityInterface(IEnumerable<Type> assemblyTypes)
        {
            var dictionary = new Dictionary<Type, EntitySynchronizationTypeInfo>();
            try
            {
                foreach (var type in assemblyTypes)
                {
                    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    var entityProps = EntitySynchronizationHelper.GetSubClassesWithEntityInterface(properties);

                    foreach (var property in entityProps)
                    {
                        var propertyType = property.PropertyType;
                        if (!dictionary.ContainsKey(propertyType))
                        {
                            var entitySynchronizationTypeInfo = new EntitySynchronizationTypeInfo();
                            entitySynchronizationTypeInfo.Add(propertyType);
                            dictionary.Add(type, entitySynchronizationTypeInfo);
                        }
                        else
                        {
                            if (dictionary.TryGetValue(type, out EntitySynchronizationTypeInfo entitySynchronizationTypeInfo))
                            {
                                entitySynchronizationTypeInfo.Add(propertyType);
                            }
                        }
                    }
                }
                return dictionary;
            }
            catch (Exception ex)
            {
                Error?.Invoke("Can not find sub classes that assigns the IEntitySyncable interface", ex);
                return null;
            }
        }


    }
}
