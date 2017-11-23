#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class NobeliumElement : Element
    {
		public NobeliumElement()
			: base(Nobelium, No, 102)
		{
		}

		public const string No = "No";
		public const string Nobelium = "Nobelium";
	}
}
