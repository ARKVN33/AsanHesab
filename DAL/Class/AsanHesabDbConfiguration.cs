using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
namespace DAL.Class
{
    public class AsanHesabDbConfiguration
    {
        private readonly string _directoryPath = Path.Combine(Globals.MyAppData,@"DATABASE");
        public void Configurate()
        {
            if (!Directory.Exists(_directoryPath))
            {
                System.Diagnostics.Process.Start("CMD.exe", "/C \"C:/Program Files/Microsoft SQL Server/120/Tools/Binn/SqlLocalDB.exe\" create v12.0 12.0 -s");
                try
                {
                    Directory.CreateDirectory(_directoryPath);
                }
                catch
                {
                    return;
                }
            }
            var dbName = _directoryPath + @"\dbAsanHesab.mdf";
            var dbLog = _directoryPath + @"\dbAsanHesab_LOG.ldf";
            var cn = new SqlConnection(@"Data Source = (LocalDb)\v12.0; DataBase = master");

            var da = new SqlDataAdapter("sp_databases", cn);
            var dt = new DataTable();

            var exists = false;
            try
            {
                da.Fill(dt);
                if (dt.Rows.Cast<DataRow>().Any(item => item["DATABASE_NAME"].ToString() == "dbAsanHesab"))
                    exists = true;

                if (exists) return;

                //Execute DB Script'
                var scriptFileName = Directory.GetCurrentDirectory() + @"\LocalDBScript.sql";
                var reader = new StreamReader(scriptFileName);
                var cmd = reader.ReadToEnd();
                cmd = cmd.Replace(":)Database_Name(:", dbName);
                cmd = cmd.Replace(":)Database_Log(:", dbLog);
                cmd = cmd.Replace("\r\n", " ");
                var commands = cmd.Split('ƒ');
                cn.Open();
                foreach (var command in commands)
                {
                    var cm = new SqlCommand(command, cn);
                    cm.ExecuteNonQuery();
                }
            }
            catch
            {
                //ignore
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
                cn.Dispose();
            }
            if (!File.Exists(_directoryPath + @"\dbAsanHesab.mdf"))
            {
                Directory.Delete(_directoryPath);
                Directory.Delete(Globals.MyAppData);
            }

        }
    }
}
