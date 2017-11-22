#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class HydrogenElement : Element
    {
		public HydrogenElement()
			: base(Hydrogen, H, 1)
		{
		}

		public const string H = "H";
		public const string Hydrogen = "Hydrogen";
	}
}
