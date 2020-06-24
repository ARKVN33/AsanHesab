using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DFeeCategoryGroup
    {
        #region Constructor

        private readonly dbAsanHesabEntities _dbAsanHesabEntities;

        public DFeeCategoryGroup()
        {
            _dbAsanHesabEntities = new dbAsanHesabEntities();
        }

        #endregion

        #region Properties

        public int DId { get; set; }

        public string DCategoryGroup { get; set; }

        #endregion

        #region Methods

        public void Add()
        {
            var feeCategoryGroup = new tblFeeCategoryGroup
            {
                CategoryGroup = DCategoryGroup,
            };
            _dbAsanHesabEntities.tblFeeCategoryGroup.Add(feeCategoryGroup);
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbAsanHesabEntities.tblFeeCategoryGroup.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            result.CategoryGroup = DCategoryGroup;
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbAsanHesabEntities.tblFeeCategoryGroup.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbAsanHesabEntities.tblFeeCategoryGroup.Remove(result);
            _dbAsanHesabEntities.SaveChanges();
        }

        public static Task<List<tblFeeCategoryGroup>> GetData()
        {
            var dbLoanEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbLoanEntities.tblFeeCategoryGroup.ToList());
        }

        #endregion
    }
}
