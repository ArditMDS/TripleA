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

        _playerManager = new PlayerManager();
        BindingContext = new PlayerViewModel(_playerManager);
    }
    private void OnTeamSelected(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedTeam = (Team)picker.SelectedItem;
    }

}