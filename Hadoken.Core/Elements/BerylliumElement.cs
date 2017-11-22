#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class BerylliumElement : Element
    {
		public BerylliumElement()
			: base(Beryllium, Be, 4)
		{
		}

		public const string Be = "Be";
		public const string Beryllium = "Beryllium";
	}
}
