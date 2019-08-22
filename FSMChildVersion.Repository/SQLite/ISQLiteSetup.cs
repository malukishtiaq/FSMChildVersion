using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FSMChildVersion.Repository.SQLite
{
    public interface ISQLiteSetup
    {
        SQLiteAsyncConnection GetDBConnection();
    }
}
