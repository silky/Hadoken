#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class IndiumElement : Element
    {
		public IndiumElement()
			: base(Indium, In, 49)
		{
		}

		public const string In = "In";
		public const string Indium = "Indium";
	}
}
