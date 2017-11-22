#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class BariumElement : Element
    {
		public BariumElement()
			: base(Barium, Ba, 56)
		{
		}

		public const string Ba = "Ba";
		public const string Barium = "Barium";
	}
}
