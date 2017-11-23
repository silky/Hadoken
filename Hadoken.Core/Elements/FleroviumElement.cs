#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class FleroviumElement : Element
    {
		public FleroviumElement()
			: base(Flerovium, Fl, 114)
		{
		}

		public const string Fl = "Fl";
		public const string Flerovium = "Flerovium";
	}
}
