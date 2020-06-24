using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DFeeCategory
    {
        private readonly dbAsanHesabEntities _dbAsanHesabEntities;

        #region Constructor

        public DFeeCategory()
        {
            _dbAsanHesabEntities = new dbAsanHesabEntities();
        }

        #endregion

        #region Properties

        public int DId { get; set; }

        public int DCategoryGroupId { get; set; }

        public string DCategory { get; set; }

        #endregion

        #region Methods

        public void Add()
        {
            var feeCategory = new tblFeeCategory
            {
                CategoryGroup_Id = DCategoryGroupId,
                Category = DCategory
            };
            _dbAsanHesabEntities.tblFeeCategory.Add(feeCategory);
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbAsanHesabEntities.tblFeeCategory.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            result.CategoryGroup_Id = DCategoryGroupId;
            result.Category = DCategory;
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbAsanHesabEntities.tblFeeCategory.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbAsanHesabEntities.tblFeeCategory.Remove(result);
            _dbAsanHesabEntities.SaveChanges();
        }

        public static Task<List<tblFeeCategory>> GetData(int categoryGroupId)
        {
            var dbAsanHesabEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbAsanHesabEntities.tblFeeCategory.Where(x => x.CategoryGroup_Id == categoryGroupId).ToList());
        }

        #endregion
    }
}
