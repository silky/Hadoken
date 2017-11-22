#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ThalliumElement : Element
    {
		public ThalliumElement()
			: base(Thallium, Tl, 81)
		{
		}

		public const string Tl = "Tl";
		public const string Thallium = "Thallium";
	}
}
