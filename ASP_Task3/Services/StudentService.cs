using ASP_Task3.Entities;
using ASP_Task3.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Task3.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task Add(Student student)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(Student student)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Student>> GetAllByKey(string key = "")
        {
            var data = await _studentRepository.GetAllAsync();
            
            return data.Where(s=>key==""|| s.FirstName.ToLower().Contains(key.Trim().ToLower())).ToList();
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}
