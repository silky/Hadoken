#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class NiobiumElement : Element
    {
		public NiobiumElement()
			: base(Niobium, Nb, 41)
		{
		}

		public const string Nb = "Nb";
		public const string Niobium = "Niobium";
	}
}
