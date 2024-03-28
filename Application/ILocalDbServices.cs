using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ILocalDbServices
    {
        public  Task<List<Employee>> GetEmployees();
        public  Task<Employee> GetById(int id);
        public Task Create(Employee employee);
        public Task Update(Employee customer);
        public Task Delete(Employee customer);
        public Task<String> LoadPhotoAsync(FileResult photo);



    }
}
