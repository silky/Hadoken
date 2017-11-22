#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class NitrogenElement : Element
    {
		public NitrogenElement()
			: base(Nitrogen, N, 7)
		{
		}

		public const string N = "N";
		public const string Nitrogen = "Nitrogen";
	}
}
