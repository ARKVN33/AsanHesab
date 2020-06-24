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
    /// Interaction logic for WinSelectIncomeCategory.xaml
    /// </summary>
    public partial class WinSelectIncomeCategory
    {
        private List<tblIncomeCategoryGroup> _incomeCategoryGroup;
        private List<tblIncomeCategory> _incomeCategory;

        public WinSelectIncomeCategory()
        {
            InitializeComponent();
            _incomeCategoryGroup = new List<tblIncomeCategoryGroup>();
            _incomeCategory = new List<tblIncomeCategory>();
        }

        #region Properties

        public int Id { get; set; }

        public string CategoryGroup { get; set; }

        public string Category { get; set; }

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

        //baraye shomare gozari datagrid
        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }


        #endregion

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _incomeCategoryGroup = await DIncomeCategoryGroup.GetData();
                _incomeCategoryGroup.RemoveAt(0);
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                Close();
                return;
            }
            DgdCategoryGroup.ItemsSource = _incomeCategoryGroup;
            DgdCategoryGroup.SelectedIndex = -1;
        }

        private async void DgdCategoryGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdCategoryGroup.SelectedIndex == -1)
            {
                LblGroup.Content = null;
                return;
            }
            
            var selectItem = _incomeCategoryGroup[DgdCategoryGroup.SelectedIndex];
            try
            {
                _incomeCategory = await DIncomeCategory.GetData(selectItem.Id);
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                return;
            }
            LblGroup.Content = selectItem.CategoryGroup;
            DgdCategory.ItemsSource = _incomeCategory;
            DgdCategory.SelectedIndex = -1;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            var winIncomeCategory = new WinIncomeCategory();
            winIncomeCategory.ShowDialog();
            Window_Loaded(null,null);
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelect())return;
            var selectCategoryGroup = _incomeCategoryGroup[DgdCategoryGroup.SelectedIndex];
            var selectGroup = _incomeCategory[DgdCategory.SelectedIndex];
            CategoryGroup = selectCategoryGroup.CategoryGroup;
            Category = selectGroup.Category;
            Id = selectGroup.Id;
            Close();
        }

        #region Method
        private bool CheckSelect()
        {
            if (DgdCategory.SelectedIndex == -1 || LblCategory.Content == null)
            {
                Utility.Message("خطا", "گروهی را برای دسته بندی مورد نظر انتخاب کنید", "Stop.png");
                return false;
            }

            return true;
        }
        #endregion

        private void DgdCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdCategory.SelectedIndex == -1)
            {
                LblCategory.Content = null;
                return;
            }
            var selectItem = _incomeCategory[DgdCategory.SelectedIndex];
            LblCategory.Content = selectItem.Category;

        }


    }
}
