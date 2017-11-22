#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class SamariumElement : Element
    {
		public SamariumElement()
			: base(Samarium, Sm, 62)
		{
		}

		public const string Sm = "Sm";
		public const string Samarium = "Samarium";
	}
}
