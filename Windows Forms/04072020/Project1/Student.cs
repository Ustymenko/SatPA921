using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Student
    {
        public String PIB { get; set; }
        public DateTime BDay { get; set; }
        public double avg  { get; set; }

        public override string ToString()
        {
            return $"{PIB,-20} {BDay.ToShortDateString()} {avg:N2}";
        } 
    }
}
