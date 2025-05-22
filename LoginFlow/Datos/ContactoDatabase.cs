
using SQLite;
using Practica5.Model;
using LoginFlow.Model;

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
        _db.CreateTableAsync<Usuario>().Wait();
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

    public Task<int> RegistrarUsuarioAsync(Usuario usuario)
    {
        return _db.InsertAsync(usuario);
    }

    public Task<Usuario?> ValidarUsuarioAsync(string nombre, string password)
    {
        return _db.Table<Usuario>()
                  .Where(u => u.Nombre == nombre && u.Password == password)
                  .FirstOrDefaultAsync();
    }

    public Task<bool> UsuarioExisteAsync(string nombre)
    {
        return _db.Table<Usuario>()
                  .Where(u => u.Nombre == nombre)
                  .FirstOrDefaultAsync()
                  .ContinueWith(t => t.Result != null);
    }

    public Task<List<Contacto>> ObtenerContactosPorUsuarioAsync(int usuarioId)
    {
        return _db.Table<Contacto>()
                  .Where(c => c.UsuarioId == usuarioId)
                  .ToListAsync();
    }
    public Task<int> GuardarContactoAsync(Contacto contacto) => contacto.Id != 0 ? _db.UpdateAsync(contacto) : _db.InsertAsync(contacto);
    public Task<int> EliminarContactoAsync(Contacto contacto) => _db.DeleteAsync(contacto);
}
