using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ZenithWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public ApplicationUser(string userName) : base(userName) {}

        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Role")]
        public ApplicationRole AppRole { get; set; }
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
