using SQLite;
using SQLiteApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteApp.Services
{
    public class SQLiteAssistant
    {
        SQLiteAsyncConnection db;
        public SQLiteAssistant(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Persona>().Wait();
        }

        public Task<int> SavePersonaAsync(Persona persona)
        {
            if (persona.Id != 0)
            {
                return db.UpdateAsync(persona);
            }
            else
            {
                return db.InsertAsync(persona);
            }
        }

        public Task<List<Persona>> GetPersonaAsync()
        {
            return db.Table<Persona>().ToListAsync();
        }

        public Task<Persona> GetPersonaByIdAsync(int id)
        {
            return db.Table<Persona>().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeletePersonaAsync(Persona persona)
        {
            return db.DeleteAsync(persona);
        }
    }
}
