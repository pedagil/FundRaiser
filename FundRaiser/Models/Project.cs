using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundRaiser.Models
{
    public class Project
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

        //public Creator Creator { get; set; } ***** WAS NOT WORKING *****
        //public virtual List<FundProject> FundProject { get; set; }

        public DateTime ExpireDate { get; set; }
        public DateTime StartDate { get; set; }
        public virtual List<Reward> ListOfRewards { get; set; }
        //TotalAmount gia trending projects (calculated method kalytera kai vasei aytou ftiaxnw ta trending)
        public decimal TotalAmount { get; set; }
        //selected package

    }
}
