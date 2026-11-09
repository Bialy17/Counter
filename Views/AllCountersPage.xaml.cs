namespace CounterApp.Views;

public partial class AllCountersPage : ContentPage
{
    public AllCountersPage()
    {
        InitializeComponent();
        BindingContext = new Models.AllCounters();
    }

    protected override void OnAppearing()
    {
        ((Models.AllCounters)BindingContext).LoadCounters();
    }
    private async void Add_clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddCounterPage));
    }

    private async void countersCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var counter = (Models.Counter)e.CurrentSelection[0];
            await Shell.Current.GoToAsync($"{nameof(CounterPage)}?ItemId={counter.Filename}");
            CountersCollection.SelectedItem = null;
        }
    }
}