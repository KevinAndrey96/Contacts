using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string documentType { get; set; }
        public string documentNumber { get; set; }
        public string phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string password { get; set; }
    }
}
