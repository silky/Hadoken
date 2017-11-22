#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ArsenicElement : Element
    {
		public ArsenicElement()
			: base(Arsenic, As, 33)
		{
		}

		public const string As = "As";
		public const string Arsenic = "Arsenic";
	}
}
