using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APSmartHome.DataAccess.LocalDevice
{
    internal class GlobalSettingContext : BaseDataBase
    {
        public GlobalSettingContext(string dbPath, string keyDB) : base(dbPath, keyDB)
        {
            database.CreateTableAsync<Models.GlobalSetting>().Wait();
        }

        public Task<List<Models.GlobalSetting>> GetGlobalSettingAsync()
        {
            return database.Table<Models.GlobalSetting>().ToListAsync();
        }
        public async Task<long> SaveGlobalSettingAsync(Models.GlobalSetting item)
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
        public Task<int> DeleteLocalPinSettingsAsync(Models.GlobalSetting item)
        {
            return database.DeleteAsync(item);
        }
    }
}
