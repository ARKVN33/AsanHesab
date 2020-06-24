using System;
using System.Collections.Generic;
using System.Windows;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using AsanHesab.Class;
using DAL;
using DAL.Class;
using Application = System.Windows.Application;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace AsanHesab.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private bool _okClose;
        private List<tblIncome> _incomeData;
        private List<tblFee> _feeData;
        private List<spSelectIncomeInfo_Result> _incomeInfo;
        private List<spSelectFeeInfo_Result> _feeInfo;
        private List<tblBankAccount> _bankData;
        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("fa-Ir"));
            _incomeData = new List<tblIncome>();
            _feeData = new List<tblFee>();
            _incomeInfo = new List<spSelectIncomeInfo_Result>();
            _feeInfo = new List<spSelectFeeInfo_Result>();
            _bankData = new List<tblBankAccount>();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            _okClose = true;
            BackUp_Click(null, null);
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            _okClose = true;
            BackUp_Click(null, null);
            e.Cancel = false;
            Application.Current.Shutdown();
        }

        private void BackUp_Click(object sender, RoutedEventArgs e)
        {
            var fileName = PersianDateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            if (_okClose == false)
            {
                var savefd = new SaveFileDialog
                {
                    Filter = "Backup File (*.Bak)|*.Bak",
                    FileName = fileName
                };
                var result = savefd.ShowDialog();
                if (result != true) return;
                var directoryName = Path.GetDirectoryName(savefd.FileName) + "\\" + fileName;
                Directory.CreateDirectory(directoryName);
                var winWait = new WinWait
                {
                    DirectoryName = directoryName,
                    FileName = fileName,
                    OkBackUp = true,
                    OkRestore = false,
                    CloseOk = false

                };

                winWait.ShowDialog();
            }
            else
            {
                var directoryPath = Path.Combine(Globals.MyAppData,@"BackUp\" + fileName);

                Directory.CreateDirectory(directoryPath);
                var winWait = new WinWait
                {
                    DirectoryName = directoryPath,
                    FileName = fileName,
                    OkBackUp = true,
                    OkRestore = false,
                    CloseOk = true
                };

                winWait.ShowDialog();
            }

        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            string extractPath = null;
            try
            {
                var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = @"Zip Files (*.Zip) |*.Zip",
                    Title = @"انتخاب مسیر فایل پشتیبان"
                };

                if (openFileDialog.ShowDialog() != true) return;

                var fileName = Path.GetFileName(openFileDialog.FileName);
                var fullPath = Path.GetFullPath(openFileDialog.FileName);
                extractPath = Path.ChangeExtension(fullPath, null);
                Directory.CreateDirectory(extractPath);
                ZipFile.ExtractToDirectory(fullPath, extractPath);
                var winWait = new WinWait
                {
                    FileName = fileName,
                    WExtractPath = extractPath,
                    OkBackUp = false,
                    OkRestore = true
                };

                winWait.ShowDialog();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بازنشانی اطلاعات", exception.Message);
                if (Directory.Exists(extractPath))
                {
                    try
                    {
                        Directory.Delete(extractPath, true);
                    }
                    catch (Exception exception1)
                    {
                        Utility.MyMessageBox("خطا در حذف فایل ایجاد شده", exception1.Message);
                    }
                }
            }
        }

        private void AutoBackUp_Click(object sender, RoutedEventArgs e)
        {
            Utility.MyMessageBox("مواردی که باید بدانید", @"پشتیبان های خودکار شامل حداکثر 30 عدد فایل پشتیبان است که به ازای هربار بسته شدن نرم افزار ایجاد می شوند.
این پشتیبان ها را باید در مکانی ذخیره کنید و سپس با استفاده از گزینه -بازنشانی فایل پشتیبان- اقدام به بازنشانی فایل پشتیبان کنید.", "AboutUs.png");

            if (!Utility.Ok) return;
            var dialog = new FolderBrowserDialog
                { Description = @"انتخاب مسیر ذخیره سازی فایل های پشتیبان" };
            var result = dialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK) return;


            var directoryName = Path.GetFullPath(dialog.SelectedPath);


            var winWait = new WinWait
            {
                DirectoryName = directoryName,
                OkAutoBackUp = true
            };
            winWait.ShowDialog();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var winChangePassword = new WinChangePassword();
            winChangePassword.ShowDialog();
        }

        private void BtnBankAccount_Click(object sender, RoutedEventArgs e)
        {
            var winBankAccount = new WinBankAccount();
            winBankAccount.ShowDialog();
            Window_Loaded(null, null);
        }

        private void BtnIncome_Click(object sender, RoutedEventArgs e)
        {
            var winIncome = new WinIncome();
            winIncome.ShowDialog();
            Window_Loaded(null, null);
        }

        private void BtnFee_Click(object sender, RoutedEventArgs e)
        {
            var winFee = new WinFee();
            winFee.ShowDialog();
            Window_Loaded(null, null);

        }

        private void BtnIncomeCategory_Click(object sender, RoutedEventArgs e)
        {
            var winIncomeCategory = new WinIncomeCategory();
            winIncomeCategory.Show();
        }

        private void BtnFeeCategory_Click(object sender, RoutedEventArgs e)
        {
            var winFeeCategory = new WinFeeCategory();
            winFeeCategory.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _incomeData = DIncome.GetIncomeData();
                _feeData = DFee.GetFeeData();
                _incomeInfo = DIncome.GetDataNoAsync();
                _feeInfo = DFee.GetDataNoAsync();
                _bankData = DBankAccount.GetDataNoAsync();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
            }
            var today = PersianDateTime.Now.Date.ToString("yyyy/MM/dd");
            var firstDayOfWeek = PersianDateTime.Now.FirstDayOfWeek.ToString("yyyy/MM/dd");
            var lastDayOfWeek = PersianDateTime.Now.LastDayOfWeek.ToString("yyyy/MM/dd");
            var firstDayOfMonth = PersianDateTime.Now.FirstDayOfMonth.ToString("yyyy/MM/dd");
            var lastDayOfMonth = PersianDateTime.Now.LastDayOfMonth.ToString("yyyy/MM/dd");
            var firstDayOfYear = PersianDateTime.Now.FirstDayOfYear.ToString("yyyy/MM/dd");
            var lastDayOfYear = PersianDateTime.Now.LastDayOfYear.ToString("yyyy/MM/dd");
            var totalIncome = Convert.ToInt64(_incomeData.Sum(y => y.Amount));
            var totalFee = Convert.ToInt64(_feeData.Sum(y => y.Amount));
            var totalAccount = Convert.ToInt64(_bankData.Sum(y => y.InitialBalance));
            var total = totalIncome - totalFee + totalAccount;
            LblTotalIncome.Content = totalIncome.ToString("N0", CultureInfo.InvariantCulture);
            LblIncomeToday.Content = Convert.ToInt64(_incomeData.Where(x => x.IncomeDate == today).Sum(y => y.Amount)).ToString("N0", CultureInfo.InvariantCulture);
            LblIncomeWeek.Content = Convert.ToInt64(_incomeData.Where(x => string.CompareOrdinal(x.IncomeDate, firstDayOfWeek) >= 0 && string.CompareOrdinal(x.IncomeDate, lastDayOfWeek) <= 0).Sum(y => y.Amount)).ToString("N0", CultureInfo.InvariantCulture);
            LblIncomeMonth.Content = Convert.ToInt64(_incomeData.Where(x => string.CompareOrdinal(x.IncomeDate, firstDayOfMonth) >= 0 && string.CompareOrdinal(x.IncomeDate, lastDayOfMonth) <= 0).Sum(y => y.Amount)).ToString("N0", CultureInfo.InvariantCulture);
            LblIncomeYear.Content = Convert.ToInt64(_incomeData.Where(x => string.CompareOrdinal(x.IncomeDate, firstDayOfYear) >= 0 && string.CompareOrdinal(x.IncomeDate, lastDayOfYear) <= 0).Sum(y => y.Amount)).ToString("N0", CultureInfo.InvariantCulture);
            LblTotalFee.Content = totalFee.ToString("N0", CultureInfo.InvariantCulture);
            LblFeeToday.Content = Convert.ToInt64(_feeData.Where(x => x.FeeDate == today).Sum(y => y.Amount)).ToString("N0", CultureInfo.InvariantCulture);
            LblFeeWeek.Content = Convert.ToInt64(_feeData.Where(x => string.CompareOrdinal(x.FeeDate, firstDayOfWeek) >= 0 && string.CompareOrdinal(x.FeeDate, lastDayOfWeek) <= 0).Sum(y => y.Amount)).ToString("N0", CultureInfo.InvariantCulture);
            LblFeeMonth.Content = Convert.ToInt64(_feeData.Where(x => string.CompareOrdinal(x.FeeDate, firstDayOfMonth) >= 0 && string.CompareOrdinal(x.FeeDate, lastDayOfMonth) <= 0).Sum(y => y.Amount)).ToString("N0", CultureInfo.InvariantCulture);
            LblFeeYear.Content = Convert.ToInt64(_feeData.Where(x => string.CompareOrdinal(x.FeeDate, firstDayOfYear) >= 0 && string.CompareOrdinal(x.FeeDate, lastDayOfYear) <= 0).Sum(y => y.Amount)).ToString("N0", CultureInfo.InvariantCulture);
            LblTotalAccount.Content = totalAccount.ToString("N0", CultureInfo.InvariantCulture);
            LblTotal.Content = total.ToString("N0", CultureInfo.InvariantCulture);
            LblTotal.Foreground = total > 0 ? Brushes.Green : Brushes.Red;
            var myValuePairs = new List<KeyValuePair<string, long?>>();
            foreach (var variable in _bankData)
            {
                var accountAmount= Convert.ToInt64(_incomeInfo.Where(x => x.BankAccont_Id == variable.Id).Sum(y => y.Amount)) - Convert.ToInt64(_feeInfo.Where(x => x.BankAccont_Id == variable.Id).Sum(y => y.Amount)) + variable.InitialBalance;
                myValuePairs.Add(new KeyValuePair<string, long?>(variable.BankName,accountAmount));
            }
            CChart.DataContext = myValuePairs;
        }

        private void BtndbAsanHesabInfo_Click(object sender, RoutedEventArgs e)
        {
            var winReport = new WinReport();
            winReport.ShowDialog();
        }
    }
}
