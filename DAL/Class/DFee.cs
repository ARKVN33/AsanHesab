using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DFee
    {
        private readonly dbAsanHesabEntities _dbAsanHesabEntities;

        #region Constructor

        public DFee()
        {
            _dbAsanHesabEntities = new dbAsanHesabEntities();
        }

        #endregion

        #region Properties

        public int DId { get; set; }

        public byte DPaymentTypeId { get; set; }

        public int? DFeeCategoryId { get; set; }

        public int? DBankAccontId { get; set; }

        public string DDate { get; set; }

        public string DTime { get; set; }

        public long DAmount { get; set; }

        public string DReceiptNumber { get; set; }

        public string DDescription { get; set; }

        #endregion

        #region Methods

        public void Add()
        {
            var tblFee = new tblFee
            {
                PaymentType_Id = DPaymentTypeId,
                FeeCategory_Id = DFeeCategoryId,
                BankAccont_Id = DBankAccontId,
                FeeDate = DDate,
                FeeTime = DTime,
                Amount = DAmount,
                ReceiptNumber = DReceiptNumber,
                FeeDescription = DDescription
            };
            _dbAsanHesabEntities.tblFee.Add(tblFee);
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbAsanHesabEntities.tblFee.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            result.PaymentType_Id = DPaymentTypeId;
            result.FeeCategory_Id = DFeeCategoryId;
            result.BankAccont_Id = DBankAccontId;
            result.FeeDate = DDate;
            result.FeeTime = DTime;
            result.Amount = DAmount;
            result.ReceiptNumber = DReceiptNumber;
            result.FeeDescription = DDescription;
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbAsanHesabEntities.tblFee.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbAsanHesabEntities.tblFee.Remove(result);
            _dbAsanHesabEntities.SaveChanges();
        }

        public static Task<List<spSelectFeeInfo_Result>> GetData()
        {
            var dbLoanEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbLoanEntities.spSelectFeeInfo().ToList());
        }

        public static List<spSelectFeeInfo_Result> GetDataNoAsync()
        {
            var dbLoanEntities = new dbAsanHesabEntities();
            return dbLoanEntities.spSelectFeeInfo().ToList();
        }
        public static List<tblFee> GetFeeData()
        {
            var dbLoanEntities = new dbAsanHesabEntities();
            return dbLoanEntities.tblFee.ToList();
        }

        public static Task<List<tblFee>> GetFeeCategoryData(int categoryId)
        {
            var dbAsanHesabEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbAsanHesabEntities.tblFee.Where(x => x.FeeCategory_Id == categoryId).ToList());
        }

        public static Task<List<tblFee>> GetFeeBankData(int bankId)
        {
            var dbAsanHesabEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbAsanHesabEntities.tblFee.Where(x => x.BankAccont_Id == bankId).ToList());
        }
        #endregion
    }
}
