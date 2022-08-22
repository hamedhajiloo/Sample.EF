using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.EF
{
    public static class EFExtension
    {
        //public static async Task<T> BulkCopy<T>()
        //{
        //    //using (SqlConnection connection = new(@"Server=.;Initial Catalog=SampleEfCore;Integrated Security=True;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=3000;App=Sample"))
        //    //{
        //    //    SqlBulkCopy bulkCopy = new(
        //    //        connection,
        //    //        SqlBulkCopyOptions.TableLock |
        //    //        SqlBulkCopyOptions.FireTriggers |
        //    //        SqlBulkCopyOptions.UseInternalTransaction,
        //    //        null
        //    //        )
        //    //    {
        //    //        DestinationTableName = "People"
        //    //    };
        //    //    connection.Open();
        //    //    bulkCopy.WriteToServer(dataTable);
        //    //    connection.Close();
        //    //}

        //    return await T;
        //}
    }
}
