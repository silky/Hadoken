#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class DysprosiumElement : Element
    {
		public DysprosiumElement()
			: base(Dysprosium, Dy, 66)
		{
		}

		public const string Dy = "Dy";
		public const string Dysprosium = "Dysprosium";
	}
}
