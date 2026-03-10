using StudentManagementPortal.DTOs;

namespace StudentManagementPortal.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResponseDTO> CreateStudentAsync(CreateStudentDTO createStudentDto);
        Task<IEnumerable<StudentResponseDTO>> GetAllStudentsAsync();
        Task<StudentResponseDTO?> GetStudentByIdAsync(int id);
        Task<StudentResponseDTO?> UpdateStudentAsync(int id, UpdateStudentDTO updateStudentDto);
        Task<bool> DeleteStudentAsync(int id);
    }
}
