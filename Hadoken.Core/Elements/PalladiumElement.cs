#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class PalladiumElement : Element
    {
		public PalladiumElement()
			: base(Palladium, Pd, 46)
		{
		}

		public const string Pd = "Pd";
		public const string Palladium = "Palladium";
	}
}
