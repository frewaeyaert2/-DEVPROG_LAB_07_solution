using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02.Models
{
    public class Area
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
