using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace PhoneMate
{
    public partial class EditContact : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindContacts();  // Bind the data only when the page first loads
            }
        }

        // Bind the contacts to GridView
        private void BindContacts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ContactID, FullName, PhoneNumber, Email FROM Contacts ORDER BY FullName";  // Ordered by FullName

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvContacts.DataSource = dt;
                gvContacts.DataBind();
            }
        }

        // Handle Paging
        protected void gvContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContacts.PageIndex = e.NewPageIndex;  // Set the new page index
            BindContacts();  // Rebind the data to display the new page
        }

        // Handle Sorting
        protected void gvContacts_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = GetContactsData();  // Get all contacts data
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvContacts.DataSource = dataView;
                gvContacts.DataBind();
            }
        }

        private DataTable GetContactsData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ContactID, FullName, PhoneNumber, Email FROM Contacts ORDER BY FullName";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void gvContacts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row to be edited
            gvContacts.EditIndex = e.NewEditIndex;

            // Rebind the data to show the row in edit mode
            BindContacts();
        }

        protected void gvContacts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Get the contact ID (primary key) of the selected row
            int contactId = Convert.ToInt32(gvContacts.DataKeys[e.RowIndex].Value);

            // Find the controls from the GridView row and extract the updated values
            GridViewRow row = gvContacts.Rows[e.RowIndex];
            TextBox txtFullName = (TextBox)row.FindControl("txtFullName");
            TextBox txtPhoneNumber = (TextBox)row.FindControl("txtPhoneNumber");
            TextBox txtEmail = (TextBox)row.FindControl("txtEmail");

            if (txtFullName != null && txtPhoneNumber != null && txtEmail != null)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Contacts SET FullName = @FullName, PhoneNumber = @PhoneNumber, Email = @Email WHERE ContactID = @ContactID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@ContactID", contactId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            // Reset the edit index and rebind the data
            gvContacts.EditIndex = -1;
            BindContacts();
        }

        protected void gvContacts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel the edit mode and rebind the data
            gvContacts.EditIndex = -1;
            BindContacts();
        }

    }
}
