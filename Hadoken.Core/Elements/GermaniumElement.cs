#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class GermaniumElement : Element
    {
		public GermaniumElement()
			: base(Germanium, Ge, 32)
		{
		}

		public const string Ge = "Ge";
		public const string Germanium = "Germanium";
	}
}
