namespace CounterApp.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class CounterPage : ContentPage
{
    public string ItemId
    {
        set { LoadCounter(value); }
    }

    public CounterPage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.counter.txt";

        LoadCounter(Path.Combine(appDataPath, randomFileName));
    }

    private void WriteCurrentCount(int counter)
    {
        CurrentCount.Text = counter.ToString();
    }

    private void LoadCounter(string fileName)
    {
        Models.Counter counterModel = new Models.Counter();
        counterModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            counterModel.Name = File.ReadAllText(fileName).Split(";")[0];
            counterModel.Count = int.Parse(File.ReadAllText(fileName).Split(";")[1]);
        }
        BindingContext = counterModel;

        if (BindingContext is Models.Counter counter)
        {
            WriteCurrentCount(counter.Count);
        }
    }

    private void DeincrementCounter(object sender, EventArgs e)
    {
        if (BindingContext is Models.Counter counter)
        {
            counter.Count--;
            WriteCurrentCount(counter.Count);
        }
        SaveCounter(sender, e);
    }

    private void IncrementCounter(object sender, EventArgs e)
    {
        if (BindingContext is Models.Counter counter)
        {
            counter.Count++;
            WriteCurrentCount(counter.Count);
        }
        SaveCounter(sender, e);
    }
    private void SaveCounter(object sender, EventArgs e)
    {
        if (BindingContext is Models.Counter counter)
        {
            File.WriteAllText(counter.Filename, (counter.Name + ";" + counter.Count));
        }
    }

    private async void ReturnToAllCounters(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}