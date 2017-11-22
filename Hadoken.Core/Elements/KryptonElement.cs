#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class KryptonElement : Element
    {
		public KryptonElement()
			: base(Krypton, Kr, 36)
		{
		}

		public const string Kr = "Kr";
		public const string Krypton = "Krypton";
	}
}
