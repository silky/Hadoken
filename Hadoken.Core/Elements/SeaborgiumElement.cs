#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class SeaborgiumElement : Element
    {
		public SeaborgiumElement()
			: base(Seaborgium, Sg, 106)
		{
		}

		public const string Sg = "Sg";
		public const string Seaborgium = "Seaborgium";
	}
}
