#region Using References

using System;

#endregion

namespace Hadoken.Data.Deployer
{
    internal class CommandLinePart
    {
        public CommandLinePart(string key)
        {
            _key = key;
        }

        public CommandLinePart(string key, string value)
            : this(key)
        {
            _value = value;
        }

        private readonly string _key = "";
        private readonly string _value = "";

        public string Key
        {
            get
            {
                return _key;
            }
        }

        public string Value
        {
            get
            {
                return _value;
            }
        }

        public override string ToString()
        {
            return $"{_key} = \"{_value}\"";
        }
    }
}
