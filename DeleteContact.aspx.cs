using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace PhoneMate
{
    public partial class DeleteContact : System.Web.UI.Page
    {
        private List<Contact> contactsList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            contactsList = new List<Contact>();

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Contacts ORDER BY FullName ASC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            contactsList.Add(new Contact
                            {
                                ContactID = (int)rdr["ContactID"],
                                FullName = rdr["FullName"].ToString(),
                                PhoneNumber = rdr["PhoneNumber"].ToString(),
                                Email = rdr["Email"].ToString(),
                                Address = rdr["Address"].ToString(),
                            });
                        }
                    }
                }
            }

            gvContacts.DataSource = contactsList;
            gvContacts.DataBind();
        }

        protected void gvContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContacts.PageIndex = e.NewPageIndex;
            gvContacts.DataSource = contactsList; // Rebind the original data source
            gvContacts.DataBind();
        }

        protected void gvContacts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int contactID = Convert.ToInt32(gvContacts.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString))
            {
                string deleteQuery = "DELETE FROM Contacts WHERE ContactID = @ContactID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ContactID", contactID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            BindGridView(); // Refresh the GridView after deletion
        }
    }

    public class Contact
    {
        public int ContactID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
