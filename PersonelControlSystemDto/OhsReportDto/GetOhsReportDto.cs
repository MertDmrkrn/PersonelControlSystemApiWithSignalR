﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelControlSystemDto.OhsReportDto
{
    public class GetOhsReportDto
    {
        public int OhsID { get; set; }

        public string OhsTitle { get; set; }

        public string OhsDescription { get; set; }

        public DateTime OhsDate { get; set; }
    }
}
