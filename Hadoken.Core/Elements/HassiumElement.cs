#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class HassiumElement : Element
    {
		public HassiumElement()
			: base(Hassium, Hs, 108)
		{
		}

		public const string Hs = "Hs";
		public const string Hassium = "Hassium";
	}
}
