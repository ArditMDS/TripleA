namespace TripleA.Views;
using TripleA.ViewModel;
using TripleA.ViewModels;

public partial class EsportStatsView : ContentPage
{
	public EsportStatsView()
	{
        InitializeComponent();
        var viewModel = new EsportStatsViewModel();
        this.BindingContext = viewModel;
    }
}