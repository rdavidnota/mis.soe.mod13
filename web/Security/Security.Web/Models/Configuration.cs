using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Web.Models
{
    public class Configuration
    {
        public int MinimumDigits { get; set; }
        public int MinimumLetters { get; set; }
        public int MinimumCapitalLetters { get; set; }
        public int MinimumSpecialCharacter { get; set; }
        public int MinimunLength { get; set; }
        public int MaximumDaysChanguePassword { get; set; }
    }
}
