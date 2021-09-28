using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class Category
    {
        [ForeignKey("Users")]
        public int Id { get; set; }

        public string Name { get; set; }

       

    }
}
