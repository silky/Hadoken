#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class MercuryElement : Element
    {
		public MercuryElement()
			: base(Mercury, Hg, 80)
		{
		}

		public const string Hg = "Hg";
		public const string Mercury = "Mercury";
	}
}
