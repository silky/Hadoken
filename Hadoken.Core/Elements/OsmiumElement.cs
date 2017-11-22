#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class OsmiumElement : Element
    {
		public OsmiumElement()
			: base(Osmium, Os, 76)
		{
		}

		public const string Os = "Os";
		public const string Osmium = "Osmium";
	}
}
