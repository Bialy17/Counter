using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterApp.Models
{
    internal class AllCounters
    {
        public ObservableCollection<Counter> Counters { get; set; } = new();

        public string CreateCounterText => "Utwórz licznik";


        public AllCounters() => LoadCounters();

        public void LoadCounters()
        {
            string appDataPath = FileSystem.AppDataDirectory;
            Counters.Clear();

            IEnumerable<Counter> counters = Directory.EnumerateFiles(appDataPath, "*.counter.txt").Select(filename => new Counter()
            {
                Filename = filename,
                Name = File.ReadAllText(filename).Split(";")[0],
                Count = int.Parse(File.ReadAllText(filename).Split(';')[1]),
                CreationTime = File.GetCreationTime(filename)
            }).OrderByDescending(x => x.CreationTime);
            foreach (Counter counter in counters)
            {
                Counters.Add(counter);
            }
        }
    }
}
