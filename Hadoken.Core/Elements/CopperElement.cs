#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class CopperElement : Element
    {
		public CopperElement()
			: base(Copper, Cu, 29)
		{
		}

		public const string Cu = "Cu";
		public const string Copper = "Copper";
	}
}
