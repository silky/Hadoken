#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ChromiumElement : Element
    {
		public ChromiumElement()
			: base(Chromium, Cr, 24)
		{
		}

		public const string Cr = "Cr";
		public const string Chromium = "Chromium";
	}
}
