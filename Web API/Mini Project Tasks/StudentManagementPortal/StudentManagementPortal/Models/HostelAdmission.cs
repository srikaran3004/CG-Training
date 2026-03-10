using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementPortal.Models;

[Index("StudentId", Name = "UQ__HostelAd__32C52B989584500E", IsUnique = true)]
public partial class HostelAdmission
{
    [Key]
    public int HostelId { get; set; }

    [StringLength(20)]
    public string RoomNumber { get; set; } = null!;

    [StringLength(20)]
    public string Block { get; set; } = null!;

    public int StudentId { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("HostelAdmission")]
    public virtual Student Student { get; set; } = null!;
}
