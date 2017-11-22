#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class TinElement : Element
    {
		public TinElement()
			: base(Tin, Sn, 50)
		{
		}

		public const string Sn = "Sn";
		public const string Tin = "Tin";
	}
}
