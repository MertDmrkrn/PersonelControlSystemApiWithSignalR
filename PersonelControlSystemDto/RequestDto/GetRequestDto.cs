using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelControlSystemDto.RequestDto
{
    public class GetRequestDto
    {
        public int RequestID { get; set; }

        public string RequestTitle { get; set; }

        public string RequestDescription { get; set; }

        public DateTime RequestDate { get; set; }
    }
}
