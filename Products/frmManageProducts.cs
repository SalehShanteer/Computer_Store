using ApiClients.Api_URLs;
using ApiClients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiClients.ClientDtos;
using ComputerStore_Business;

namespace Computer_Store
{
    public partial class frmManageProducts : Form
    {

        private DataTable _dtProductsList;
        private ProductsApiClient _ProductsClient = new ProductsApiClient(ApiUrls.ProductsURL);
        private BrandsApiClient _BrandsClient = new BrandsApiClient(ApiUrls.BrandsURL);
        private CategoriesApiClient _CategoriesClient = new CategoriesApiClient(ApiUrls.CategoryURL);
        private SubcategoriesApiClient _SubcategoriesClient = new SubcategoriesApiClient(ApiUrls.SubcategoryURL);
        private ProductImagesApiClient _ProductImagesClient = new ProductImagesApiClient(ApiUrls.ProductImagesURL);

        private struct stList
        {
            public List<BrandDto> Brands { get; set; }
            public List<CategoryDto> Categories { get; set; }
            public List<SubcategoryDto> Subcategories { get; set; }
        }

        public frmManageProducts()
        {
            InitializeComponent();
        }

        private async void frmManageProducts_Load(object sender, EventArgs e)
        {
            await _LoadProductDataTable();
        }

        private async Task _LoadProductDataTable()
        {
            _dtProductsList = new DataTable();

            // Add columns to table
            _dtProductsList.Columns.Add("Product ID", typeof(int));
            _dtProductsList.Columns.Add("Name", typeof(string));
            _dtProductsList.Columns.Add("Description", typeof(string));
            _dtProductsList.Columns.Add("Price", typeof(decimal));
            _dtProductsList.Columns.Add("Quantity", typeof(short));
            _dtProductsList.Columns.Add("Category", typeof(string));
            _dtProductsList.Columns.Add("Subcategory", typeof(string));
            _dtProductsList.Columns.Add("Brand", typeof(string));
            _dtProductsList.Columns.Add("Rating", typeof(decimal));
            _dtProductsList.Columns.Add("Release Date", typeof(DateTime));

            // Load products
            List<ProductDetailsDto> products = (List<ProductDetailsDto>)await _ProductsClient.GetAllDetailsAsync();

            foreach(var product in products)
            {
               
                if (product.Subcategory == null)
                {
                    product.Subcategory = "N/A";
                }

                if (product.Brand == null)
                {
                    product.Brand = "N/A";
                }

                _dtProductsList.Rows.Add(product.ID, product.Name, product.Description, product.Price, product.QuantityInStock,
                    product.Category, product.Subcategory, product.Brand, product.Rating, product.ReleaseDate);
            }

            dgvProductsList.DataSource = _dtProductsList;

        }

        private void _ShowAddNewProductScreen()
        {
            frmAddUpdateProduct frm = new frmAddUpdateProduct(null);

            frm.ProductSaved += async (sender, isSaved) =>
            {
                if (isSaved)
                {
                    await _LoadProductDataTable();
                }
            };

            // Refresh the product list after saving a new product
            frm.FormClosed += (s, e) =>
            {
                this.Focus(); // Focus on close
            };
            frm.Show(); // Non-blocking
        }

        private void _ShowUpdateProductScreen()
        {

            if (dgvProductsList.SelectedCells.Count > 0)
            {
                int productID = Convert.ToInt32(dgvProductsList.CurrentRow.Cells["Product ID"].Value);

                frmAddUpdateProduct frm = new frmAddUpdateProduct(productID);
                // Refresh the product list after saving a new product

                frm.ProductSaved += async (sender, isSaved) =>
                {
                    if (isSaved)
                    {
                        await _LoadProductDataTable();
                    }
                };

                frm.FormClosed += (s, e) =>
                {
                    this.Focus(); // Focus on close           
                };
                frm.Show(); // Non-blocking
            }         
        }

        private async Task _DeleteProduct()
        {
            if (dgvProductsList.SelectedCells.Count > 0)
            {
                int productID = Convert.ToInt32(dgvProductsList.CurrentRow.Cells["Product ID"].Value);
                DialogResult result = MessageBox.Show(gvMessages.deleteMessage("product", productID), gvMessages.deleteTitle("product")
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Delete product and images asynchronously
                        var deleteProductTask = _ProductsClient.DeleteAsync(productID);
                        var deleteImagesTask = _ProductImagesClient.DeleteAllByProductIdWithFilesAsync(productID);

                        await Task.WhenAll(deleteProductTask, deleteImagesTask); 
                        await _LoadProductDataTable();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ShowAddNewProductScreen();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowAddNewProductScreen();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowUpdateProductScreen();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _DeleteProduct();
        }
    }
}
