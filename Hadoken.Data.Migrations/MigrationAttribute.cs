#region Using References

using System;

#endregion

namespace Hadoken.Data.Migrations
{
    public class MigrationAttribute : Attribute
    {
        public MigrationAttribute(int value)
        {
            _value = value;
        }

        public MigrationAttribute(int value, bool isIgnore)
            : this(value)
        {
            _isIgnore = isIgnore;
        }

        private readonly bool _isIgnore;
        private readonly int _value;

        public bool IsIgnore
        {
            get
            {
                return _isIgnore;
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
        }
    }
}
