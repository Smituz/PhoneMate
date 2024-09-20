using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneMate
{
    public partial class Login : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check if all validations pass
            if (Page.IsValid && ValidateUser(username, password))
            {
                Session["Username"] = username;
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Invalid username or password.";
            }
        }

        private bool ValidateUser(string username, string password)
        {
            bool isValid = false;

            string connectionString = ConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString;

            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();

                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    { 
                        isValid = true;
                    }
                }
            }

            return isValid;
        }
    }
}
