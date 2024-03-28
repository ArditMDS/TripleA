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
    }
    private void OnTeamSelected(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedTeam = (Team)picker.SelectedItem;
    }

}