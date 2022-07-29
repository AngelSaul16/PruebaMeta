using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaMeta.Models
{
    public partial class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage="El nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "El nombre solo puede tener 30 caracteres")]
        public string? Nick { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime? Birth { get; set; }

        [Required(ErrorMessage = "El curso es obligatorio")]
        public string? Grade { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public string? Status { get; set; }
    }
}
