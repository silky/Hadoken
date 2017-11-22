#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class MolybdenumElement : Element
    {
		public MolybdenumElement()
			: base(Molybdenum, Mo, 42)
		{
		}

		public const string Mo = "Mo";
		public const string Molybdenum = "Molybdenum";
	}
}
