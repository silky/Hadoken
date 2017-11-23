#region Using References

using System;

#endregion

namespace Hadoken.Data.Migrations
{
    public class DataPlatformAttribute : Attribute
    {
        public DataPlatformAttribute(DataPlatformType dataPlatformType)
        {
            _dataPlatformType = dataPlatformType;
        }

        private readonly DataPlatformType _dataPlatformType;

        public DataPlatformType DataPlatformType
        {
            get
            {
                return _dataPlatformType;
            }
        }
    }
}
