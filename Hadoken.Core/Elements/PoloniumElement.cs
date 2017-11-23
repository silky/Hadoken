#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class PoloniumElement : Element
    {
		public PoloniumElement()
			: base(Polonium, Po, 84)
		{
		}

		public const string Po = "Po";
		public const string Polonium = "Polonium";
	}
}
