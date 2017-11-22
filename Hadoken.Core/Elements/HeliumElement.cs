#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class HeliumElement : Element
    {
		public HeliumElement()
			: base(Helium, He, 2)
		{
		}

		public const string He = "He";
		public const string Helium = "Helium";
	}
}
