#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class TitaniumElement : Element
    {
		public TitaniumElement()
			: base(Titanium, Ti, 22)
		{
		}

		public const string Ti = "Ti";
		public const string Titanium = "Titanium";
	}
}
