#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class BohriumElement : Element
    {
		public BohriumElement()
			: base(Bohrium, Bh, 107)
		{
		}

		public const string Bh = "Bh";
		public const string Bohrium = "Bohrium";
	}
}
