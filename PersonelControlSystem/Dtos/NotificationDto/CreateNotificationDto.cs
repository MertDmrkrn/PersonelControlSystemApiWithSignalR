namespace PersonelControlSystem.Dtos.NotificationDto
{
    public class CreateNotificationDto
    {
        public string NotificationTitle { get; set; }

        public string ImgUrl { get; set; }

        public string NotificationDescription { get; set; }

        public DateTime NotificationDate { get; set; }
    }
}
