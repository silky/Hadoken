#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class TantalumElement : Element
    {
		public TantalumElement()
			: base(Tantalum, Ta, 73)
		{
		}

		public const string Ta = "Ta";
		public const string Tantalum = "Tantalum";
	}
}
