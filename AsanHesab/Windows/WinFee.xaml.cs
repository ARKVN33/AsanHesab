using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Arash;
using AsanHesab.Class;
using DAL;
using DAL.Class;

namespace AsanHesab.Windows
{
    /// <summary>
    /// Interaction logic for WinFee.xaml
    /// </summary>
    public partial class WinFee
    {
        private List<spSelectFeeInfo_Result> _feeData;
        private List<spSelectFeeInfo_Result> _feeSearchData;

        public WinFee()
        {
            InitializeComponent();
            _feeData = new List<spSelectFeeInfo_Result>();
            _feeSearchData = new List<spSelectFeeInfo_Result>();
        }

        #region Properties

        public int AccountId { get; set; }

        public int FeeCategoryId { get; set; }

        #endregion

        #region Event

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _feeData = await DFee.GetData();
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                Close();
                return;
            }
            _feeSearchData = _feeData;
            DgdFee.ItemsSource = _feeSearchData;

            BtnNew_Click(null, null);
        }

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountId = 1;
            LblAccount.Content = string.Empty;
            var winSelectAccount = new WinSelectAccount();
            winSelectAccount.ShowDialog();
            AccountId = winSelectAccount.Id;
            if (AccountId == 0)
            {
                LblAccount.Content = "حساب شخصی";
                AccountId = 1;
                LblAccount.Foreground = Brushes.Red;
                return;
            }
            LblAccount.Content = winSelectAccount.BankName;
            LblAccount.Foreground = AccountId == 1 ? Brushes.Red : Brushes.Green;
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEmpty()) return;

            try
            {
                var addFee = new DFee
                {
                    DPaymentTypeId = (byte) CboPayType.SelectedIndex,
                    DFeeCategoryId = FeeCategoryId,
                    DBankAccontId = AccountId,
                    DDate = Utility.CurrectDate(TxtDate.Text),
                    DTime = Utility.CurrectTime(TxtTime.Text),
                    DAmount = long.Parse(Regex.Replace(TxtAmount.Text, "[\\W]", "")),
                    DReceiptNumber = TxtReceiptNumber.Text.Trim() == string.Empty ? null : TxtReceiptNumber.Text,
                    DDescription = TxtDescription.Text.Trim() == string.Empty ? null : TxtDescription.Text
                };
                await Task.Run(() => addFee.Add());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ثبت اطلاعات\n" + exception.Message);
                return;
            }
            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت ویرایش گردید", "Correct.png");
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            TxtDate.Text = PersianDate.Today.ToString();
            TxtTime.Text = DateTime.Now.ToString("HH:mm:ss");
            TxtAmount.Text = "0";
            CboPayType.SelectedIndex = 1;
            LblCategory.Content = "نامشخص";
            LblAccount.Content = "حساب شخصی";
            LblCategory.Foreground = Brushes.Red;
            LblAccount.Foreground = Brushes.Red;
            TxtReceiptNumber.Text = string.Empty;
            TxtDescription.Text = string.Empty;
            BtnAdd.IsEnabled = true;

            AccountId = 1;
            FeeCategoryId = 1;

            DgdFee.SelectedIndex = -1;
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelectEdit() || !CheckEmpty()) return;
            var selectItem = _feeSearchData[DgdFee.SelectedIndex];
            try
            {
                var editFee = new DFee
                {
                    DId = selectItem.Id,
                    DPaymentTypeId = (byte) CboPayType.SelectedIndex,
                    DFeeCategoryId = FeeCategoryId,
                    DBankAccontId = AccountId,
                    DDate = Utility.CurrectDate(TxtDate.Text),
                    DTime = Utility.CurrectTime(TxtTime.Text),
                    DAmount = long.Parse(Regex.Replace(TxtAmount.Text, "[\\W]", "")),
                    DReceiptNumber = TxtReceiptNumber.Text.Trim() == string.Empty ? null : TxtReceiptNumber.Text,
                    DDescription = TxtDescription.Text.Trim() == string.Empty ? null : TxtDescription.Text
                };
                await Task.Run(() => editFee.Edit());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی",
                    "خطا در ثبت اطلاعات موجودی اولیه حساب\n" + exception.Message);
                return;
            }
            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت ویرایش گردید", "Correct.png");
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelectDelete()) return;
            var selectItem = _feeSearchData[DgdFee.SelectedIndex];
            Utility.MyMessageBox("هشدار", "آیا از حذف اطمینان دارید؟ ", "Warning.png", false);
            if (!Utility.YesNo) return;
            try
            {
                var deleteFee = new DFee
                {
                    DId = selectItem.Id
                };
                await Task.Run(() => deleteFee.Delete());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در حذف اطلاعات\n" + exception.Message);
                return;
            }
            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت حذف گردید", "Correct.png");
        }

        private void TxtAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtAmount.Text.Trim() == string.Empty)
            {
                TxtAmount.Text = "0";
            }
            else
            {
                decimal number;
                if (!decimal.TryParse(TxtAmount.Text, out number)) return;
                TxtAmount.Text = $"{number:N0}";
                TxtAmount.SelectionStart = TxtAmount.Text.Length;
            }
        }

        private void DgdFee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdFee.SelectedIndex == -1) return;
            BtnAdd.IsEnabled = false;
            var selectItem = _feeSearchData[DgdFee.SelectedIndex];
            // ReSharper disable once PossibleInvalidOperationException
            FeeCategoryId = (int) selectItem.FeeCategory_Id;
            // ReSharper disable once PossibleInvalidOperationException
            AccountId = (int) selectItem.BankAccont_Id;
            TxtAmount.Text = selectItem.Amount.ToString();
            TxtDate.Text = selectItem.FeeDate;
            TxtTime.Text = selectItem.FeeTime;
            if (selectItem.FeeCategory_Id == 1)
            {
                LblCategory.Content = "نامشخص";
                LblCategory.Foreground = Brushes.Red;
            }
            else
            {
                LblCategory.Content = selectItem.Category;
                LblCategory.Foreground = Brushes.Green;
            }

            if (selectItem.BankAccont_Id == 1)
            {
                LblAccount.Content = "حساب شخصی";
                LblAccount.Foreground = Brushes.Red;
            }
            else
            {
                LblAccount.Content = selectItem.BankName;
                LblAccount.Foreground = Brushes.Green;
            }
            CboPayType.SelectedIndex = selectItem.PaymentId;
            TxtReceiptNumber.Text = selectItem.ReceiptNumber;
            TxtDescription.Text = selectItem.FeeDescription;
        }

        #endregion

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

        private void NumberInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DateInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[^0-9^\/]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DisablePaste(object sender, ExecutedRoutedEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = e.Command == ApplicationCommands.Paste && regex.IsMatch(Clipboard.GetText());
        }

        private void DisablePasteDate(object sender, ExecutedRoutedEventArgs e)
        {
            var regex = new Regex(@"[^0-9^\/]+");
            e.Handled = e.Command == ApplicationCommands.Paste && regex.IsMatch(Clipboard.GetText());
        }

        //baraye shomare gozari datagrid
        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        #endregion

        #region Method

        private bool CheckSelectDelete()
        {
            if (DgdFee.SelectedIndex == -1)
            {
                Utility.Message("اخطار", "موردی را برای حذف انتخاب کنید", "Warning.png");
                return false;
            }
            return true;
        }

        private bool CheckSelectEdit()
        {
            if (DgdFee.SelectedIndex == -1)
            {
                Utility.Message("اخطار", "موردی را برای ویرایش انتخاب کنید", "Warning.png");
                return false;
            }
            return true;
        }

        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(TxtAmount.Text.Trim()) ||
                long.Parse(Regex.Replace(TxtAmount.Text, "[\\W]", "")) == 0)
            {
                Utility.Message("خطا", "لطفا مبلغ را وارد کنید", "Stop.png");
                return false;
            }

            if (string.IsNullOrEmpty(TxtDate.Text))
            {
                Utility.Message("خطا", "لطفا تاریخ وارد کنید", "Stop.png");
                return false;
            }

            if (!Utility.CheckDate(TxtDate.Text))
            {
                Utility.Message("خطا", "لطفا یک تاریخ صحیح انتخاب کنید", "Stop.png");
                return false;
            }

            if (string.IsNullOrEmpty(TxtTime.Text))
            {
                Utility.Message("خطا", "لطفا ساعت وارد کنید", "Stop.png");
                return false;
            }

            if (!Utility.CheckTime(TxtTime.Text))
            {
                Utility.Message("خطا", "لطفا یک ساعت صحیح وارد کنید", "Stop.png");
                return false;
            }

            if (string.IsNullOrEmpty(CboPayType.Text.Trim()))
            {
                Utility.Message("خطا", "لطفا نوع پرداخت را مشخص کنید", "Stop.png");
                return false;
            }
            return true;
        }


        #endregion

        private void BtnCategory_Click(object sender, RoutedEventArgs e)
        {
            FeeCategoryId = 1;
            LblCategory.Content = string.Empty;
            var winSelectFeeCategory = new WinSelectFeeCategory();
            winSelectFeeCategory.ShowDialog();
            FeeCategoryId = winSelectFeeCategory.Id;
            if (FeeCategoryId == 0)
            {
                LblCategory.Content = "نامشخص";
                FeeCategoryId = 1;
                LblCategory.Foreground = Brushes.Red;
                return;
            }
            LblCategory.Content = winSelectFeeCategory.CategoryGroup + " : " + winSelectFeeCategory.Category;
            LblCategory.Foreground = FeeCategoryId == 1 ? Brushes.Red : Brushes.Green;
        }

        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = TxtSearch.Text;

            if (string.IsNullOrEmpty(search))
            {
                _feeSearchData = _feeData;
            }

            else
            {
                _feeSearchData = await Task.Run(() => _feeSearchData.FindAll(t =>
                    !string.IsNullOrEmpty(t.FeeDate) && t.FeeDate.Contains(search) ||
                    !string.IsNullOrEmpty(t.FeeTime) && t.FeeTime.Contains(search) ||
                    !string.IsNullOrEmpty(t.BankName) && t.BankName.Contains(search) ||
                    !string.IsNullOrEmpty(t.Category) && t.Category.Contains(search) ||
                    !string.IsNullOrEmpty(t.ReceiptNumber) && t.ReceiptNumber.Contains(search) ||
                    !string.IsNullOrEmpty(t.FeeDescription) && t.FeeDescription.Contains(search)));

            }
            DgdFee.ItemsSource = _feeSearchData;
        }
    }

}
