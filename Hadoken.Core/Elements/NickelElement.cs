#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class NickelElement : Element
    {
		public NickelElement()
			: base(Nickel, Ni, 28)
		{
		}

		public const string Ni = "Ni";
		public const string Nickel = "Nickel";
	}
}
