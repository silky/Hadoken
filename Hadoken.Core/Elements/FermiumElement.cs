#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class FermiumElement : Element
    {
		public FermiumElement()
			: base(Fermium, Fm, 100)
		{
		}

		public const string Fm = "Fm";
		public const string Fermium = "Fermium";
	}
}
