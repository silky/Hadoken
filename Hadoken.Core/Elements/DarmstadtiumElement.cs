#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class DarmstadtiumElement : Element
    {
		public DarmstadtiumElement()
			: base(Darmstadtium, Ds, 110)
		{
		}

		public const string Ds = "Ds";
		public const string Darmstadtium = "Darmstadtium";
	}
}
