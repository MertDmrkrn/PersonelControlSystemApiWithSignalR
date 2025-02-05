namespace PersonelControlSystem.Dtos.NotificationDto
{
    public class ResultNotificationDto
    {
        public int NotificationID { get; set; }

        public string NotificationTitle { get; set; }

        public string ImgUrl { get; set; }

        public string NotificationDescription { get; set; }

        public DateTime NotificationDate { get; set; }
    }
}
