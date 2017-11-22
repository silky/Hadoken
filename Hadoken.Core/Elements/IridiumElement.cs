#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class IridiumElement : Element
    {
		public IridiumElement()
			: base(Iridium, Ir, 77)
		{
		}

		public const string Ir = "Ir";
		public const string Iridium = "Iridium";
	}
}
