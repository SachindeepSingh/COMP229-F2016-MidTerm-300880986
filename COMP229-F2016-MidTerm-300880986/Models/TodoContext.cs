namespace COMP229_F2016_MidTerm_300880986.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TodoContext : DbContext
    {
        public TodoContext()
            : base("name=TodoConnection")
        {
        }

        public virtual DbSet<Todo> Todoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .Property(e => e.TodoDescription)
                .IsFixedLength();
        }
    }
}
