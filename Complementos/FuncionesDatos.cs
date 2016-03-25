using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Complementos
{
    public static class FuncionesDatos
    {
        //public DataTable EntityToDatatable(IQueryable Result, ObjectContext ctx)
        //{
        //    try
        //    {
        //        EntityConnection conn = ctx.Connection as EntityConnection;
        //        using (SqlConnection SQLCon = new SqlConnection(conn.StoreConnection.ConnectionString))
        //        {
        //            ObjectQuery query = Result as ObjectQuery;
        //            using (SqlCommand Cmd = new SqlCommand(query.ToTraceString(), SQLCon))
        //            {
        //                foreach (var param in query.Parameters)
        //                {
        //                    Cmd.Parameters.AddWithValue(param.Name, param.Value);
        //                }
        //                using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
        //                {
        //                    using (DataTable dt = new DataTable())
        //                    {
        //                        da.Fill(dt);
        //                        return dt;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        //{
        //    DataTable dtReturn = new DataTable();

        //    // column names 
        //    PropertyInfo[] oProps = null;

        //    if (varlist == null) return dtReturn;

        //    foreach (T rec in varlist)
        //    {
        //        // Use reflection to get property names, to create table, Only first time, others           will follow 
        //        if (oProps == null)
        //        {
        //            oProps = ((Type)rec.GetType()).GetProperties();
        //            foreach (PropertyInfo pi in oProps)
        //            {
        //                Type colType = pi.PropertyType;

        //                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
        //                == typeof(Nullable<>)))
        //                {
        //                    colType = colType.GetGenericArguments()[0];
        //                }

        //                dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
        //            }
        //        }

        //        DataRow dr = dtReturn.NewRow();

        //        foreach (PropertyInfo pi in oProps)
        //        {
        //            dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
        //            (rec, null);
        //        }

        //        dtReturn.Rows.Add(dr);
        //    }
        //    return dtReturn;
        //}


    }
}
