using TripleA.Managers;
using TripleA.Model;
using TripleA.ViewModel;

namespace TripleA.Views;

public partial class PlayerPage : ContentPage
{
    private PlayerManager _playerManager;
    public PlayerPage()
	{
		InitializeComponent();

        BindingContext = App.PlayerViewModelInstance;

        if (BindingContext is PlayerViewModel viewModel)
        {
            viewModel.ScrollToTopRequested += ViewModel_ScrollToTopRequested;
        }

    }

    private async void ViewModel_ScrollToTopRequested(object sender, EventArgs e)
    {
        // scroll vers le top
        await MainScrollView.ScrollToAsync(0, 0, true);
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is PlayerViewModel viewModel)
        {
            viewModel.ScrollToTopRequested -= ViewModel_ScrollToTopRequested;
        }
    }
    private void OnTeamSelected(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedTeam = (Team)picker.SelectedItem;
    }

}