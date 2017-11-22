#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ChlorineElement : Element
    {
		public ChlorineElement()
			: base(Chlorine, Cl, 17)
		{
		}

		public const string Cl = "Cl";
		public const string Chlorine = "Chlorine";
	}
}
