using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Options
{
    public class ProjectOptions
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Photo { get; set; }
        public string Video { get; set; }
        public string Status { get; set; }

        public DateTime ExpireDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}
