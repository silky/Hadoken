#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class CuriumElement : Element
    {
		public CuriumElement()
			: base(Curium, Cm, 96)
		{
		}

		public const string Cm = "Cm";
		public const string Curium = "Curium";
	}
}
