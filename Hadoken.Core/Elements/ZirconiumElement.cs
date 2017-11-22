#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ZirconiumElement : Element
    {
		public ZirconiumElement()
			: base(Zirconium, Zr, 40)
		{
		}

		public const string Zr = "Zr";
		public const string Zirconium = "Zirconium";
	}
}
