#region Using References

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Hadoken.Core.Elements;

#endregion

namespace Hadoken.Data
{
    public class ElementRepository : Repository
    {
        private const string spGetElement = "dbo.spGetElement"; //  "public.spgetelement";

        public List<Element> SelectElements()
        {
            List<Element> selectElements = new List<Element>();

            using (DbConnection dbConnection = ConnectionFactory.NewDbConnection())
            {
                using (DbCommand dbCommand = CommandFactory.NewStoredProcedureCommand(dbConnection, spGetElement))
                {
                    using (IDataReader dataReader = dbCommand.ExecuteReader())
                    {
                        while (dataReader.Read() == true)
                        {
                            selectElements.Add(new Element
                            (
                                Convert.ToInt32(dataReader["atomicnumber"]),
                                Convert.ToInt32(dataReader["atomicweight"]),
                                Convert.ToDateTime(dataReader["datecreatedutc"]),
                                Convert.ToDateTime(dataReader["dateupdatedutc"]),
                                Convert.ToDouble(dataReader["density"]),
                                ToNullableInt32(dataReader["groupid"]),
                                Convert.ToInt32(dataReader["id"]),
                                dataReader["name"].ToString(),
                                Convert.ToInt32(dataReader["period"]),
                                dataReader["symbol"].ToString()
                            ));
                        }
                    }
                }
            }

            return selectElements;
        }
    }
}
