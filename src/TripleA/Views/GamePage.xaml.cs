using System.Collections.ObjectModel;
using TripleA.Model;
using TripleA.ViewModel;

namespace TripleA.Views;

public partial class GamePage : ContentPage
{
    public GamePage()
    {
        InitializeComponent();
        BindingContext = new GamePageViewModel();
    }
}