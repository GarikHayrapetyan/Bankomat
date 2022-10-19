using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bankomat.Models
{
    public class UserAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserAccountID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Balance { get; set; }

    }
}