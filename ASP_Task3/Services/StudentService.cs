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

        public async Task Add(Student student)
        {
            await _studentRepository.Add(student);
        }

        public async Task Delete(Student student)
        {
            await _studentRepository.Delete(student);
        }

        public async Task<List<Student>> GetAllByKey(string key = "")
        {
            var data = await _studentRepository.GetAllAsync();
            
            return data.Where(s=>key==""|| s.FirstName.ToLower().Contains(key.Trim().ToLower())).ToList();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task Update(Student student)
        {
            await _studentRepository.Update(student);
        }
    }
}
