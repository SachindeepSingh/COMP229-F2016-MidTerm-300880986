using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// using statements required for EF DB access
using COMP229_F2016_MidTerm_300880986.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;
namespace COMP229_F2016_MidTerm_300880986
{
    public partial class TodoDetails : System.Web.UI.Page
    {
      

      
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to the students page
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to conect to the server
            using (TodoContext db = new TodoContext())
            {
                // use the Todo model to create a new Todo object and 
                // save a new record

                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0) // our URL has a STUDENTID in it
                {
                    // get the id from the URL
                }

                // add form data to the new TodoList record
                newTodo.TodoDescription = TodoNameTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                //newTodo.Completed = Convert.ToBoolean(CompletedTextBox.Text);






                // use LINQ to ADO.NET to add / insert new Todo into the db

                if (TodoID == 0)
                {
                    db.Todoes.Add(newTodo);
                }

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated Todo's page
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}