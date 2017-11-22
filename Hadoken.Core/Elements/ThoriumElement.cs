#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ThoriumElement : Element
    {
		public ThoriumElement()
			: base(Thorium, Th, 90)
		{
		}

		public const string Th = "Th";
		public const string Thorium = "Thorium";
	}
}
