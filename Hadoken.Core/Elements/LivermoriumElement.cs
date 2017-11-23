#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class LivermoriumElement : Element
    {
		public LivermoriumElement()
			: base(Livermorium, Lv, 116)
		{
		}

		public const string Lv = "Lv";
		public const string Livermorium = "Livermorium";
	}
}
