#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class CaesiumElement : Element
    {
		public CaesiumElement()
			: base(Caesium, Cs, 55)
		{
		}

		public const string Cs = "Cs";
		public const string Caesium = "Caesium";
	}
}
