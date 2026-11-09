using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterApp.Models
{
    public class Counter
    {
        public string Filename { get; set; }
        public string? Name {  get; set; }
        public int Count { get; set; }
        public DateTime CreationTime { get; set; }
        public string CounterState => "Stan licznika";
        public string ReturnToAllCountersText => "Powrót";
    }
}
