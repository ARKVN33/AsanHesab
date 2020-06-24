using System;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using AsanHesab.Class;

namespace AsanHesab.Windows
{
    /// <summary>
    /// Interaction logic for WinReport.xaml
    /// </summary>
    public partial class WinReport
    {
        public int Count;

        public WinReport()
        {
            InitializeComponent();
            Count = 0;
        }
        public int AccountId { get; set; }
        public int IncomeCategoryId { get; set; }
        public int FeeCategoryId { get; set; }
        private void BtnCategory_Click(object sender, RoutedEventArgs e)
        {
            if (RdoIncome.IsChecked == true)
            {
                IncomeCategoryId = 1;
                LblCategory.Content = string.Empty;
                var winSelectIncomeCategory = new WinSelectIncomeCategory();
                winSelectIncomeCategory.ShowDialog();
                IncomeCategoryId = winSelectIncomeCategory.Id;
                if (IncomeCategoryId == 0)
                {
                    LblCategory.Content = "همه دسته بندی‌ها";
                    IncomeCategoryId = 1;
                    LblCategory.Foreground = Brushes.Red;
                    return;
                }
                LblCategory.Content = winSelectIncomeCategory.CategoryGroup + " : " + winSelectIncomeCategory.Category;
                LblCategory.Foreground = IncomeCategoryId == 1 ? Brushes.Red : Brushes.Green;
            }
            else if(RdoFee.IsChecked == true)
            {
                FeeCategoryId = 1;
                LblCategory.Content = string.Empty;
                var winSelectFeeCategory = new WinSelectFeeCategory();
                winSelectFeeCategory.ShowDialog();
                FeeCategoryId = winSelectFeeCategory.Id;
                if (FeeCategoryId == 0)
                {
                    LblCategory.Content = "همه دسته بندی‌ها";
                    FeeCategoryId = 1;
                    LblCategory.Foreground = Brushes.Red;
                    return;
                }
                LblCategory.Content = winSelectFeeCategory.CategoryGroup + " : " + winSelectFeeCategory.Category;
                LblCategory.Foreground = FeeCategoryId == 1 ? Brushes.Red : Brushes.Green;
            }
            else
            {
                LblCategory.Content = "همه دسته بندی‌ها";
            }
        }

        private void RdoIncome_Checked(object sender, RoutedEventArgs e)
        {
            BtnNew_Click(null, null);
        }

        private void RdoFee_Checked(object sender, RoutedEventArgs e)
        {
            BtnNew_Click(null, null);
        }

        private void RdoFeeIncome_Checked(object sender, RoutedEventArgs e)
        {
            BtnNew_Click(null, null);
        }

        #region FixedEvent

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void DateInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[^0-9^\/]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DisablePasteDate(object sender, ExecutedRoutedEventArgs e)
        {
            var regex = new Regex(@"[^0-9^\/]+");
            e.Handled = e.Command == ApplicationCommands.Paste && regex.IsMatch(Clipboard.GetText());
        }

        //baraye shomare gozari datagrid

        #endregion

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountId = 0;
            LblAccount.Content = string.Empty;
            var winSelectAccount = new WinSelectAccount();
            winSelectAccount.ShowDialog();
            AccountId = winSelectAccount.Id;
            if (AccountId == 0)
            {
                LblAccount.Content = "حساب شخصی";
                AccountId = 1;
                LblAccount.Foreground = Brushes.Green;
                return;
            }
            LblAccount.Content = winSelectAccount.BankName;
            LblAccount.Foreground = AccountId == 1 ? Brushes.Red : Brushes.Green;
        }

        private void BtnToday_Click(object sender, RoutedEventArgs e)
        {
            
            
            TxtStartDate.Text = TxtEndDate.Text = PersianDateTime.Now.Date.ToString("yyyy/MM/dd");
        }

        private void BtnWeek_Click(object sender, RoutedEventArgs e)
        {
            TxtStartDate.Text = PersianDateTime.Now.FirstDayOfWeek.ToString("yyyy/MM/dd");
            TxtEndDate.Text = PersianDateTime.Now.LastDayOfWeek.ToString("yyyy/MM/dd");
        }

        private void BtnMonth_Click(object sender, RoutedEventArgs e)
        {
            TxtStartDate.Text = PersianDateTime.Now.FirstDayOfMonth.ToString("yyyy/MM/dd");
            TxtEndDate.Text = PersianDateTime.Now.LastDayOfMonth.ToString("yyyy/MM/dd");
        }

