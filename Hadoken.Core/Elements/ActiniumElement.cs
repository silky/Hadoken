#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class ActiniumElement : Element
    {
		public ActiniumElement()
			: base(Actinium, Ac, 89)
		{
		}

		public const string Ac = "Ac";
		public const string Actinium = "Actinium";
	}
}
