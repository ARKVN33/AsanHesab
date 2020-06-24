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
    public partial class WinIncomeCategory
    {
        private List<tblIncomeCategoryGroup> _incomeCategoryGroup;
        private List<tblIncomeCategory> _incomeCategory;
        private List<tblIncome> _incomeData;

        public WinIncomeCategory()
        {
            InitializeComponent();
            _incomeCategoryGroup = new List<tblIncomeCategoryGroup>();
            _incomeCategory = new List<tblIncomeCategory>();
            _incomeData = new List<tblIncome>();
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
            if (!CheckEmpty() || !CheckSelectGroup()) return;
            var selectItem = _incomeCategoryGroup[DgdCategoryGroup.SelectedIndex];
            try
            {
                var addIncomeCategory = new DIncomeCategory
                {
                    DCategoryGroupId = selectItem.Id,
                    DCategory = TxtCategory.Text

                };
                await Task.Run(() => addIncomeCategory.Add());
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
            if (!CheckSelectGroup()) return;

            var selectGroup = _incomeCategoryGroup[DgdCategoryGroup.SelectedIndex];

            if (!CheckSelectCategory() || !CheckEmpty()) return;

            var selectCategory = _incomeCategory[DgdCategory.SelectedIndex];

            try
            {
                var editIncomeCategory = new DIncomeCategory
                {
                    DId = selectCategory.Id,
                    DCategoryGroupId = selectGroup.Id,
                    DCategory = TxtCategory.Text
                };
                await Task.Run(() => editIncomeCategory.Edit());
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
            if (!CheckSelectGroup() || !CheckSelectCategory() ) return;
            
            var selectCategory = _incomeCategory[DgdCategory.SelectedIndex];
            try
            {
                _incomeData = await DIncome.GetIncomeCategoryData(selectCategory.Id);
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
                var deleteIncomeCategory = new DIncomeCategory
                {
                    DId = selectCategory.Id
                };
                await Task.Run(() => deleteIncomeCategory.Delete());
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
            TxtCategory.Text = string.Empty;

            DgdCategoryGroup.SelectedIndex = -1;
            
            DgdCategory.SelectedIndex = -1;
            DgdCategory.ItemsSource = null;

            BtnAdd.IsEnabled = true;
        }

        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            var winIncomeCategoryGroup = new WinIncomeCategoryGroup();
            winIncomeCategoryGroup.ShowDialog();
            Window_Loaded(null, null);
        }

        private async void DgdCategoryGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdCategoryGroup.SelectedIndex == -1)
            {
                LblGroup.Content = string.Empty;
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

            LblCategory.Content = TxtCategory.Text = string.Empty;

            BtnAdd.IsEnabled = true;
        }

        private void DgdCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdCategory.SelectedIndex == -1)
            {
                LblCategory.Content = null;
                return;
            }
            var selectItem = _incomeCategory[DgdCategory.SelectedIndex];

            LblCategory.Content = TxtCategory.Text = selectItem.Category;

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
            if (string.IsNullOrEmpty(TxtCategory.Text.Trim()))
            {
                Utility.Message("خطا", "لطفا نام دسته بندی را وارد کنید", "Stop.png");
                return false;
            }

            return true;
        }

        private bool CheckSelectGroup()
        {
            if (DgdCategoryGroup.SelectedIndex == -1)
            {
                Utility.Message("اخطار", "گروهی را برای ثبت، ویرایش یا حذف انتخاب کنید", "Warning.png");
                return false;
            }
            return true;
        }

        private bool CheckSelectCategory()
        {
            if (DgdCategory.SelectedIndex == -1)
            {
                Utility.Message("اخطار", "دسته بندیی را برای ویرایش یا حذف انتخاب کنید", "Warning.png");
                return false;
            }
            return true;
        }

        private bool CheckCanDelete()
        {
            if (_incomeData.Count != 0)
            {
                Utility.Message("خطا", "به دلیل موجود بودن سوابق مالی برای این دسته بندی قادر به حذف آن نیستید", "Stop.png");
                return false;
            }
            return true;
        }

        #endregion

    }
}
