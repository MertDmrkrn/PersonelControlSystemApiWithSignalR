using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        public int NotificationID { get; set; }

        public string NotificationTitle { get; set; }

        public string ImgUrl { get; set; }

        public string NotificationDescription { get; set; }

        public DateTime NotificationDate { get; set; }
    }
}
