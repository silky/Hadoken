#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class CobaltElement : Element
    {
		public CobaltElement()
			: base(Cobalt, Co, 27)
		{
		}

		public const string Co = "Co";
		public const string Cobalt = "Cobalt";
	}
}
