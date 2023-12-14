namespace Dominio.Database
{
    public class Sessions
    {
        public int SesionId { get; set; }
        public int UserId { get; set; }
        public DateTime Date_Time { get; set; }
        public Users? UsersNavigation { get; set; }
    }
}
