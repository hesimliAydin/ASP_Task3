using ASP_Task3.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_Task3.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task Add(Student student);
        Task Delete(Student student);
        Task Update(Student student);
        Task<Student> GetByIdAsync(int id);


    }
}
