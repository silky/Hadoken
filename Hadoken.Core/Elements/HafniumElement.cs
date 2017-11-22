#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class HafniumElement : Element
    {
		public HafniumElement()
			: base(Hafnium, Hf, 72)
		{
		}

		public const string Hf = "Hf";
		public const string Hafnium = "Hafnium";
	}
}
