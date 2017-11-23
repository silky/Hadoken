#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class CoperniciumElement : Element
    {
		public CoperniciumElement()
			: base(Copernicium, Cn, 112)
		{
		}

		public const string Cn = "Cn";
		public const string Copernicium = "Copernicium";
	}
}
