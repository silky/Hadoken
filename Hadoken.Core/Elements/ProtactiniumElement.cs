#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ProtactiniumElement : Element
    {
		public ProtactiniumElement()
			: base(Protactinium, Pa, 91)
		{
		}

		public const string Pa = "Pa";
		public const string Protactinium = "Protactinium";
	}
}
