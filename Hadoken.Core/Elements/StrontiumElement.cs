#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class StrontiumElement : Element
    {
		public StrontiumElement()
			: base(Strontium, Sr, 38)
		{
		}

		public const string Sr = "Sr";
		public const string Strontium = "Strontium";
	}
}
