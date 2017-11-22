#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class FluorineElement : Element
    {
		public FluorineElement()
			: base(Fluorine, F, 9)
		{
		}

		public const string F = "F";
		public const string Fluorine = "Fluorine";
	}
}
