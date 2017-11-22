#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class GadoliniumElement : Element
    {
		public GadoliniumElement()
			: base(Gadolinium, Gd, 64)
		{
		}

		public const string Gd = "Gd";
		public const string Gadolinium = "Gadolinium";
	}
}
