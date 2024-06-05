using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoginDemoServer.Models;

public partial class Grade
{
    [Key]
    public int Id { get; set; }

    [Column("Grade")]
    [StringLength(10)]
    public string Grade1 { get; set; } = null!;

    [StringLength(100)]
    public string EmailId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [StringLength(100)]
    public string? Subject { get; set; }

    [ForeignKey("EmailId")]
    [InverseProperty("Grades")]
    public virtual User Email { get; set; } = null!;
}
