using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02.Models
{
    public class QualityScore
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Score_out_of_10")]
        public double ScoreOutOf10 { get; set; }
        public string Color { get; set; }

        public int ScorePercentage { get { return (int) ScoreOutOf10 * 10; } }

        public override string ToString()
        {
            return string.Format("{0} : {1}%", Name, ScorePercentage);
        }
    }
}
