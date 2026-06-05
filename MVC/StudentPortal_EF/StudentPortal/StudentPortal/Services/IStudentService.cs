using StudentPortal.Models;

namespace StudentPortal.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        bool StudentExists(int id);
    }
}
