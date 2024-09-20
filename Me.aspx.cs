using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace PhoneMate
{
    public partial class Me : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString;

            try
            {
                using (con)
                {
                    string usernm = (string)Session["Username"];
                    string command = "SELECT * FROM Users WHERE Username = @username";
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.Parameters.AddWithValue("@username", usernm);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)  // Check if any data is returned
                    {
                        rdr.Read();  // Move to the first record

                        // Assuming you are using Labels or TextBoxes to display data:
                        lblFullName.Text = rdr["FullName"].ToString();
                        lblEmail.Text = rdr["Email"].ToString();
                        lblPhoneNumber.Text = rdr["PhoneNumber"].ToString();
                        lblAddress.Text = rdr["Address"].ToString();
                        lblXID.Text = rdr["XID"].ToString();
                        lblInstagramID.Text = rdr["InstagramID"].ToString();
                    }
                    else
                    {
                        // Handle the case where no data is returned
                        Response.Write("User has not been logged in properly.Visit Login.aspx to proper login");
                    }

                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errors: " + ex.Message);
            }
        }
    }
}
