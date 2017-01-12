#load "./fdata.csx"

#r "System.Configuration"
#r "System.Data"

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public static void Run(string myQueueItem, TraceWriter log)
{
    log.Info($"Processing entry: {myQueueItem}");
    
    try
    {
        var data = new fdata(myQueueItem);

        if(data.Save())
        {
            var cs = ConfigurationManager.ConnectionStrings["function_sql"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("DATA_VALUES_SET", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@P_TRANSFERID", SqlDbType.UniqueIdentifier).Value = data.TransferID;
                    cmd.Parameters.Add("@P_Fondsname", SqlDbType.VarChar).Value = data.Fondsname;
                    cmd.Parameters.Add("@P_ISIN", SqlDbType.VarChar).Value = data.ISIN;
                    cmd.Parameters.Add("@P_WKN", SqlDbType.VarChar).Value = data.WKN;
                    cmd.Parameters.Add("@P_Gesellschaft", SqlDbType.VarChar).Value = data.Gesellschaft;
                    cmd.Parameters.Add("@P_MindestanlageErst", SqlDbType.Decimal).Value = data.MindestanlageErst;
                    cmd.Parameters.Add("@P_GrundlageVPH", SqlDbType.Decimal).Value = data.GrundlageVPH;
                    cmd.Parameters.Add("@P_VP", SqlDbType.Decimal).Value = data.VP;
                    cmd.Parameters.Add("@P_VPh", SqlDbType.Decimal).Value = data.VPh;
                    cmd.Parameters.Add("@P_Formel_VPh", SqlDbType.VarChar).Value = data.Formel_VPh;
                    cmd.Parameters.Add("@P_AGAG_fremd", SqlDbType.Decimal).Value = data.AGAG_fremd;
                    cmd.Parameters.Add("@P_SchlusstagsabweichungKauf", SqlDbType.Int).Value = data.SchlusstagsabweichungKauf;
                    cmd.Parameters.Add("@P_SchlusstagsabweichungVerkauf", SqlDbType.Int).Value = data.SchlusstagsabweichungVerkauf;
                    cmd.Parameters.Add("@P_sparplanfaehig", SqlDbType.VarChar).Value = data.sparplanfaehig;
                    cmd.Parameters.Add("@P_Mindestfolgeanlage", SqlDbType.Decimal).Value = data.Mindestfolgeanlage;
                    cmd.Parameters.Add("@P_Mindestsparplanrate", SqlDbType.Decimal).Value = data.Mindestsparplanrate;
                    cmd.Parameters.Add("@P_Kaufsperre", SqlDbType.VarChar).Value = data.Kaufsperre;
                    cmd.Parameters.Add("@P_Verkaufsperre", SqlDbType.VarChar).Value = data.Verkaufsperre;
                    cmd.Parameters.Add("@P_Waehrung", SqlDbType.VarChar).Value = data.Waehrung;
                    cmd.Parameters.Add("@P_Fondsart", SqlDbType.VarChar).Value = data.Fondsart;
                    cmd.Parameters.Add("@P_Transaktionskosten_Kauf", SqlDbType.Decimal).Value = data.Transaktionskosten_Kauf;
                    cmd.Parameters.Add("@P_Transaktionskosten_Verkauf", SqlDbType.Decimal).Value = data.Transaktionskosten_Verkauf;
                    cmd.Parameters.Add("@P_ETF", SqlDbType.VarChar).Value = data.ETF;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
             }
        }
        else
        {
            log.Info($"Mapping failed: {myQueueItem}");
        }
    }
    catch(Exception ex)
    {
        log.Error($"Error occured: {ex.Message}");
    }
}
