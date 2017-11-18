#region Using References

using System;
using System.Data;
using System.Data.Common;

#endregion

namespace Hadoken.Data
{
    public class Repository
    {
        protected int? ToNullableInt32(object value)
        {
            int? toNullableInt32 = null;

            if ((value != null) && (value != DBNull.Value))
            {
                toNullableInt32 = Convert.ToInt32(value);
            }

            return toNullableInt32;
        }
    }
}
