#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class RutheniumElement : Element
    {
		public RutheniumElement()
			: base(Ruthenium, Ru, 44)
		{
		}

		public const string Ru = "Ru";
		public const string Ruthenium = "Ruthenium";
	}
}
