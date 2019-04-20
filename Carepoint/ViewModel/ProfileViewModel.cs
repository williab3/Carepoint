using Carepoint.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.IO.Compression;
using System.Data.Entity;

namespace Carepoint.ViewModel
{
    public class ProfileViewModel 
    {
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

        [Display(Name = "DSN Phone")]
        [DataType(DataType.PhoneNumber)]
        public string DSNPhone { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ProfilePic { get; set; }

        public string PhoneNumber { get; set; }

        public string Bio { get; set; }
        public string UserId { get; set; }

        public bool IsCarepointNameValid { get; set; }

        public bool IsPhoneNumberValid { get; set; }

        public bool IsDsnPhoneValid { get; set; }

        public string ProfilePicUrl { get; set; }
        public bool IsBioValid { get; set; }
        public HttpPostedFileBase PicFile { get; set; }
        public List<Friend> Friends { get; set; }

        //private ApplicationUser _user;
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public ProfileViewModel(string userId)
        {
            ApplicationUser _user = dbContext.Users.Include(u => u.Friends).SingleOrDefault(u => u.Id == userId);
            FirstName = _user.FirstName;
            LastName = _user.LastName;
            UserId = userId;
            CarePointName = _user.CarePointName;
            PhoneNumber = _user.PhoneNumber;
            DSNPhone = _user.DSNPhone;
            Bio = _user.Bio;
            ProfilePicUrl = _user.ProfilePic;
            Friends = _user.Friends;

            if (_user.CarePointName == null)
            {
                IsCarepointNameValid = false;
            }
            else
            {
                IsCarepointNameValid = true;
            }

            if (_user.PhoneNumber == null)
            {
                IsPhoneNumberValid = false;
            }
            else
            {
                IsPhoneNumberValid = true;
            }

            if (_user.DSNPhone == null)
            {
                IsDsnPhoneValid = false;
            }
            else
            {
                IsDsnPhoneValid = true;
            }

            if (_user.Bio == null)
            {
                IsBioValid = false;
            }
            else
            {
                IsBioValid = true;
            }
        }

        public ProfileViewModel()
        {

        }

        public void SaveData()
        {
            var userInDb = dbContext.Users.Single(u => u.Id == UserId);
            if (!string.IsNullOrEmpty(PhoneNumber))
            {
                userInDb.PhoneNumber = PhoneNumber;
                IsPhoneNumberValid = true;
            }
            if (!string.IsNullOrEmpty(DSNPhone))
            {
                userInDb.DSNPhone = DSNPhone;
                IsDsnPhoneValid = true;
            }
            if (!string.IsNullOrEmpty(CarePointName))
            {
                userInDb.CarePointName = CarePointName;
                IsCarepointNameValid = true;
            }
            if (!string.IsNullOrEmpty(Bio))
            {
                userInDb.Bio = Bio;
                IsBioValid = true;
            }
            if (PicFile != null && PicFile.ContentLength > 0)
            {
                string fileExt = Path.GetExtension(PicFile.FileName).ToLower();
                if (fileExt == ".jpg" || fileExt == ".png" || fileExt == ".jpeg" || fileExt == ".gif")
                {
                    string originalFileName = PicFile.FileName;
                    string picGuid = Guid.NewGuid().ToString().Replace("-", "");
                    string newFileName = string.Concat(picGuid,"-id-", UserId);
                    string imageFilePath = Path.Combine(HttpContext.Current.Server.MapPath(@"~\Content\Images\Profile_Pics"), newFileName + fileExt);
                    //Compress & archive old pictures
                    if (userInDb.ProfilePic != null)
                    {
                        string oldPicUrl = HttpContext.Current.Server.MapPath(userInDb.ProfilePic);
                        FileInfo oldFile = new FileInfo(oldPicUrl);
                        FileInfo zipFile;
                        DirectoryInfo archiveDestination = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~\Content\Images\Profile_Pics\ArchivedPics"));
                        using (FileStream stream = oldFile.OpenRead())
                        {
                            using (FileStream zipStream = File.Create(oldFile.FullName + ".gz"))
                            {
                                using (GZipStream compressionStream = new GZipStream(zipStream, CompressionMode.Compress))
                                {
                                    stream.CopyTo(compressionStream);
                                    zipFile = new FileInfo(oldFile.FullName + ".gz");
                                }
                            }
                            zipFile.MoveTo(archiveDestination.FullName + Path.DirectorySeparatorChar + Path.GetFileName(zipFile.FullName));
                            File.Delete(oldFile.FullName + ".gz");
                            
                        }
                        File.Delete(oldFile.FullName);
                    }
                    PicFile.SaveAs(imageFilePath);
                    userInDb.ProfilePic = Path.Combine(@"\Content\Images\Profile_Pics", newFileName + fileExt);
                    ProfilePicUrl = userInDb.ProfilePic;
                }
            }
            dbContext.SaveChanges();
        }
    }
}