using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02.Models
{
    public class AreaData
    {
      
            public string Name { get; set; }
            public string FullName { get; set; }
            public string Mayor { get; set; }
            public string Continent { get; set; }
            public Imagedata ImageData { get; set; }

        
    }

    public class Imagedata
    {
        public string License { get; set; }
        public string Photographer { get; set; }
        public string Site { get; set; }
        public string Source { get; set; }
        public string Mobile { get; set; }
        public string Web { get; set; }
    }
}
