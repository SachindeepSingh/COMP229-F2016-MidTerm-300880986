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

            // Get the student data
            this.GetTodoList();
        }
    }

    /// <summary>
    /// This method gets the student data from the DB
    /// </summary>
    private void GetTodoList()
    {
        // connect to EF DB
        using (TodoContext db = new TodoContext())
        {
            // query the Student Table using EF and LINQ
            var Students = (from allTodoList in db.Todo
                            select allTodoList);

            // bind the result to the Students GridView
            TodoListGridView.DataSource = Todo.ToList();
            TodoListGridView.DataBind();
        }
    }

    protected void TodoListGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {


        // store which row was clicked
        int selectedRow = e.RowIndex;

        // get the selected StudentID using the Grid's DataKey collection
        int StudentID = Convert.ToInt32(TodoListGridView.DataKeys[selectedRow].Values["TodoID"]);

        // use EF and LINQ to find the selected student in the DB and remove it
        using (TodoContext db = new TodoContext())
        {
            // create object ot the student clas and store the query inside of it
            TodoList deletedTodo = (from studentRecords in db.Todoes
                                      where studentRecords.StudentID == StudentID
                                      select studentRecords).FirstOrDefault();

            // remove the selected student from the db
            db.Todoes.Remove(deletedTodo);

            // save my changes back to the db
            db.SaveChanges();

            // refresh the grid
            this.GetTodoList();
        }


    }
}
}