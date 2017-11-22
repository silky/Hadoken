#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ArgonElement : Element
    {
		public ArgonElement()
			: base(Argon, Ar, 18)
		{
		}

		public const string Ar = "Ar";
		public const string Argon = "Argon";
	}
}
