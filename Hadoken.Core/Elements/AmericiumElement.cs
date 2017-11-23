#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class AmericiumElement : Element
    {
		public AmericiumElement()
			: base(Americium, Am, 95)
		{
		}

		public const string Am = "Am";
		public const string Americium = "Americium";
	}
}
