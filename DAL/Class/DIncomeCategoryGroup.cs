using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DIncomeCategoryGroup
    {
        private readonly dbAsanHesabEntities _dbAsanHesabEntities;

        #region Constructor

        public DIncomeCategoryGroup()
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
            var incomeCategoryGroup = new tblIncomeCategoryGroup
            {
                CategoryGroup = DCategoryGroup,
            };
            _dbAsanHesabEntities.tblIncomeCategoryGroup.Add(incomeCategoryGroup);
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbAsanHesabEntities.tblIncomeCategoryGroup.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            result.CategoryGroup = DCategoryGroup;
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbAsanHesabEntities.tblIncomeCategoryGroup.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbAsanHesabEntities.tblIncomeCategoryGroup.Remove(result);
            _dbAsanHesabEntities.SaveChanges();
        }

        public static Task<List<tblIncomeCategoryGroup>> GetData()
        {
            var dbLoanEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbLoanEntities.tblIncomeCategoryGroup.ToList());
        }

        #endregion
    }
}