        private void BtnYear_Click(object sender, RoutedEventArgs e)
        {
            TxtStartDate.Text = PersianDateTime.Now.FirstDayOfYear.ToString("yyyy/MM/dd");
            TxtEndDate.Text = PersianDateTime.Now.LastDayOfYear.ToString("yyyy/MM/dd");
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEmpty())return;
            var startDate = Utility.CurrectDate(TxtStartDate.Text);
            var endDate = Utility.CurrectDate(TxtEndDate.Text);
            Count = 1;
            var incomeQuery = string.Empty;
            var feeQuery = string.Empty;
            var traType = string.Empty;
            if (RdoIncome.IsChecked == true)
            {
                traType = "درآمدها";
                incomeQuery = "AND N'درآمد' = N'درآمد'";
                feeQuery = "AND N'هزینه' = N'درآمد'";
                if (IncomeCategoryId != 1)
                {
                    incomeQuery += "AND IncomeCategory_Id = " + IncomeCategoryId;
                }
            }
            if (RdoFee.IsChecked == true)
            {
                traType = "‌هزینه‌ها";
                incomeQuery = "AND N'درآمد' = N'هزینه'";
                feeQuery = "AND N'هزینه' = N'هزینه'";
                if (FeeCategoryId != 1)
                {
                    feeQuery += "AND FeeCategory_Id = " + FeeCategoryId;
                }
            }
            if (RdoFeeIncome.IsChecked == true)
            {
                traType = "درآمدها و هزینه‌ها";
                incomeQuery = string.Empty;
                feeQuery = string.Empty;
            }

            if (AccountId != 0)
            {
                incomeQuery += "AND BankAccont_Id = " + AccountId;
                feeQuery += "AND BankAccont_Id = " + AccountId;
            }
            if (!string.IsNullOrEmpty(TxtSearch.Text))
            {
                incomeQuery += string.Concat(" AND IncomeDescription LIKE N'%", TxtSearch.Text, "%'");
                feeQuery += string.Concat(" AND FeeDescription LIKE N'%", TxtSearch.Text, "%'");
            }
            var report = new StiReport();
            report.Load("Report//FullReport.mrt");
            report.Dictionary.Variables.Add(new StiVariable("ShamsiDate", PersianDateTime.Now.Date.ToString("yyyy/MM/dd")));
            report.Dictionary.Variables.Add(new StiVariable("TimeNow", PersianDateTime.Now.TimeOfDay.ToHHMMSS()));
            report.Dictionary.Variables.Add(new StiVariable("StartDate", "'" + startDate + "'"));
            report.Dictionary.Variables.Add(new StiVariable("EndDate", "'" + endDate + "'"));
            report.Dictionary.Variables.Add(new StiVariable("IncomeQuery", incomeQuery));
            report.Dictionary.Variables.Add(new StiVariable("FeeQuery", feeQuery));
            report.Dictionary.Variables.Add(new StiVariable("Account", LblAccount.Content));
            report.Dictionary.Variables.Add(new StiVariable("Category", LblCategory.Content));
            report.Dictionary.Variables.Add(new StiVariable("TraType", traType));
            report.Dictionary.Variables.Add(new StiVariable("Period", "از تاریخ " + startDate + " تا تاریخ " + endDate));
            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            FeeCategoryId = 1;
            IncomeCategoryId = 1;
            AccountId = 0;
            if (Count==0)return;
            LblAccount.Content = "همه حساب‌ها";
            LblCategory.Content = "همه دسته بندی‌ها";
            LblAccount.Foreground = Brushes.Red;
            LblCategory.Foreground = Brushes.Red;
        }

        public bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(TxtStartDate.Text))
            {
                Utility.Message("خطا", "لطفا تاریخ شروع بازه زمانی را وارد کنید", "Stop.png");
                return false;
            }

            if (!Utility.CheckDate(TxtStartDate.Text))
            {
                Utility.Message("خطا", "لطفا یک تاریخ صحیح برای تاریخ شروع بازه زمانی انتخاب کنید", "Stop.png");
                return false;
            }

            if (string.IsNullOrEmpty(TxtStartDate.Text))
            {
                Utility.Message("خطا", "لطفا تاریخ پایان بازه زمانی را وارد کنید", "Stop.png");
                return false;
            }

            if (!Utility.CheckDate(TxtStartDate.Text))
            {
                Utility.Message("خطا", "لطفا یک تاریخ صحیح برای تاریخ پایان بازه زمانی انتخاب کنید", "Stop.png");
                return false;
            }

            return true;
        }
    }
}
