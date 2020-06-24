using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DUser
    {
        private readonly dbAsanHesabEntities _dbAsanHesabEntities;

        #region Constructor

        public DUser()
        {
            _dbAsanHesabEntities = new dbAsanHesabEntities();
        }

        #endregion

        #region Properties

        public int DId { get; set; }

        public byte DPostTypeId { get; set; }

        public byte DSecurityQuestionId { get; set; }

        public string DFirstName { get; set; }

        public string DLastName { get; set; }

        public string DUserName { get; set; }

        public string DPassword { get; set; }

        public string DMobile { get; set; }

        public string DEmail { get; set; }

        public string DAnswer { get; set; }

        public string DRegistrationDate { get; set; }

        public string DImage { get; set; }

        public string DDescription { get; set; }


        #endregion

        #region Methods

        public void AddAdmin()
        {
            var tblUser = new tblUser
            {
                User_PostType_Id = DPostTypeId,
                User_SecurityQuestion_Id = DSecurityQuestionId,
                UserFirstName = DFirstName,
                UserLastName = DLastName,
                UserName = DUserName,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(DPassword),
                UserMobileNumber = DMobile,
                UserEmail = DEmail,
                UserAnswer = BCrypt.Net.BCrypt.HashPassword(DAnswer),
                UserRegistrationDate = DRegistrationDate,
                UserImage = DImage,
                UserDescription = DDescription
            };
            _dbAsanHesabEntities.tblUser.Add(tblUser);
            _dbAsanHesabEntities.SaveChanges();
            var tblSundry = new tblSundry
            {
                Id = 1,
                RegisteredAdminPassword = true
            };
            _dbAsanHesabEntities.tblSundry.Add(tblSundry);
            _dbAsanHesabEntities.SaveChanges();
        }

        public static Task<List<string>> GetQuestion()
        {
            var dbAsanHesabEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbAsanHesabEntities.tblSecurityQuestion.Select(x => x.SecurityQuestion).ToList());
        }

        public void ChangePassword()
        {
            var tblUser = new tblUser
            {
                Id = 1,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(DPassword)
            };

            using (var dbAsanHesabEntities = new dbAsanHesabEntities())
            {
                dbAsanHesabEntities.tblUser.Attach(tblUser);
                dbAsanHesabEntities.Entry(tblUser).Property(x => x.UserPassword).IsModified = true;
                dbAsanHesabEntities.SaveChanges();
            }
        }

        private static List<tblPostType> GetPostdata()
        {
            var dbAsanHesabEntities = new dbAsanHesabEntities();
            return dbAsanHesabEntities.tblPostType.ToList();
        }

        #endregion
    }
}
