#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class NeptuniumElement : Element
    {
		public NeptuniumElement()
			: base(Neptunium, Np, 93)
		{
		}

		public const string Np = "Np";
		public const string Neptunium = "Neptunium";
	}
}
