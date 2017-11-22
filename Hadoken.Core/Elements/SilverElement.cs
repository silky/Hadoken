#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class SilverElement : Element
    {
		public SilverElement()
			: base(Silver, Ag, 47)
		{
		}

		public const string Ag = "Ag";
		public const string Silver = "Silver";
	}
}
