using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace PhoneMate
{
    public partial class DeleteContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString);
            string query = "SELECT * FROM Contacts ORDER BY FullName ASC";

            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    gvContacts.DataSource = cmd.ExecuteReader();
                    gvContacts.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        // Event to handle page indexing (pagination)
        protected void gvContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContacts.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        // RowDeleting event to delete the contact
        protected void gvContacts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int contactID = Convert.ToInt32(gvContacts.DataKeys[e.RowIndex].Value);

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString);
            string deleteQuery = "DELETE FROM Contacts WHERE ContactID = @ContactID";

            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@ContactID", contactID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                BindGridView(); // Refresh the GridView after deletion
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}
