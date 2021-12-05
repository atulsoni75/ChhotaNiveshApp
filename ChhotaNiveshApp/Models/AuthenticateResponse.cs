using ChhotaNivesh.Models.Users;

namespace ChhotaNiveshToolApp.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        //public AuthenticateResponse(Users userModel, string token)
        //{
        //    Id = user.Id;
        //    FirstName = user.FirstName;
        //    LastName = user.LastName;
        //    Username = user.Username;
        //    Token = token;
        //}
    }
}
