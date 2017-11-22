#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class PlutoniumElement : Element
    {
		public PlutoniumElement()
			: base(Plutonium, Pu, 94)
		{
		}

		public const string Pu = "Pu";
		public const string Plutonium = "Plutonium";
	}
}
