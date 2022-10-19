using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bankomat.Models
{
    public class BanknoteDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BanknoteDetailID { get; set; }
        public int Banknote { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
    }
}