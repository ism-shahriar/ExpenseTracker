using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManagerAPI.Models
{
    public class ExpenseCategoryDto
    {

        [Key]
        public int CategoryID { get; set; }
        [DisplayName("Category")]
        public string CategoryType { get; set; }
        [DisplayName("Details")]
        public string CategoryDetails { get; set; }
    }
}
