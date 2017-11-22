#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class SiliconElement : Element
    {
		public SiliconElement()
			: base(Silicon, Si, 14)
		{
		}

		public const string Si = "Si";
		public const string Silicon = "Silicon";
	}
}
