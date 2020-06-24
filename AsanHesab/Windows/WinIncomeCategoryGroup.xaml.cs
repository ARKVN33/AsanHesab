using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AsanHesab.Class;
using DAL;
using DAL.Class;
using System.Threading.Tasks;

namespace AsanHesab.Windows
{
    /// <summary>
    /// Interaction logic for WinIncomeCategory.xaml
    /// </summary>
    public partial class WinIncomeCategoryGroup
    {
        private List<tblIncomeCategoryGroup> _incomeCategoryGroup;
        private List<tblIncomeCategory> _incomeCategory;

        public WinIncomeCategoryGroup()
        {
            InitializeComponent();
            _incomeCategoryGroup = new List<tblIncomeCategoryGroup>();
            _incomeCategory = new List<tblIncomeCategory>();
        }

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

            BtnNew_Click(null, null);
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEmpty()) return;
            try
            {
                var addIncomeCategoryGroup = new DIncomeCategoryGroup
                {
                    DCategoryGroup = TxtGroup.Text

                };
                await Task.Run(() => addIncomeCategoryGroup.Add());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ثبت اطلاعات\n" + exception.Message);
                return;
            }

            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت ثبت گردید", "Correct.png");
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelectGroup() || !CheckEmpty()) return;

            var selectGroup = _incomeCategoryGroup[DgdCategoryGroup.SelectedIndex];

            try
            {
                var editIncomeCategoryGroup = new DIncomeCategoryGroup
                {
                    DId = selectGroup.Id,
                    DCategoryGroup = TxtGroup.Text
                };
                await Task.Run(() => editIncomeCategoryGroup.Edit());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در ویرایش اطلاعات\n" + exception.Message);
                return;
            }

            Window_Loaded(null, null);
            Utility.Message("پیام", "اطلاعات با موفقیت ثبت گردید", "Correct.png");
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSelectGroup()) return;
            var selectGroup = _incomeCategoryGroup[DgdCategoryGroup.SelectedIndex];
            try
            {
                _incomeCategory = await DIncomeCategory.GetData(selectGroup.Id);
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در دریافت اطلاعات\n" + exception.Message);
                return;
            }
            if (!CheckCanDelete()) return;

            Utility.MyMessageBox("هشدار", "آیا از حذف این دسته بندی اطمینان دارید؟", "Warning.png", false);

            if (!Utility.YesNo) return;
            try
            {
                var deleteIncomeCategoryGroup = new DIncomeCategoryGroup
                {
                    DId = selectGroup.Id
                };
                await Task.Run(() => deleteIncomeCategoryGroup.Delete());
            }
            catch (Exception exception)
            {
                Utility.MyMessageBox("خطا در بانک اطلاعاتی", "خطا در حذف اطلاعات\n" + exception.Message);
            }

            Utility.Message("پیام", "اطلاعات مورد نظر با موفقیت حذف گردید", "Correct.png");
            Window_Loaded(null, null);
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            TxtGroup.Text = string.Empty;

            DgdCategoryGroup.SelectedIndex = -1;

            BtnAdd.IsEnabled = true;
        }

        private void DgdCategoryGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdCategoryGroup.SelectedIndex == -1) return;


            var selectItem = _incomeCategoryGroup[DgdCategoryGroup.SelectedIndex];

            TxtGroup.Text = selectItem.CategoryGroup;

            BtnAdd.IsEnabled = false;
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

        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(TxtGroup.Text.Trim()))
            {
                Utility.Message("خطا", "لطفا نام گروه را وارد کنید", "Stop.png");
                return false;
            }

            return true;
        }

        private bool CheckSelectGroup()
        {
            if (DgdCategoryGroup.SelectedIndex == -1)
            {
                Utility.Message("اخطار", "گروهی را برای ویرایش یا حذف انتخاب کنید", "Warning.png");
                return false;
            }
            return true;
        }

        private bool CheckCanDelete()
        {
            if (_incomeCategory.Count != 0)
            {
                Utility.Message("خطا", "به دلیل موجود بودن دسته بندی برای این گروه قادر به حذف آن نیستید", "Stop.png");
                return false;
            }
            return true;
        }

        #endregion

    }
}
