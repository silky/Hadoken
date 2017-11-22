#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ThuliumElement : Element
    {
		public ThuliumElement()
			: base(Thulium, Tm, 69)
		{
		}

		public const string Tm = "Tm";
		public const string Thulium = "Thulium";
	}
}
