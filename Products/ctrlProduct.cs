using ApiClients;
using ApiClients.Api_URLs;
using ApiClients.ClientDtos;
using Computer_Store.Properties;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class ctrlProduct : UserControl
    {

        private ProductDto _Product;
        private ProductsApiClient _ProductsClient = new ProductsApiClient(ApiUrls.ProductsURL);

        public ctrlProduct()
        {
            InitializeComponent();
        }

        public void LoadProductInfo(ProductDto product)
        {
            if (product != null)
            {
                _Product = product;
                _DisplayProduct();
            }
        }

        private void _DisplayProductQuantity()
        {
            short? quantity = _Product.QuantityInStock;

            if (quantity != 0)
            {
                lblProductInStock.Text = $"{quantity} left";
                lblProductInStock.ForeColor = Color.Green;
            }
            else
            {
                lblProductInStock.Text = "Out of stock";
                lblProductInStock.ForeColor = Color.Red;
            }           
        }

        private void _DisplayRating()
        {
            float rating = (float)_Product.Rating;

            PictureBox[] starControls = { pbStar1, pbStar2, pbStar3, pbStar4, pbStar5 };

            for (int i = 0; i < starControls.Length; i++)
            {
                if (rating >= i + 0.5f)
                {
                    starControls[i].Image = Resources.FullStar;
                }
                else
                {
                    starControls[i].Image = Resources.EmptyStar;
                }
            }
        }

        private void _DisplayProduct()
        {
            lblProductID.Text = _Product.ID.ToString();
            lblProductName.Text = _Product.Name;
            lblProductPrice.Text = _Product.Price.ToString();
            _DisplayProductQuantity();
            _DisplayRating();
        }

       
    }
}
