#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class MoscoviumElement : Element
    {
		public MoscoviumElement()
			: base(Moscovium, Mc, 115)
		{
		}

		public const string Mc = "Mc";
		public const string Moscovium = "Moscovium";
	}
}
