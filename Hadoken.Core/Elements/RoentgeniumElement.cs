#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class RoentgeniumElement : Element
    {
		public RoentgeniumElement()
			: base(Roentgenium, Rg, 111)
		{
		}

		public const string Rg = "Rg";
		public const string Roentgenium = "Roentgenium";
	}
}
