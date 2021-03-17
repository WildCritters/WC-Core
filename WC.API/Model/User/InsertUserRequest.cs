namespace WC.API.Model.User
{
    public class InsertUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Ip { get; set; }
        public bool Banned { get; set; }
        public string BanReason { get; set; }
        public int Level { get; set; }
        public int RoleId { get; set; }
    }
}