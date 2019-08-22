using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FSMChildVersion.Repository.DomainModels;
using SQLite;

namespace FSMChildVersion.Repository.SQLite
{
    public class SQLiteSetup : ISQLiteSetup
    {
        #region Local DB Setup
        private readonly SQLiteAsyncConnection dBConnection;
        public SQLiteSetup()
        {
            dBConnection = new SQLiteAsyncConnection(Config.LocalDBFile);
            LocalDB();
        }
        public SQLiteAsyncConnection GetDBConnection() { return dBConnection; }
        #endregion

        #region Setup
        private void SetUpLocalDatabase()
        {
            if (IsDbExists())
            {
                return;
            }

            Task<CreateTableResult> tableResult = dBConnection.CreateTableAsync<MakeUp>();
            while (!tableResult.IsCompleted)
                ;
        }
        private bool IsDbExists()
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
        private static void StopSyncService()
        {
            //BackgroundAggregatorService.StopBackgroundService();
        }
        private static void StartSyncService()
        {
            //BackgroundAggregatorService.StartBackgroundService();
        }
        #endregion
    }
    public class SQLiteDatabase
    {
        private static Lazy<ISQLiteSetup> instance = new Lazy<ISQLiteSetup>(() => new SQLiteSetup(), System.Threading.LazyThreadSafetyMode.PublicationOnly);
        public static ISQLiteSetup Instance
        {
            get
            {
                ISQLiteSetup ret = instance.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }
        internal static Exception NotImplementedInReferenceAssembly() => new NotImplementedException("Functionality is not implemented.");
    }
}
