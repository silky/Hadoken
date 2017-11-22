#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class UraniumElement : Element
    {
		public UraniumElement()
			: base(Uranium, U, 92)
		{
		}

		public const string U = "U";
		public const string Uranium = "Uranium";
	}
}
