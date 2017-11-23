#region Using References

using System;

#endregion

namespace Hadoken.Data.Migrations
{
    [Migration(0001)]
    [DataPlatform(DataPlatformType.Sql)]
    public class M0001 : Migration
    {
        public override void Apply(DataPlatformType dataPlatformType)
        {
            //  Tables
            ExecuteResource(dataPlatformType, "dbo.Group.sql");
            ExecuteResource(dataPlatformType, "dbo.Element.sql");

            //  Functions
            ExecuteResource(dataPlatformType, "dbo.spGetElement.sql");
            
            //  Data
            ExecuteResource(dataPlatformType, "Groups.sql");
            ExecuteResource(dataPlatformType, "Elements.sql");
        }
    }
}
