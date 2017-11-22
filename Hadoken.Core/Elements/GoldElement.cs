#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class GoldElement : Element
    {
		public GoldElement()
			: base(Gold, Au, 79)
		{
		}

		public const string Au = "Au";
		public const string Gold = "Gold";
	}
}
