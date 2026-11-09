using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterApp.Models
{
    internal class AddCounter
    {
        public string? CounterName { get; set; }
        public string? CounterDefaultValue { get; set; }
        public string SetCounterName => "Podaj nazwę licznika:";
        public string SetCounterDefaultValue => "Podaj wartość początkową:";
    }
}
