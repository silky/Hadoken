#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class CarbonElement : Element
    {
		public CarbonElement()
			: base(Carbon, C, 6)
		{
		}

		public const string C = "C";
		public const string Carbon = "Carbon";
	}
}
