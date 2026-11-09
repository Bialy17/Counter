using CounterApp.Models;

namespace CounterApp.Views;

public partial class AddCounterPage : ContentPage
{
    public AddCounterPage()
    {
        InitializeComponent();
    }
    
    private async void AddNewCounter(object sender, EventArgs e)
    {
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.counter.txt";

        var data = (AddCounter)BindingContext;
        string counterName = data.CounterName;
        int counterDefaultValue;
        if (!int.TryParse(data.CounterDefaultValue, out counterDefaultValue))
        {
            counterDefaultValue = 0;
        }
        else
        {
            counterDefaultValue = int.Parse(data.CounterDefaultValue);
        }

            Models.Counter newCounter = new();

        newCounter.Name = counterName;
        newCounter.Count = counterDefaultValue;

        File.WriteAllText(Path.Combine(appDataPath, randomFileName), (newCounter.Name + ";" + newCounter.Count));

        await Shell.Current.GoToAsync("..");
    }
}