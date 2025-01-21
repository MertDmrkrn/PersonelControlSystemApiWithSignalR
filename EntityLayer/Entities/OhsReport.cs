using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OhsReport
    {
        [Key]
        public int OhsID { get; set; }

        public string OhsTitle { get; set; }

        public string OhsDescription { get; set; }

        public DateTime OhsDate { get; set; }
        
    }
}
