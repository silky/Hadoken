#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class VanadiumElement : Element
    {
		public VanadiumElement()
			: base(Vanadium, V, 23)
		{
		}

		public const string V = "V";
		public const string Vanadium = "Vanadium";
	}
}
