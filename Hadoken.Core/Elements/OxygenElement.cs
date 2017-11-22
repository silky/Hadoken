#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class OxygenElement : Element
    {
		public OxygenElement()
			: base(Oxygen, O, 8)
		{
		}

		public const string O = "O";
		public const string Oxygen = "Oxygen";
	}
}
