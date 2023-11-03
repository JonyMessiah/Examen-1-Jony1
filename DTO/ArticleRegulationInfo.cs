using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class ArticleRegulationInfo
    {
        /* Clase para modelar los datos del API central
         * Estos son los datos que me devuelte el  API de Regulacion
            {
              "isbn": "2023-9-9124-7-19572",
              "issn": "4298-3",
              "insPectNbr": "668144"
            }
        */
        public string ISBN { get; set; }
        public string ISSN { get; set; }
        public string InspectNbr { get; set; }
    }
}
