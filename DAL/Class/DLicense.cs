using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DLicense
    {
        private readonly dbAsanHesabEntities _dbAsanHesabEntities;

        #region Constructor

        public DLicense()
        {
            _dbAsanHesabEntities = new dbAsanHesabEntities();
        }

        #endregion

        #region Properties

        public string DAppLicense { get; set; }

        public string DAppVersion { get; set; }

        #endregion

        #region Methods

        public void Add()
        {
            var tblLicense = new tblLicense
            {
                Id = 1,
                AppLicense = DAppLicense,
                AppVersion = DAppVersion
            };
            _dbAsanHesabEntities.tblLicense.Add(tblLicense);
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbAsanHesabEntities.tblLicense.SingleOrDefault(x => x.Id == 1);
            if (result == null) return;
            result.AppLicense = DAppLicense;
            result.AppVersion = DAppVersion;
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbAsanHesabEntities.tblLicense.SingleOrDefault(x => x.Id == 1);
            if (result == null) return;
            _dbAsanHesabEntities.tblLicense.Remove(result);
            _dbAsanHesabEntities.SaveChanges();
        }

        public static Task<List<tblLicense>> GetData()
        {
            var dbAsanHesabEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbAsanHesabEntities.tblLicense.Where(x => x.Id == 1).ToList());
        }
        #endregion
    }
}
