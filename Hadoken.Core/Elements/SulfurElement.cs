#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class SulfurElement : Element
    {
		public SulfurElement()
			: base(Sulfur, S, 16)
		{
		}

		public const string S = "S";
		public const string Sulfur = "Sulfur";
	}
}
