using Microsoft.AspNetCore.Mvc;
using LpuApplicationForm.Models;
using LpuApplicationForm.Repository;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace LpuApplicationForm.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repo;
        private readonly IWebHostEnvironment _env;

        public StudentController(StudentRepository repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }

        public IActionResult Index()
        {
            var students = _repo.GetAllStudent();
            return View(students);
        }

        public IActionResult Create()
        {
            return View(new StudentModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentModel obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (obj.ProfileFile != null && obj.ProfileFile.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        obj.ProfileFile.CopyTo(ms);
                        obj.ProfileImage = ms.ToArray();
                        obj.ImageExtension = Path.GetExtension(obj.ProfileFile.FileName).ToLowerInvariant();
                    }

                    if (_repo.CheckDuplicate(obj.Email, obj.Mobile))
                    {
                        ModelState.AddModelError("", "This Email or Mobile is already registered.");
                        return View(obj);
                    }

                    if (_repo.AddStudent(obj))
                    {
                        TempData["Success"] = "Form Submitted Successfully!";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex) when (ex.Message.Contains("CHK_Student_Age"))
                {
                    ModelState.AddModelError("DOB", "Applicant must be between 16 and 100 years old.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An unexpected error occurred. Please try again.");
                }
            }
            TempData["Error"] = "Submission failed. Please check the form.";
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return NotFound();
            return View("Create", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.ProfileFile != null && obj.ProfileFile.Length > 0)
                {
                    using var ms = new MemoryStream();
                    obj.ProfileFile.CopyTo(ms);
                    obj.ProfileImage = ms.ToArray();
                    obj.ImageExtension = Path.GetExtension(obj.ProfileFile.FileName).ToLowerInvariant();
                }

                // Duplicate check excluding current ID
                if (_repo.CheckDuplicate(obj.Email, obj.Mobile, obj.StudentId))
                {
                    ModelState.AddModelError("", "Another student is already using this Email or Mobile.");
                    TempData["Error"] = "Duplicate Found!";
                    return View("Create", obj);
                }

                try
                {
                    if (_repo.UpdateStudent(obj))
                    {
                        TempData["Success"] = "Application Updated Successfully!";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex) when (ex.Message.Contains("CHK_Student_Age"))
                {
                    ModelState.AddModelError("DOB", "Applicant must be between 16 and 100 years old.");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An unexpected error occurred. Please try again.");
                }
            }
            return View("Create", obj);
        }

        public IActionResult Delete(int id)
        {
            if (_repo.DeleteStudent(id))
                TempData["Success"] = "Application Deleted!";
            else
                TempData["Error"] = "Failed to delete.";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        public IActionResult DownloadApplicationPDF(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return NotFound();

            QuestPDF.Settings.License = LicenseType.Community;

            byte[] logoBytes = System.IO.File.ReadAllBytes(
                Path.Combine(_env.WebRootPath, "images", "lpu-logo.png"));

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.MarginHorizontal(40);
                    page.MarginVertical(30);

                    page.Content().Border(2).BorderColor("#F47C00").Padding(20).Column(col =>
                    {
                        // Header with Logo and Title
                        col.Item().Row(row =>
                        {
                            row.RelativeItem(1).AlignLeft().AlignMiddle()
                                .Height(60).Image(logoBytes).FitArea();

                            row.RelativeItem(3).AlignCenter().AlignMiddle().Column(titleCol =>
                            {
                                titleCol.Item().AlignCenter()
                                    .Text("LOVELY PROFESSIONAL UNIVERSITY")
                                    .FontSize(16).Bold().FontColor("#F47C00");

                                titleCol.Item().AlignCenter()
                                    .Text("OFFICIAL ADMISSION APPLICATION")
                                    .FontSize(13).Bold().FontColor("#1a1a1a");
                            });

                            row.RelativeItem(1).AlignRight().AlignMiddle()
                                .Height(60).Image(logoBytes).FitArea();
                        });

                        col.Item().PaddingVertical(8)
                            .LineHorizontal(2).LineColor("#F47C00");

                        // Application ID
                        col.Item().PaddingVertical(5).AlignCenter()
                            .Text($"Application No: {student.StudentId}")
                            .FontSize(11).Bold().FontColor("#333");

                        col.Item().PaddingBottom(5)
                            .LineHorizontal(0.5f).LineColor("#ccc");

                        // Profile Photo
                        if (student.ProfileImage != null)
                        {
                            col.Item().PaddingVertical(10).AlignCenter()
                                .Width(100).Height(120)
                                .Image(student.ProfileImage).FitArea();
                        }

                        // Personal Information Section
                        col.Item().PaddingTop(10).Text("PERSONAL INFORMATION")
                            .FontSize(12).Bold().FontColor("#F47C00").Underline();

                        col.Item().PaddingTop(8).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                            });

                            AddTableRow(table, "Full Name", student.FullName, "Gender", student.Gender);
                            AddTableRow(table, "Date of Birth", student.DOB?.ToString("dd MMM yyyy") ?? "-",
                                "Mobile", student.Mobile);
                            AddTableRow(table, "Email", student.Email, "Course Applied", student.CourseApplied);
                        });

                        // Address Section
                        col.Item().PaddingTop(15).Text("ADDRESS INFORMATION")
                            .FontSize(12).Bold().FontColor("#F47C00").Underline();

                        col.Item().PaddingTop(8).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(5);
                            });

                            AddSingleRow(table, "Address", student.Address);
                            AddSingleRow(table, "City", student.City);
                            AddSingleRow(table, "State", student.State);
                            AddSingleRow(table, "Pincode", student.Pincode);
                        });

                        // Academic Section
                        col.Item().PaddingTop(15).Text("ACADEMIC INFORMATION")
                            .FontSize(12).Bold().FontColor("#F47C00").Underline();

                        col.Item().PaddingTop(8).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                            });

                            AddTableRow(table, "10th Marks (%)",
                                student.HighSchoolMarks?.ToString("F2") ?? "-",
                                "12th Marks (%)",
                                student.IntermediateMarks?.ToString("F2") ?? "-");
                        });

                        // Footer
                        col.Item().PaddingTop(30).Row(row =>
                        {
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().PaddingTop(30)
                                    .LineHorizontal(1).LineColor("#333");
                                c.Item().AlignCenter().Text("Applicant Signature")
                                    .FontSize(9).Italic();
                            });

                            row.ConstantItem(80);

                            row.RelativeItem().Column(c =>
                            {
                                c.Item().PaddingTop(30)
                                    .LineHorizontal(1).LineColor("#333");
                                c.Item().AlignCenter().Text("Authorized Signature")
                                    .FontSize(9).Italic();
                            });
                        });

                        col.Item().PaddingTop(15).AlignCenter()
                            .Text($"Generated on: {DateTime.Now:dd MMM yyyy, hh:mm tt}")
                            .FontSize(8).FontColor("#999");
                    });
                });
            });

            using var stream = new MemoryStream();
            document.GeneratePdf(stream);
            return File(stream.ToArray(), "application/pdf",
                $"Application_{student.StudentId}_{student.FullName.Replace(" ", "_")}.pdf");
        }

        public IActionResult DownloadIDCard(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return NotFound();

            QuestPDF.Settings.License = LicenseType.Community;

            byte[] logoBytes = System.IO.File.ReadAllBytes(
                Path.Combine(_env.WebRootPath, "images", "lpu-logo.png"));

            // ID card size: 3.375 x 2.125 inches
            float cardWidth = 3.375f * 72; // points
            float cardHeight = 2.125f * 72;

            string batchYear = student.DOB.HasValue
                ? (student.DOB.Value.Year + 18).ToString()
                : "N/A";

            string validUpto = DateTime.Now.AddYears(4).ToString("dd/MM/yyyy");

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(new PageSize(cardWidth, cardHeight, Unit.Point));
                    page.Margin(0);

                    page.Content()
                        .Border(1.5f).BorderColor("#F47C00")
                        .Column(col =>
                        {
                            // Top section with student info left + logo right
                            col.Item().Padding(8).Row(row =>
                            {
                                // Left side: Batch, ID, Name
                                row.RelativeItem(3).Column(left =>
                                {
                                    left.Item().Text($"Batch :  {batchYear}")
                                        .FontSize(8).Bold().FontColor("#1a1a1a");

                                    left.Item().PaddingTop(2)
                                        .Text(student.StudentId.ToString())
                                        .FontSize(8).Bold().FontColor("#1a1a1a");

                                    left.Item().PaddingTop(2)
                                        .Text(student.FullName)
                                        .FontSize(8).Bold().FontColor("#1a1a1a");
                                });

                                // Right side: LPU Logo
                                row.RelativeItem(2).AlignRight().AlignTop()
                                    .MaxHeight(45).Image(logoBytes).FitArea();
                            });

                            // Middle section: Photo left + Address right
                            col.Item().PaddingHorizontal(8).Row(row =>
                            {
                                // Student Photo
                                row.RelativeItem(2).AlignLeft().AlignMiddle()
                                    .MaxWidth(65).MaxHeight(70)
                                    .Element(photoContainer =>
                                    {
                                        if (student.ProfileImage != null)
                                            photoContainer.Image(student.ProfileImage).FitArea();
                                        else
                                            photoContainer.Background("#eee").AlignCenter().AlignMiddle()
                                                .Text("No Photo").FontSize(6);
                                    });

                                // Address block
                                row.RelativeItem(3).PaddingLeft(5).AlignLeft().Column(addr =>
                                {
                                    addr.Item().Text($"C/O: {student.FullName}")
                                        .FontSize(6.5f).FontColor("#333");

                                    addr.Item().Text(student.Address)
                                        .FontSize(6.5f).FontColor("#333");

                                    addr.Item().Text(student.City + ",")
                                        .FontSize(6.5f).FontColor("#333");

                                    addr.Item().Text(student.State + ".")
                                        .FontSize(6.5f).FontColor("#333");
                                });
                            });

                            // Bottom section: Resi No + Valid upto
                            col.Item().PaddingHorizontal(8).PaddingBottom(5).Row(row =>
                            {
                                row.RelativeItem().AlignLeft().AlignBottom()
                                    .Text($"Resi No. : {student.Mobile}")
                                    .FontSize(6.5f).Bold().FontColor("#333");

                                row.RelativeItem().AlignRight().AlignBottom().Column(vc =>
                                {
                                    vc.Item().AlignRight()
                                        .Text($"Valid upto : {validUpto}")
                                        .FontSize(6).Bold().FontColor("#F47C00");

                                    vc.Item().AlignRight()
                                        .Text("(if not withdrawn earlier)")
                                        .FontSize(5).Italic().FontColor("#F47C00");
                                });
                            });
                        });
                });
            });

            using var stream = new MemoryStream();
            document.GeneratePdf(stream);
            return File(stream.ToArray(), "application/pdf",
                $"IDCard_{student.StudentId}_{student.FullName.Replace(" ", "_")}.pdf");
        }

        private static void AddTableRow(TableDescriptor table,
            string label1, string value1, string label2, string value2)
        {
            table.Cell().Padding(4).Text(label1).FontSize(9).Bold().FontColor("#555");
            table.Cell().Padding(4).Text(value1).FontSize(9).FontColor("#1a1a1a");
            table.Cell().Padding(4).Text(label2).FontSize(9).Bold().FontColor("#555");
            table.Cell().Padding(4).Text(value2).FontSize(9).FontColor("#1a1a1a");
        }

        private static void AddSingleRow(TableDescriptor table, string label, string value)
        {
            table.Cell().Padding(4).Text(label).FontSize(9).Bold().FontColor("#555");
            table.Cell().Padding(4).Text(value).FontSize(9).FontColor("#1a1a1a");
        }
    }
}