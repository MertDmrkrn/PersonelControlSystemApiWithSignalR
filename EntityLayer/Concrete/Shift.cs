﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Shift
    {
        public int ShiftID { get; set; }

        public string ShiftHours { get; set; }

        public List<Personel> Personels { get; set; }

        public List<OhsReport> OhsReports { get; set; }
    }
}
