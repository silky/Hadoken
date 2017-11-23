#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class CaliforniumElement : Element
    {
		public CaliforniumElement()
			: base(Californium, Cf, 98)
		{
		}

		public const string Cf = "Cf";
		public const string Californium = "Californium";
	}
}
