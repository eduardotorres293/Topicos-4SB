
using SQLite;
using AgendaApp.Modelos;

namespace AgendaApp.Datos;

public class ContactoDatabase
{
    private readonly SQLiteAsyncConnection _db;

    public ContactoDatabase()
    {
        if (_db is not null)
            return;

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "agenda.db");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Contacto>().Wait();
    }

    public Task<List<Contacto>> ObtenerContactosAsync() => _db.Table<Contacto>().ToListAsync();

    public async Task<List<Contacto>> GetItemsActivosAsync()
    {
        return await _db.Table<Contacto>().Where(t => t.Activo).ToListAsync();

        // SQL queries are also possible
        //return await Database.QueryAsync<Contacto>("SELECT * FROM [TodoItem] WHERE [Activo] = True");
    }

    public async Task<Contacto> GetItemAsync(int id)
    {
        return await _db.Table<Contacto>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }


    public Task<int> GuardarContactoAsync(Contacto contacto) => contacto.Id != 0 ? _db.UpdateAsync(contacto) : _db.InsertAsync(contacto);
    public Task<int> EliminarContactoAsync(Contacto contacto) => _db.DeleteAsync(contacto);
}
