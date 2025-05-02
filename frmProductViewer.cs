using ApiClients.Api_URLs;
using ApiClients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiClients.ClientDtos;
using Computer_Store.Properties;

namespace Computer_Store
{
    public partial class frmProductViewer : Form
    {

        private ProductsApiClient _ProductsClient = new ProductsApiClient(ApiUrls.ProductsURL);
        private ProductImagesApiClient _ProductImagesClient = new ProductImagesApiClient(ApiUrls.ProductImagesURL);
        private ReviewsApiClient _ReviewsClient = new ReviewsApiClient(ApiUrls.ReviewsURL);
        private UserSettingsApiClient _UserSettingsClient = new UserSettingsApiClient(ApiUrls.UserSettingsURL);
        private OrderItemsApiClient _OrderItemsClient = new OrderItemsApiClient(ApiUrls.OrderItemsURL);
        private OrdersApiClient _OrdersClient = new OrdersApiClient(ApiUrls.OrdersURL);

        private int? _ProductID;
        private int? _UserID;
        private ProductDetailsDto _Product;
        private ReviewDto _Review;
        private List<string> _ProductImagePaths;
        private byte _ImageOrder;

        public frmProductViewer(int? productID)
        {
            InitializeComponent();

            if (productID is null || productID < 1)
            {
                MessageBox.Show("Invalid Product ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Close the form if the product ID is invalid
                this.Close();
            }

            _ProductID = productID;
        }

        private async void frmProductViewer_Load(object sender, EventArgs e)
        {
            await _LoadProductDetails();
        }

        private async Task _LoadProductDetails()
        {
            try
            {
                _Product = await _ProductsClient.FindWithDetailsAsync(_ProductID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Product == null)
            {
                MessageBox.Show("Product not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await Task.WhenAll(_LoadImagesPaths(), _LoadReview(), _GetUserID());

            // Display product details and images
            await _DisplayProductDetails();
        }
            
        private async Task _GetUserID()
        {
            var currentUser = await _UserSettingsClient.FindAsync("Current User");
            if (currentUser != null && currentUser.UserID != null)
            {
                _UserID = (int)currentUser.UserID;
            }
        }

        private async Task _LoadImagesPaths()
        {
            // Load image paths from the product images
            _ProductImagePaths = new List<string>();
            List<ProductImageDto> productImages = (List<ProductImageDto>)await _ProductImagesClient.GetAllByProductIdAsync((int)_Product.ID);

            foreach (var image in productImages)
            {
                _ProductImagePaths.Add(image.ImagePath);
            }
        }

        private void _DisplayProductsImages(byte imageOrder)
        {
            if (_ProductImagePaths != null && _ProductImagePaths.Count > imageOrder - 1)
            {
                // Display the first image in the list
                string imagePath = _ProductImagePaths[imageOrder - 1];
                pbProductImage.ImageLocation = imagePath;
            }
            else
            {
                pbProductImage.ImageLocation = null;
                pbProductImage.Image = Resources.No_Image;
            }

            _UpdateImagesNavigationUI();
        }

        private void _UpdateImagesNavigationUI()
        {
            if (_ImageOrder == 1)
            {
                pbPrevious.Enabled = false;
            }
            else
            {
                pbPrevious.Enabled = true;
            }

            if (_ImageOrder == _ProductImagePaths.Count)
            {
                pbNext.Enabled = false;
            }
            else
            {
                pbNext.Enabled = true;
            }
        }

        private async Task _DisplayProductDetails()
        {
            // Display product details
            lblProductID.Text = _Product.ID.ToString();
            lblProductName.Text = _Product.Name;
            lblProductPrice.Text = clsUtility.DecimalToMoneyString(_Product.Price);
            lblDescription.Text = _Product.Description;
            lblCategory.Text = _Product.Category;
            lblSubcategory.Text = _Product.Subcategory;
            lblBrand.Text = _Product.Brand;
            lblReviewsCount.Text = "(" + (await _ReviewsClient.GetTotalByProductAsync(_Product.ID)).ToString() + ")";
            
            // Display product rating as stars
            ctrlStarsRating.DisplayRating(_Product.Rating);

            await _DisplayProductQuantity();
            _DisplayReviewUI();

            _ImageOrder = 1; // Initialize image order to 1
            // Display the first image
            _DisplayProductsImages(1);
        }

        private void _DisplayQuantityToCart(short quantity)
        {
            nudQuantityToCart.Value = quantity > 0 ? 1 : 0;
            nudQuantityToCart.Maximum = (int)quantity;
        }

        private async Task _DisplayProductQuantity()
        {
            short? quantity = _Product.QuantityInStock;

            // check quantity added before
            var order = await _OrdersClient.FindCurrentAsync(_UserID);
            if (order != null && order.OrderID != null)
            {
                var orderItem = await _OrderItemsClient.FindAsync(new OrderItemKeyDto(order.OrderID, _Product.ID));
                if (orderItem != null && orderItem.Quantity != null)
                {
                    quantity -= orderItem.Quantity;
                }
            }

            if (quantity > 0)
            {
                lblProductInStock.Text = $"{quantity} left";
                lblProductInStock.ForeColor = Color.Green;
            }
            else
            {
                lblProductInStock.Text = "Out of stock";
                lblProductInStock.ForeColor = Color.Red;
            }

            _DisplayQuantityToCart((short)quantity);
        }

        private async Task _LoadReview()
        {
            var currentUser = await _UserSettingsClient.FindAsync("Current User");

            if (currentUser != null && currentUser.UserID != null)
            {
                int userId = (int)currentUser.UserID;
                _Review = await _ReviewsClient.FindAsync((int)_Product.ID, userId);
            }
        }

        private void _DisplayReviewUI()
        {
            if (_Review != null)
            {
                _ShowReviewUI();
                // Display the review text and rating
                rtxtReviewText.Text = _Review.ReviewText;
                if (_Review.Rating != null)
                {
                    switch (_Review.Rating)
                    {
                        case 1:
                            rbOne.Checked = true;
                            break;
                        case 2:
                            rbTwo.Checked = true;
                            break;
                        case 3:
                            rbThree.Checked = true;
                            break;
                        case 4:
                            rbFour.Checked = true;
                            break;
                        case 5:
                            rbFive.Checked = true;
                            break;
                        default:
                            rbOne.Checked = true;
                            break;
                    }
                }
            }
            else
            {
                // Hide the review UI if no review exists
                _HideReviewUI();
            }
        }

        private void _GoToNextImage()
        {
            if (_ImageOrder < _ProductImagePaths.Count)
            {
                _ImageOrder++;
                _DisplayProductsImages(_ImageOrder);
            }
        }

        private void _BackToPreviousImage()
        {
            if (_ImageOrder > 1)
            {
                _ImageOrder--;
                _DisplayProductsImages(_ImageOrder);
            }
        }

        private void _ShowReviewUI()
        {
            pbSend.Visible = true;
            lblRatinglabel.Visible = true;
            rtxtReviewText.Visible = true;

            // Show the radio buttons for rating
            rbOne.Visible = true;
            rbTwo.Visible = true;
            rbThree.Visible = true;
            rbFour.Visible = true;
            rbFive.Visible = true;

            // Set the button text to "Edit Review" if a review exists
            btnAddEditReview.Text = "Edit Review";
        }

        private void _HideReviewUI()
        {
            pbSend.Visible = false;
            lblRatinglabel.Visible = false;
            rtxtReviewText.Visible = false;

            // Hide the radio buttons for rating
            rbOne.Visible = false;
            rbTwo.Visible = false;
            rbThree.Visible = false;
            rbFour.Visible = false;
            rbFive.Visible = false;

            // Set the button text to "Add Review" if no review exists
            btnAddEditReview.Text = "Add Review";
        }   

        private async Task _SendReview()
        {
            if (_Review == null)
            {
                _Review = new ReviewDto
                {
                    ProductID = _Product.ID,
                    UserID = _UserID,
                    ReviewText = rtxtReviewText.Text ?? null,
                    Rating = (byte)(rbOne.Checked ? 1 : rbTwo.Checked ? 2 : rbThree.Checked ? 3 : rbFour.Checked ? 4 : 5)
                };
            }
            else
            {
                _Review.ReviewText = rtxtReviewText.Text ?? null;
                _Review.Rating = (byte)(rbOne.Checked ? 1 : rbTwo.Checked ? 2 : rbThree.Checked ? 3 : rbFour.Checked ? 4 : 5);
            }
            // Save the review
            var savedReview = await _ReviewsClient.SaveAsync(_Review);
            if (savedReview != null)
            {
                // Update the review object with the saved review
                _Review = savedReview;
                MessageBox.Show("Review saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update the stars UI with the saved review
                ctrlStarsRating.DisplayRating(_Review.Rating);
            }
            else
            {
                MessageBox.Show("Failed to save review", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _AddItemToCart()
        {
            // Add the item to the cart
            var orderItem = new OrderItemDto
            {
                ProductID = _Product.ID,
                Quantity = (short)nudQuantityToCart.Value,
                UserID = _UserID,
            };
            var result = await _OrderItemsClient.AddNewAsync(orderItem);
            if (result != null)
            {
                MessageBox.Show("Item added to cart successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update the product quantity in stock
                await _DisplayProductQuantity();
            }
            else
            {
                MessageBox.Show("Failed to add item to cart", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            _GoToNextImage();
        }

        private void pbPrevious_Click(object sender, EventArgs e)
        {
            _BackToPreviousImage();
        }

        private void pbNext_MouseHover(object sender, EventArgs e)
        {
            pbNext.BackColor = Color.Gainsboro;
        }

        private void pbNext_MouseLeave(object sender, EventArgs e)
        {
            pbNext.BackColor = Color.Transparent;
        }

        private void pbPrevious_MouseHover(object sender, EventArgs e)
        {
            pbPrevious.BackColor = Color.Gainsboro;
        }

        private void pbPrevious_MouseLeave(object sender, EventArgs e)
        {
            pbPrevious.BackColor = Color.Transparent;
        }

        private void pbSend_MouseHover(object sender, EventArgs e)
        {
            pbSend.BackColor = Color.Gainsboro;
        }

        private void pbSend_MouseLeave(object sender, EventArgs e)
        {
            pbSend.BackColor = Color.Transparent;
        }

        private async void pbSend_Click(object sender, EventArgs e)
        {
            await _SendReview();
        }

        private void btnAddEditReview_Click(object sender, EventArgs e)
        {
            if (btnAddEditReview.Text == "Add Review")
            {
                _ShowReviewUI();
            }
            else
            {
                _HideReviewUI();
            }
        }

        private void nudQuantityToCart_ValueChanged(object sender, EventArgs e)
        {
            if (nudQuantityToCart.Value == 0)
            {
                btnAddToCart.Enabled = false;
                btnAddToCart.BackColor = Color.Gray;
                btnAddToCart.ForeColor = Color.Black;
            }
            else
            {
                btnAddToCart.Enabled = true;
                btnAddToCart.BackColor = Color.Black;
                btnAddToCart.ForeColor = Color.White;
            }
        }

        private async void btnAddToCart_Click(object sender, EventArgs e)
        {
            await _AddItemToCart();
        }
    }
}
