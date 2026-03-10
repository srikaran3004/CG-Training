using Microsoft.EntityFrameworkCore;
using StudentManagementPortal.DTOs;
using StudentManagementPortal.Interfaces;
using StudentManagementPortal.Models;

namespace StudentManagementPortal.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentResponseDTO> CreateStudentAsync(CreateStudentDTO createStudentDto)
        {
            // Using a transaction to ensure both inserts are atomic
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. Create Student entity
                var student = new Student
                {
                    Name = createStudentDto.Name,
                    Email = createStudentDto.Email,
                    Course = createStudentDto.Course
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync(); // Save changes to get the generated StudentId

                // 2. Create HostelAdmission entity
                var hostelAdmission = new HostelAdmission
                {
                    RoomNumber = createStudentDto.RoomNumber,
                    Block = createStudentDto.Block,
                    StudentId = student.StudentId // Use the generated StudentId
                };

                _context.HostelAdmissions.Add(hostelAdmission);
                await _context.SaveChangesAsync();

                // Commit the transaction since both inserts were successful
                await transaction.CommitAsync();

                return new StudentResponseDTO
                {
                    StudentId = student.StudentId,
                    Name = student.Name,
                    Email = student.Email,
                    Course = student.Course,
                    RoomNumber = hostelAdmission.RoomNumber,
                    Block = hostelAdmission.Block
                };
            }
            catch (Exception)
            {
                // Rollback if any part of the process fails
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var student = await _context.Students
                    .Include(s => s.HostelAdmission)
                    .FirstOrDefaultAsync(s => s.StudentId == id);

                if (student == null)
                    return false;

                // 1. Delete HostelAdmission first
                if (student.HostelAdmission != null)
                {
                    _context.HostelAdmissions.Remove(student.HostelAdmission);
                    await _context.SaveChangesAsync();
                }

                // 2. Delete Student
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<StudentResponseDTO>> GetAllStudentsAsync()
        {
            var students = await _context.Students
                .Include(s => s.HostelAdmission)
                .ToListAsync();

            return students.Select(s => new StudentResponseDTO
            {
                StudentId = s.StudentId,
                Name = s.Name,
                Email = s.Email,
                Course = s.Course,
                RoomNumber = s.HostelAdmission?.RoomNumber ?? "N/A",
                Block = s.HostelAdmission?.Block ?? "N/A"
            });
        }

        public async Task<StudentResponseDTO?> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students
                .Include(s => s.HostelAdmission)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null)
                return null;

            return new StudentResponseDTO
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Email = student.Email,
                Course = student.Course,
                RoomNumber = student.HostelAdmission?.RoomNumber ?? "N/A",
                Block = student.HostelAdmission?.Block ?? "N/A"
            };
        }

        public async Task<StudentResponseDTO?> UpdateStudentAsync(int id, UpdateStudentDTO updateStudentDto)
        {
            if (id != updateStudentDto.StudentId)
                return null;

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var student = await _context.Students
                    .Include(s => s.HostelAdmission)
                    .FirstOrDefaultAsync(s => s.StudentId == id);

                if (student == null)
                    return null;

                // Update Student details
                student.Name = updateStudentDto.Name;
                student.Email = updateStudentDto.Email;
                student.Course = updateStudentDto.Course;

                // Update HostelAdmission details
                if (student.HostelAdmission != null)
                {
                    student.HostelAdmission.RoomNumber = updateStudentDto.RoomNumber;
                    student.HostelAdmission.Block = updateStudentDto.Block;
                }
                else
                {
                    // Case where they didn't have an admission before, but now we are adding it as part of update
                    student.HostelAdmission = new HostelAdmission
                    {
                        RoomNumber = updateStudentDto.RoomNumber,
                        Block = updateStudentDto.Block,
                        StudentId = student.StudentId
                    };
                    _context.HostelAdmissions.Add(student.HostelAdmission);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new StudentResponseDTO
                {
                    StudentId = student.StudentId,
                    Name = student.Name,
                    Email = student.Email,
                    Course = student.Course,
                    RoomNumber = student.HostelAdmission.RoomNumber,
                    Block = student.HostelAdmission.Block
                };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
