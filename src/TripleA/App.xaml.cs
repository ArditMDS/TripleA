using TripleA.Managers;
using TripleA.ViewModel;

namespace TripleA
{
    public partial class App : Application
    {
        public static PlayerManager PlayerManagerInstance { get; private set; }
        public static GamePageViewModel GamePageViewModelInstance { get; private set; }
        public static PlayerViewModel PlayerViewModelInstance { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            PlayerManagerInstance = new PlayerManager();
            GamePageViewModelInstance = new GamePageViewModel(PlayerManagerInstance);
            PlayerViewModelInstance = new PlayerViewModel(PlayerManagerInstance);
        }

    }
}
