#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class SeleniumElement : Element
    {
		public SeleniumElement()
			: base(Selenium, Se, 34)
		{
		}

		public const string Se = "Se";
		public const string Selenium = "Selenium";
	}
}
