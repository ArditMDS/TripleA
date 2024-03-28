using TripleA.Managers;
using TripleA.ViewModel;

namespace TripleA
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            var playerManager = new PlayerManager();
            var viewModel = new GamePageViewModel(playerManager);
            this.DataContext = viewModel;
        }

        public GamePageViewModel DataContext { get; }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
