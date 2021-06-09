using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundRaiser.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(70, ErrorMessage = "Better keep it simple!")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }


        public string Photo { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        public string Video { get; set; }
        public string Status { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }
        public DateTime StartDate { get; set; }


        public virtual List<Reward> ListOfRewards { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
