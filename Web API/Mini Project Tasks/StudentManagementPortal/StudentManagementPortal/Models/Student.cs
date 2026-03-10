using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementPortal.Models;

[Index("Email", Name = "UQ__Students__A9D105343BC6FFEE", IsUnique = true)]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(100)]
    public string Course { get; set; } = null!;

    [InverseProperty("Student")]
    public virtual HostelAdmission? HostelAdmission { get; set; }
}
