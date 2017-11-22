#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class AluminiumElement : Element
    {
		public AluminiumElement()
			: base(Aluminium, Al, 13)
		{
		}

		public const string Al = "Al";
		public const string Aluminium = "Aluminium";
	}
}
