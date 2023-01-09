using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProiectMAUIHairsalon.Models;

namespace ProiectMAUIHairsalon.Data
{
    public class ProgramareDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ProgramareDatabase(string dbPath) 
        { 
            _database = new SQLiteAsyncConnection(dbPath); 
            _database.CreateTableAsync<Programare>().Wait();
            _database.CreateTableAsync<Salon>().Wait();     
        }
        public Task<List<Programare>> GetProgramariAsync() 
        { 
            return _database.Table<Programare>().ToListAsync(); 
        }
        public Task<Programare> GetProgramareAsync(int id) 
        { 
            return _database.Table<Programare>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SalveazaProgramareAsync(Programare slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> StergeProgramareAsync(Programare slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<List<Salon>> GetSaloaneAsync() 
        { 
            return _database.Table<Salon>().ToListAsync(); 
        }

        public Task<int> SalveazaSalonAsync(Salon shop) 
        { 
            if (shop.ID != 0) 
            { 
                return _database.UpdateAsync(shop); 
            } 
            else 
            { 
                return _database.InsertAsync(shop);
            } 
        }
    }
}
