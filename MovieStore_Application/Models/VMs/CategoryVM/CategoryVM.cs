using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.VMs.CategoryVM
{
    public class CategoryVM
    {
        public int? Id { get; set; }

        public string?  Name { get; set; }

        public string? Description { get; set; }
    }
}
