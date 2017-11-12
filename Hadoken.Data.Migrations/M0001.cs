#region Using References

using System;

#endregion

namespace Hadoken.Data.Migrations
{
    [Migration(0001)]
    public class M0001 : Migration
    {
        public override void Apply()
        {
            //  Tables
            ExecuteResource("Public.Group.sql");
            ExecuteResource("Public.Element.sql");

            //  Data
            ExecuteResource("Groups.sql");
            ExecuteResource("Elements.sql");
        }
    }
}
