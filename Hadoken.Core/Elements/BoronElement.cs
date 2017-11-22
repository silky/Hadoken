#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class BoronElement : Element
    {
		public BoronElement()
			: base(Boron, B, 5)
		{
		}

		public const string B = "B";
		public const string Boron = "Boron";
	}
}
