using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AsanHesab.Class;
using DAL;
using DAL.Class;

namespace AsanHesab.Windows
{
    /// <summary>
    /// Interaction logic for WinSelectAccount.xaml
    /// </summary>
    public partial class WinSelectAccount
    {
        private List<tblBankAccount> _bankAccountData;

        #region Properties

        public int Id { get; set; }

        public string BankName { get; set; }

        #endregion

        public WinSelectAccount()
        {
            InitializeComponent();
            _bankAccountData = new List<tblBankAccount>();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Id = 1;
            BankName = "حساب شخصی";
            try
            {
                _bankAccountData = await DBankAccount.GetData();
                _bankAccountData.RemoveAt(0);
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                return;
            }
            DgdBankAccount.ItemsSource = _bankAccountData;
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelect()) return;
            var selectItem = _bankAccountData[DgdBankAccount.SelectedIndex];
            Id = selectItem.Id;
            BankName = selectItem.BankName;
            Close();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            var winBankAccount = new WinBankAccount();
            winBankAccount.ShowDialog();
            Window_Loaded(null, null);
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

        //baraye shomare gozari datagrid
        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        #endregion

        #region Method

        private bool CheckSelect()
        {
            if (DgdBankAccount.SelectedIndex == -1)
            {
                Utility.Message("خطا", "حسابی را انتخاب کنید", "Stop.png");
                return false;
            }

            return true;
        }

        #endregion

        private void DgdBankAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdBankAccount.SelectedIndex == -1) return;

            var selectItem = _bankAccountData[DgdBankAccount.SelectedIndex];
            LblBankName.Content = selectItem.BankName;
            LblBranchName.Content = selectItem.BranchName;
            LblAccNum.Content = selectItem.AccountNum;
            LblCardNum.Content = selectItem.CardNum;
        }
    }
}
