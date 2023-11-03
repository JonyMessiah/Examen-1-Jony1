using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Author: BaseClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Charge { get; set; }
    }
}
