using TripleA.Model;
using TripleA.ViewModel;

namespace TripleA.Views;

public partial class PlayerPage : ContentPage
{
	public PlayerPage()
	{
		InitializeComponent();
        BindingContext = new PlayerViewModel();
    }
    private void OnTeamSelected(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedTeam = (Team)picker.SelectedItem;
    }

}