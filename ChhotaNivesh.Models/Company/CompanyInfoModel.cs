using System;

namespace ChhotaNivesh.Models.Company
{
    public class UserInfoModel : BaseModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public bool IsAdmin { get; set; }

        public string Token { get; set; }
    }
}
