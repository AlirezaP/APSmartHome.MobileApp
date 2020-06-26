using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSmartHome.DataAccess.LocalDevice
{
    internal class LocalPinSettingsContext : BaseDataBase
    {
        public LocalPinSettingsContext(string dbPath, string keyDB) : base(dbPath, keyDB)
        {
            database.CreateTableAsync<Models.LocalPinSettings>().Wait();
        }

        public Task<List<Models.LocalPinSettings>> GetDevicesInfoListAsync()
        {
            return database.Table<Models.LocalPinSettings>().ToListAsync();
        }
        public async Task<long> SaveLocalPinSettingsAsync(Models.LocalPinSettings item)
        {
    
            if (item.ID != 0)
            {
                return await database.UpdateAsync(item);
            }
            else
            {
                var r1 = await database.InsertAsync(item);
                if (r1 != 0)
                {
                    string sql = @"select last_insert_rowid()";
                    long lastId = (long)(await database.ExecuteScalarAsync<long>(sql));
                    return lastId;
                }
                else
                {
                    return 0;
                }

            }
        }
        public Task<int> DeleteLocalPinSettingsAsync(Models.LocalPinSettings item)
        {
            return database.DeleteAsync(item);
        }
    }
}
