#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class XenonElement : Element
    {
		public XenonElement()
			: base(Xenon, Xe, 54)
		{
		}

		public const string Xe = "Xe";
		public const string Xenon = "Xenon";
	}
}
