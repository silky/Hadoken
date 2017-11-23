#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class LawrenciumElement : Element
    {
		public LawrenciumElement()
			: base(Lawrencium, Lr, 103)
		{
		}

		public const string Lr = "Lr";
		public const string Lawrencium = "Lawrencium";
	}
}
