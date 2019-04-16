using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Carepoint.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        private ApplicationDbContext dbContext;
        public ApplicationUser(string userId)
        {
            dbContext = new ApplicationDbContext();
            ApplicationUser _user = dbContext.Users.SingleOrDefault(u => u.Id == userId);
            FirstName = _user.FirstName;
            LastName = _user.LastName;
            CarePointName = _user.CarePointName;
            PhoneNumber = _user.PhoneNumber;
            DSNPhone = _user.DSNPhone;
            Bio = _user.Bio;
            ProfilePic = _user.ProfilePic;
            
        }
        public ApplicationUser()
        {

        }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(15)]
        public string LastName { get; set; }

        [Display(Name = "User ID")]
        [StringLength(10, ErrorMessage = "User ID must be between 3 and 10 characters long", MinimumLength = 3)]
        public string CarePointName { get; set; }

        [Display(Name ="DSN Phone")]
        [DataType(DataType.PhoneNumber)]
        public string DSNPhone { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ProfilePic { get; set; }

        public string Bio { get; set; }

        public List<ApplicationUser> Friends { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CodingInquiry> CodingInquiries { get; set; }
        public DbSet<PasbaApp> PasbaApps { get; set; }
        public DbSet<InstantMessage> InstantMessages { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}