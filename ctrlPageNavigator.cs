using System;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class ctrlPageNavigator : UserControl
    {

        public delegate void OnPageChangeEventHandler(object sender, int PageNumber);

        public event OnPageChangeEventHandler OnPageChange;

        public int CurrentPage { get; set; }
       
        public int NumberOfPages { get; set; }

        public int NumberOfItemsInPage { get; set; }

        public ctrlPageNavigator()
        {
            InitializeComponent();
        }

        public void UpdateNumberOfPages(int ItemsNumber)
        {
            CurrentPage = 1;
            NumberOfPages = ((ItemsNumber - 1) / NumberOfItemsInPage) + 1;

            _UpdateUI();
        }

        private void _UpdateUI()
        {
            _UpdateNextButtonUI();
            _UpdatePrevButtonUI();
            _UpdatePageNumberUI();
        }

        private void _UpdatePrevButtonUI()
        {
            if (CurrentPage == 1)
            {
                btnPreviousPage.Enabled = false;
            }
            else
            {
                btnPreviousPage.Enabled = true;
            }
        }

        private void _UpdateNextButtonUI()
        {
            if (CurrentPage < NumberOfPages)
            {
                btnNextPage.Enabled = true;
            }
            else
            {
                btnNextPage.Enabled = false;
            }
        }

        private void _UpdatePageNumberUI()
        {
            lblCurrentPageNumber.Text = CurrentPage.ToString();
        }

        private void _GoToNextPage()
        {
            if (CurrentPage < NumberOfPages)
            {
                CurrentPage++;
                OnPageChange?.Invoke(this, PageNumber: CurrentPage);
            }
            _UpdateUI();
        }

        private void _BackToPreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                OnPageChange?.Invoke(this, PageNumber: CurrentPage);
            }
            _UpdateUI();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            _GoToNextPage();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            _BackToPreviousPage();
        }
    }
}
