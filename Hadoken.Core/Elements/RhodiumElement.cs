#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class RhodiumElement : Element
    {
		public RhodiumElement()
			: base(Rhodium, Rh, 45)
		{
		}

		public const string Rh = "Rh";
		public const string Rhodium = "Rhodium";
	}
}
