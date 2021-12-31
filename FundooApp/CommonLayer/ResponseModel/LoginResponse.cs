using System;

namespace FundooApp.Controllers.ResponseModel
{
    public class LoginResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public DateTime? Createat { get; set; }
        public DateTime? Modifiedat { get; set; }
        public string token { get; set; }
    }
}
