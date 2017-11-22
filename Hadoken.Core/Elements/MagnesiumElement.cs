#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class MagnesiumElement : Element
    {
		public MagnesiumElement()
			: base(Magnesium, Mg, 12)
		{
		}

		public const string Mg = "Mg";
		public const string Magnesium = "Magnesium";
	}
}
