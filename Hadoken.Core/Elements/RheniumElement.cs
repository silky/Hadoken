#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class RheniumElement : Element
    {
		public RheniumElement()
			: base(Rhenium, Re, 75)
		{
		}

		public const string Re = "Re";
		public const string Rhenium = "Rhenium";
	}
}
