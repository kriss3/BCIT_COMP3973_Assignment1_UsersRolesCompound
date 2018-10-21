using Microsoft.AspNetCore.Identity;

namespace ZenithWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public ApplicationUser(string userName) : base(userName) {}

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string MobileNumber { get; set; }
    }

    /*
     * base class already capures UserName and Phone Number, do we just pass this from our class?
     * Should address be a seprate class or r u ok with props in ApplicatonUser class?
     * 
     * 
     * Login uses:  username and password (not email and password)
     * User registration must capture the following data:
     *      Username
     *      Email
     *      Password
     *      FirstName
     *      LastName
     *      Address comprising:
     *          Address Street
     *          Address City
     *          Address Province
     *          Address Postal Code
     *          Address Country
     *      Mobile Number
     */
}
