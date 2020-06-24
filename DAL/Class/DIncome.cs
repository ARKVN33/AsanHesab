using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DIncome
    {
        private readonly dbAsanHesabEntities _dbAsanHesabEntities;

        #region Constructor

        public DIncome()
        {
            _dbAsanHesabEntities = new dbAsanHesabEntities();
        }

        #endregion

        #region Properties

        public int DId { get; set; }

        public byte DPaymentTypeId { get; set; }

        public int? DIncomeCategoryId { get; set; }

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
            var tblIncome = new tblIncome
            {
                PaymentType_Id = DPaymentTypeId,
                IncomeCategory_Id = DIncomeCategoryId,
                BankAccont_Id = DBankAccontId,
                IncomeDate = DDate,
                IncomeTime = DTime,
                Amount = DAmount,
                ReceiptNumber = DReceiptNumber,
                IncomeDescription = DDescription
            };
            _dbAsanHesabEntities.tblIncome.Add(tblIncome);
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbAsanHesabEntities.tblIncome.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            result.PaymentType_Id = DPaymentTypeId;
            result.IncomeCategory_Id = DIncomeCategoryId;
            result.BankAccont_Id = DBankAccontId;
            result.IncomeDate = DDate;
            result.IncomeTime = DTime;
            result.Amount = DAmount;
            result.ReceiptNumber = DReceiptNumber;
            result.IncomeDescription = DDescription;
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbAsanHesabEntities.tblIncome.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbAsanHesabEntities.tblIncome.Remove(result);
            _dbAsanHesabEntities.SaveChanges();
        }

        public static Task<List<spSelectIncomeInfo_Result>> GetData()
        {
            var dbLoanEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbLoanEntities.spSelectIncomeInfo().ToList());
        }
        public static List<spSelectIncomeInfo_Result> GetDataNoAsync()
        {
            var dbLoanEntities = new dbAsanHesabEntities();
            return dbLoanEntities.spSelectIncomeInfo().ToList();
        }
        public static List<tblIncome> GetIncomeData()
        {
            var dbLoanEntities = new dbAsanHesabEntities();
            return dbLoanEntities.tblIncome.ToList();
        }

        public static Task<List<tblIncome>> GetIncomeCategoryData(int categoryId)
        {
            var dbAsanHesabEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbAsanHesabEntities.tblIncome.Where(x => x.IncomeCategory_Id == categoryId).ToList());
        }

        public static Task<List<tblIncome>> GetIncomeBankData(int bankId)
        {
            var dbAsanHesabEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbAsanHesabEntities.tblIncome.Where(x => x.BankAccont_Id == bankId).ToList());
        }
        #endregion
    }
}
