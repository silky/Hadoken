#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class LeadElement : Element
    {
		public LeadElement()
			: base(Lead, Pb, 82)
		{
		}

		public const string Pb = "Pb";
		public const string Lead = "Lead";
	}
}
