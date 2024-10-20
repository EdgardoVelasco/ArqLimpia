using System.Text.Json.Serialization;

namespace RestfulReservas.Business.Entitites
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }


    }
}
