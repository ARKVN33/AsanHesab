using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Class
{
    public class DBankAccount
    {
        private readonly dbAsanHesabEntities _dbAsanHesabEntities;

        #region Constructor

        public DBankAccount()
        {
            _dbAsanHesabEntities = new dbAsanHesabEntities();
        }

        #endregion

        #region Properties

        public int DId { get; set; }

        public string DBankName { get; set; }

        public string DBranchName { get; set; }

        public string DAccountNum { get; set; }

        public string DCardNum { get; set; }

        public long DInitialBalance { get; set; }

        public string DDescription { get; set; }

        #endregion

        #region Methods

        public void Add()
        {
            var tblBankAccount = new tblBankAccount()
            {
                BankName = DBankName,
                BranchName = DBranchName,
                AccountNum = DAccountNum,
                CardNum = DCardNum,
                InitialBalance = DInitialBalance,
                BankDescription = DDescription
            };
            _dbAsanHesabEntities.tblBankAccount.Add(tblBankAccount);
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Edit()
        {
            var result = _dbAsanHesabEntities.tblBankAccount.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            result.BankName = DBankName;
            result.BranchName = DBranchName;
            result.AccountNum = DAccountNum;
            result.CardNum = DCardNum;
            result.InitialBalance = DInitialBalance;
            result.BankDescription = DDescription;
            _dbAsanHesabEntities.SaveChanges();
        }

        public void Delete()
        {
            var result = _dbAsanHesabEntities.tblBankAccount.SingleOrDefault(x => x.Id == DId);
            if (result == null) return;
            _dbAsanHesabEntities.tblBankAccount.Remove(result);
            _dbAsanHesabEntities.SaveChanges();
        }

        public static Task<List<tblBankAccount>> GetData()
        {
            var dbAsanHesabEntities = new dbAsanHesabEntities();
            return Task.Run(() => dbAsanHesabEntities.tblBankAccount.ToList());
        }
        public static List<tblBankAccount> GetDataNoAsync()
        {
            var dbAsanHesabEntities = new dbAsanHesabEntities();
            return dbAsanHesabEntities.tblBankAccount.ToList();
        }
        #endregion
    }
}
