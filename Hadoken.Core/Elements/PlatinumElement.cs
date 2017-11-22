#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class PlatinumElement : Element
    {
		public PlatinumElement()
			: base(Platinum, Pt, 78)
		{
		}

		public const string Pt = "Pt";
		public const string Platinum = "Platinum";
	}
}
