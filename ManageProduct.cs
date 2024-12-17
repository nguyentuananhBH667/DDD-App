using GLOCERY;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class ManageProduct : Form
    {
        // variable to store the selected product
        private int productId;

        // variable to store the authority level of user, so that we are able to navigate back
        private string authorityLevel;

        // variable to store logged in userId
        private int userId;

        public ManageProduct(string authorityLevel, int userId)
        {
            this.authorityLevel = authorityLevel;
            this.userId = userId;
            productId = 0;
            InitializeComponent();
        }

        private void LoadCategoryCombobox()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string query = "SELECT CategoryID, CategoryName FROM Category";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cbCategory.DataSource = dataTable;
                cbCategory.DisplayMember = "CategoryName";
                cbCategory.ValueMember = "CategoryID";
            }
        }

        private bool ValidateData(String productCode,
                                  String productName,
                                  String productPrice,
                                  String productQuantity)
        {
            double temp;
            int temp2;
            if (String.IsNullOrEmpty(productName)) { return false; }
            if (String.IsNullOrEmpty(productPrice)) { return false; }
            if (!double.TryParse(productPrice, out temp)) { return false; }
            if (String.IsNullOrEmpty(productQuantity)) { return false; }
            return int.TryParse(productQuantity, out temp2);
        }

        private void UploadFile(String filter, String path)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Optional: Set file filters (e.g., only allow certain file types)
            openFileDialog.Filter = filter;

            // Examples
            // Text Files (*.txt)|*.txt
            // Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png
            // All Files (*.*)|*.*

            // You can combine these options to upload multiple type of data

            // Set title of the dialog
            openFileDialog.Title = "Select a file to upload";

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of the selected file
                string sourceFilePath = openFileDialog.FileName;

                // Specify the target path relative to the project directory
                string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploads");

                // Combine the target directory with the file name to get the destination path
                string targetFilePath = Path.Combine(targetDirectory, Path.GetFileName(sourceFilePath));

                try
                {
                    // Ensure the target directory exists
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    // Copy the file to the target directory
                    File.Copy(sourceFilePath, targetFilePath, overwrite: true);

                    txtProductImg.Text = targetFilePath;
                    // Inform the user
                    MessageBox.Show("File uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the file upload
                    MessageBox.Show("Error uploading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadProductData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string querry = "SELECT * FROM Figure";
                SqlDataAdapter adapter = new SqlDataAdapter(querry, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dtgProduct.DataSource = dataTable;
                connection.Close();
            }
        }

        private void ClearData()
        {
            FlushProductId();
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductImg.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }

        private void ChangeButtonStatus(bool buttonStatus)
        {
            btnUpload.Enabled = buttonStatus;
            btnDelete.Enabled = buttonStatus;
            btnClear.Enabled = buttonStatus;
            btnAdd.Enabled = !buttonStatus;
        }

        private void FlushProductId()
        {
            this.productId = 0;
            ChangeButtonStatus(false);
        }

        private void AddProduct()
        {
            // Open connection by calling the GetConnection function in DatabaseConnection class
            SqlConnection connection = DatabaseConnection.GetConnection();
            // Check connection
            if (connection != null)
            {
                // Open the connection
                connection.Open();
                // Get data from input
                string productCode = txtProductCode.Text;
                string productName = txtProductName.Text;
                string productImg = txtProductImg.Text;
                string price = txtProductPrice.Text;
                string quantity = txtProductQuantity.Text;
                int categoryId = Convert.ToInt32(cbCategory.SelectedValue);

                // Validate data
                if (ValidateData(productCode, productName, price, quantity))
                {
                    // Declare query
                    string sql = "INSERT INTO Figure VALUES (@productCode, @productName, @productPrice, @productQuantity, @productImg, @categoryId)";
                    // Declare SqlCommand variable to manipulate query
                    SqlCommand command = new SqlCommand(sql, connection);

                    // Add parameters
                    command.Parameters.AddWithValue("productCode", productCode);
                    command.Parameters.AddWithValue("productName", productName);
                    command.Parameters.AddWithValue("productPrice", Convert.ToDouble(price));
                    command.Parameters.AddWithValue("productQuantity", Convert.ToInt32(quantity));
                    command.Parameters.AddWithValue("productImg", productImg);
                    command.Parameters.AddWithValue("categoryId", categoryId);

                    // Execute query and get the result
                    int result = command.ExecuteNonQuery();

                    // Check the result
                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Successfully added new product",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        ClearData();
                        LoadProductData();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Cannot add new product",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                // Close the connection
                connection.Close();
            }
        }

        private void UpdateProduct()
        {
            // Open connection by calling the GetConnection function in DatabaseConnection class
            SqlConnection connection = DatabaseConnection.GetConnection();
            // Check connection
            if (connection != null)
            {
                // Open the connection
                connection.Open();
                // Get input data
                string productCode = txtProductCode.Text;
                string productName = txtProductName.Text;
                string productImg = txtProductImg.Text;
                string price = txtProductPrice.Text;
                string quantity = txtProductQuantity.Text;
                int categoryId = Convert.ToInt32(cbCategory.SelectedValue);

                // Validate data
                if (ValidateData(productCode, productName, price, quantity))
                {
                    // Declare query
                    string sql = "UPDATE Figure SET ProductCode = @productCode, " +
                                 "ProductName = @productName, " +
                                 "Price = @productPrice, " +
                                 "InventoryQuantity = @productQuantity, " +
                                 "ProductImage = @productImg, " +
                                 "CategoryID = @categoryId " +
                                 "WHERE ProductID = @productId";

                    // Declare SqlCommand variable to manipulate query
                    SqlCommand command = new SqlCommand(sql, connection);

                    // Add parameters
                    command.Parameters.AddWithValue("productCode", productCode);
                    command.Parameters.AddWithValue("productName", productName);
                    command.Parameters.AddWithValue("productPrice", Convert.ToDouble(price));
                    command.Parameters.AddWithValue("productQuantity", Convert.ToInt32(quantity));
                    command.Parameters.AddWithValue("productImg", productImg);
                    command.Parameters.AddWithValue("categoryId", categoryId);
                    command.Parameters.AddWithValue("productId", this.productId);

                    // Execute query and get the result
                    int result = command.ExecuteNonQuery();

                    // Check result
                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Successfully updated product",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        ClearData();
                        LoadProductData();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Cannot update product",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                // Close the connection
                connection.Close();
            }
        }

        private void DeleteProduct()
        {
            // Ask for confirmation
            DialogResult dialogResult = MessageBox.Show(
                "Do you want to delete the product",
                "Warning",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {
                // Check if product in any order
                // If it exists in an order, deny this action because it can cause exceptions while running
                if (!IsProductInOrder(this.productId))
                {
                    // Open connection by calling the GetConnection function in DatabaseConnection class
                    SqlConnection connection = DatabaseConnection.GetConnection();

                    // Check connection
                    if (connection != null)
                    {
                        // Open the connection
                        connection.Open();

                        // Declare query
                        string sql = "DELETE FROM Figure WHERE ProductID = @productId";

                        // Declare SqlCommand variable to manipulate query
                        SqlCommand command = new SqlCommand(sql, connection);

                        // Add parameters
                        command.Parameters.AddWithValue("productId", this.productId);

                        // Execute query and get the result
                        int result = command.ExecuteNonQuery();

                        // Check result
                        if (result > 0)
                        {
                            MessageBox.Show(
                                "Successfully deleted product",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                            ClearData();
                            LoadProductData();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Cannot delete product",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }

                        // Close the connection
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Product is in another order\nCannot delete",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private bool IsProductInOrder(int productId)
        {
            // Open connection by calling the GetConnection function in DatabaseConnection class
            SqlConnection connection = DatabaseConnection.GetConnection();
            // Check connection
            if (connection != null)
            {
                // Open the connection
                connection.Open();
                // Declare query to get number of records having ProductID equal to productId
                string sql = "SELECT COUNT(*) FROM OrderDetail WHERE ProductID = @productId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("productId", productId);
                int result = (int)command.ExecuteScalar();
                connection.Close();
                return result > 0;
            }
            return false;
        }


        private void SearchProduct(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadProductData();
            }
            else
            {
                // Open connection by calling the GetConnection function in DatabaseConnection class
                SqlConnection connection = DatabaseConnection.GetConnection();
                // Check connection
                if (connection != null)
                {
                    // Open the connection
                    connection.Open();
                    // Declare query to the database
                    string sql = "SELECT p.ProductID, p.ProductCode, p.ProductName, p.Price, " +
                                 "p.InventoryQuantity, p.ProductImage, c.CategoryName " +
                                 "FROM Product p " +
                                 "INNER JOIN Category c " +
                                 "ON p.CategoryID = c.CategoryID " +
                                 "WHERE p.ProductCode LIKE @search " +
                                 "OR p.ProductName LIKE @search " +
                                 "OR c.CategoryName LIKE @search";
                    // Initialize SqlDataAdapter to translate query result to a data table
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Add params to query
                    adapter.SelectCommand.Parameters.AddWithValue("search", "%" + search + "%");
                    // Initialize data table
                    DataTable data = new DataTable();
                    // Fill datatable with data queried from database
                    adapter.Fill(data);
                    // Set the data source for data table
                    dtgProduct.DataSource = data;
                    // Close the connection
                    connection.Close();
                }
            }
        }



        private void ManageProduct_Load(object sender, EventArgs e)
        {
            LoadProductData();
            LoadCategoryCombobox();
            ChangeButtonStatus(false);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadFile("Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png", "/upload");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (authorityLevel)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(this.authorityLevel, this.userId);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse Manager":
                    {
                        Warehouse_Manager_Form warehouseManagerForm = new Warehouse_Manager_Form(this.authorityLevel, this.userId);
                        this.Hide();
                        warehouseManagerForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        Sale_Form saleForm = new Sale_Form(this.authorityLevel, this.userId);
                        this.Hide();
                        saleForm.Show();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            //ManageCategory manageCategory = new ManageCategory(this.authorityLevel, this.employeeId);
            //this.Hide();
            //manageCategory.Show();
        }

        private void dtgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get row index based on current cell (cell clicked)
            int index = dtgProduct.CurrentCell.RowIndex;
            // Check index
            if (index != -1 && !dtgProduct.Rows[index].IsNewRow)
            {
                // Get value of each cell based on row index
                // You have to check the SQL query which is used to load data from database (LoadProductData function)
                // Use this query and execute it in SSMS to imagine the DataGridView
                // The order of the column header is as follows: ID | ProductCode | ProductName | Price | InventoryQuantity | ProductImage | CategoryName
                // And the index is from 0 to 6

                // Get the ProductID (index is 0)
                productId = Convert.ToInt32(dtgProduct.Rows[index].Cells[0].Value);
                // Change the button status by true (update, delete, clear is enabled when productId is assigned with value > 0)
                ChangeButtonStatus(true);
                // Get the ProductCode (index is 1)
                txtProductCode.Text = dtgProduct.Rows[index].Cells[1].Value.ToString();
                // Get the ProductName (index is 2)
                txtProductName.Text = dtgProduct.Rows[index].Cells[2].Value.ToString();
                // Get the ProductPrice (index is 3)
                txtProductPrice.Text = dtgProduct.Rows[index].Cells[3].Value.ToString();
                // Get the ProductQuantity (index is 4)
                txtProductQuantity.Text = dtgProduct.Rows[index].Cells[4].Value.ToString();
                // Get the Img URL (index is 5)
                txtProductImg.Text = dtgProduct.Rows[index].Cells[5].Value.ToString();
                // Get the CategoryName (index is 6) and check in ComboBox to select the equal value
                string categoryName = dtgProduct.Rows[index].Cells[6].Value.ToString();
                for (int i = 0; i < cbCategory.Items.Count; i++)
                {
                    if (cbCategory.SelectedText == categoryName)
                    {
                        cbCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text;
            SearchProduct(search);
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            ManageProduct manageProduct = new ManageProduct(this.authorityLevel, this.userId);
            this.Hide();
            manageProduct.Show();
        }
    }
}
