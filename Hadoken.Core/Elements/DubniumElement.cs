#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class DubniumElement : Element
    {
		public DubniumElement()
			: base(Dubnium, Db, 105)
		{
		}

		public const string Db = "Db";
		public const string Dubnium = "Dubnium";
	}
}
