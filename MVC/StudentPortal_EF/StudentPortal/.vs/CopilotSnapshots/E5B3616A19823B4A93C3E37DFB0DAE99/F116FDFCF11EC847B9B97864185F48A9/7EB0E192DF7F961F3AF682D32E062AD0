using StudentPortal.Models;
using StudentPortal.Repositories;

namespace StudentPortal.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddStudentAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
        }

        public bool StudentExists(int id)
        {
            return _studentRepository.StudentExists(id);
        }
    }
}
