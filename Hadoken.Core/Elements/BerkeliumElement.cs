#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class BerkeliumElement : Element
    {
		public BerkeliumElement()
			: base(Berkelium, Bk, 97)
		{
		}

		public const string Bk = "Bk";
		public const string Berkelium = "Berkelium";
	}
}
