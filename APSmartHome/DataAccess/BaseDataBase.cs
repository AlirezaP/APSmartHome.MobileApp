using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace APSmartHome.DataAccess
{
    public class BaseDataBase
    {
        protected SQLiteAsyncConnection database;
        public BaseDataBase(string dbPath, string keyDB)
        {
            //database = new SQLiteAsyncConnection(dbPath, key: keyDB);
            database = new SQLiteAsyncConnection(dbPath);
        }
    }
}
