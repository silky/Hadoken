#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class RubidiumElement : Element
    {
		public RubidiumElement()
			: base(Rubidium, Rb, 37)
		{
		}

		public const string Rb = "Rb";
		public const string Rubidium = "Rubidium";
	}
}
