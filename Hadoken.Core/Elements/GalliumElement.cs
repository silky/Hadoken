#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class GalliumElement : Element
    {
		public GalliumElement()
			: base(Gallium, Ga, 31)
		{
		}

		public const string Ga = "Ga";
		public const string Gallium = "Gallium";
	}
}
