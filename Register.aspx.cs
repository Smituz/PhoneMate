using System;
using System.Data.SqlClient;
using System.Configuration;

namespace PhoneMate
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) // Check if all the validations pass
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string email = txtEmail.Text.Trim();
                string fullName = txtFullName.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();
                string address = txtAddress.Text.Trim();
                string xid = txtXID.Text.Trim();
                string instagramID = txtInstagramID.Text.Trim();

                // Database connection
                string connectionString = ConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Users (Username, Password, Email, FullName, PhoneNumber, Address, XID, InstagramID)
                                     VALUES (@Username, @Password, @Email, @FullName, @PhoneNumber, @Address, @XID, @InstagramID)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(address) ? DBNull.Value : (object)address);
                        cmd.Parameters.AddWithValue("@XID", string.IsNullOrEmpty(xid) ? DBNull.Value : (object)xid);
                        cmd.Parameters.AddWithValue("@InstagramID", string.IsNullOrEmpty(instagramID) ? DBNull.Value : (object)instagramID);

                        try
                        {
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // Registration successful, redirect to Home page
                                Session["Username"] = username;
                                Response.Redirect("Home.aspx");
                            }
                            else
                            {
                                // Display error message if registration fails
                                Response.Write("<script>alert('Error: Could not register user. Please try again.');</script>");
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle any errors
                            Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                        }
                    }
                }
            }
        }
    }
}
