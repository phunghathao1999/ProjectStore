namespace ApplicationCore.Models
{
    public class AccountModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string token { get; set; }
        public string roles { get; set; }


        public AccountModel(PeopleModel user, string token)
        {
            id = user.id;
            username = user.username;
            name = user.name;
            roles = user.Role.roleName;
            this.token = token;
        }
    }
}