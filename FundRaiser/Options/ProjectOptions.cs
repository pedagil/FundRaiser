using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundRaiser.Options
{
    public class ProjectOptions
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Photo { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        public string Video { get; set; }
        public string Status { get; set; }

        public DateTime ExpireDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}
