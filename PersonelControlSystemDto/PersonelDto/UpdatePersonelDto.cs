using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelControlSystemDto.PersonelDto
{
    public class UpdatePersonelDto
    {
        public int PersonelID { get; set; }

        public string PersonelName { get; set; }

        public string PersonelTitle { get; set; }

        public int PersonelRegisterNumber { get; set; }

        public DateTime PersonelShiftDate { get; set; }
    }
}
