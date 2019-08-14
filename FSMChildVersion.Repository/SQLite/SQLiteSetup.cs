using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FSMChildVersion.Repository.DomainModels;
using SQLite;

namespace FSMChildVersion.Repository.SQLite
{
    public class SQLiteSetup
    {
        #region Local DB Setup
        private readonly SQLiteAsyncConnection dBConnection;

        public SQLiteSetup()
        {
            dBConnection = new SQLiteAsyncConnection(Config.LocalDBFile);
            LocalDB();
        }
        public void SetUpLocalDatabase()
        {
            //if (IsDbExists())
            //{
            //    return;
            //}

            Task<CreateTableResult> tableResult = dBConnection.CreateTableAsync<MakeUp>();
            while (!(tableResult.IsCompleted))
            {
                ;
            }

        }
        public bool IsDbExists()
        {
            try
            {
                if (!File.Exists(Config.LocalDBFile))
                    return false;

                List<SQLiteConnection.ColumnInfo> MakeUp = dBConnection.GetTableInfoAsync("MakeUp").Result;
                return MakeUp.Count != 0;
            }
            catch
            {
                return false;
            }
        }
        private void LocalDB()
        {
            SetUpLocalDatabase();
            StartSyncService();
        }
        public static void StopSyncService()
        {
            //BackgroundAggregatorService.StopBackgroundService();
        }
        public static void StartSyncService()
        {
            //BackgroundAggregatorService.StartBackgroundService();
        }
        #endregion
    }
}
