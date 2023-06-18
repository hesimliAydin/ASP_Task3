using ASP_Task3.Entities;
using ASP_Task3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Task3.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly StudentDbContext _dbContext;

        public StudentRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            var data=_dbContext.Students.SingleOrDefault(c=>c.Id== student.Id);
            _dbContext.Entry(data).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _dbContext.Students.
                FirstOrDefaultAsync(c => c.Id== id);
        }

        public Task Update(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}
