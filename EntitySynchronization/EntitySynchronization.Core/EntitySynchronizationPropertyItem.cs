
namespace EntitySynchronization.Core
{
    public class EntitySynchronizationPropertyItem
    {
        private System.Guid _identifier;
        private object _value;
        private string _propertyName;

        public System.Guid Identifier
        {
            get { return _identifier; }
            set
            {
                if (value == null || value == System.Guid.Empty)
                    throw new System.ArgumentNullException("The identifier can not be null or emtpy");

                _identifier = value;
            }
        }

        public object Value
        {
            get { return _value; }
            set
            {
                _value = value ?? throw new System.ArgumentNullException("The value can not be null");
            }
        }
        
        public string PropertyName
        {
            get { return _propertyName; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("The property name can not be null, emtpy or whitespace");

                _propertyName = value;
            }
        }
    }
}
