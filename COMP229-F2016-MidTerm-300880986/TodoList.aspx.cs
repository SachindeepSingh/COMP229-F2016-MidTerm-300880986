using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// using statements that are required to connect to EF DB

using COMP229_F2016_MidTerm_300880986.Models;
using System.Web.ModelBinding;

namespace COMP229_F2016_MidTerm_300880986

{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time
            // populate the student grid
            if (!IsPostBack)
            {
                // Get the Todo data
                this.TodoData();
            }

        }


        /// <summary>
        /// This method gets the Todo data from the DB
        /// </summary>
        private void TodoData()
        {
            // connect to DB
            using (TodoContext db = new TodoContext())
            {

                // query the Student Table using EF and LINQ
                var ToDo = (from allTodos in db.Todoes
                            select allTodos);

                // bind the result to the Students GridView
                TodoListGridView.DataSource = ToDo.ToList();
                TodoListGridView.DataBind();
            }
        }

        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected todoID using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(TodoListGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF and LINQ to find the selected todo in the DB and remove it
            using (TodoContext db = new TodoContext())
            {
                // create object to the todo clas and store the query inside of it
                Todo deleteTodo = (from TodoRecords in db.Todoes
                                   where TodoRecords.TodoID == TodoID
                                   select TodoRecords).FirstOrDefault();

                // remove the selected todo from the db
                db.Todoes.Remove(deleteTodo);

                // save my changes back to the db
                db.SaveChanges();

                // refresh the grid
                this.TodoData();
            }

        }
    }
}