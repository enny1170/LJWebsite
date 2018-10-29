using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Extensions;

namespace LJWebsite.Models.Entities
{
    public class ColorKey
    {
        [Required]
        [Key]
        public int ColorID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Color")]
        public string ColorName { get; set; }

    }
}