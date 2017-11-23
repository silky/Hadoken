#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class RadonElement : Element
    {
		public RadonElement()
			: base(Radon, Rn, 86)
		{
		}

		public const string Rn = "Rn";
		public const string Radon = "Radon";
	}
}
