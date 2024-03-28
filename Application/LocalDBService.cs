using Application.Models;
using SQLite;


namespace Application
{
    public class LocalDBService : ILocalDbServices
    {
        public readonly static string nameSpace = "demo_local_db";

        private const string DB_NAME = "demo_local_db.db4";
        private readonly SQLiteAsyncConnection _connection;
        public LocalDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,DB_NAME));
            _connection.CreateTableAsync<Employee>();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _connection.Table<Employee>().ToListAsync();
        }

       

        public async Task<Employee> GetById(int id)
        {
            return await _connection.Table<Employee>().Where(x=> x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Employee employee)
        {
            await _connection.InsertAsync(employee);
        }

        public async Task Update(Employee customer)
        {
            await _connection.UpdateAsync(customer);
        }

        public async Task Delete(Employee customer)
        {
            await _connection.DeleteAsync(customer);
        }

        public async Task<String> LoadPhotoAsync(FileResult photo)
        {
            var stream = photo.OpenReadAsync().Result;

            byte[] imagedata;

            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                imagedata = ms.ToArray();
            }

            var folderpath = Path.Combine(FileSystem.AppDataDirectory, "Image");
            if (!File.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }

            var empfilename = Guid.NewGuid() + "_image.jpg";

            var newfile = Path.Combine(folderpath, empfilename);// Complete Path of the photo

            using (var stream2 = new MemoryStream(imagedata))
            using (var newstream = File.OpenWrite(newfile))
            {
                await stream2.CopyToAsync(newstream);
            }

            return newfile;
        }

        public List<T> GetTableRows<T>(string tableName)
        {

            object[] obj = new object[] { };
            TableMapping map = new TableMapping(Type.GetType(nameSpace + tableName));
            string query = "SELECT * FROM [" + tableName + "]";

            return _connection.QueryAsync(map, query, obj).Result.Cast<T>().ToList();

        }



    }
}
