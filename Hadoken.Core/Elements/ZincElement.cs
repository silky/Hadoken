#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ZincElement : Element
    {
		public ZincElement()
			: base(Zinc, Zn, 30)
		{
		}

		public const string Zn = "Zn";
		public const string Zinc = "Zinc";
	}
}
