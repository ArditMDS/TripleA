using TripleA.Managers;
using TripleA.ViewModel;
using TripleA.ViewModels;

namespace TripleA
{
    public partial class App : Application
    {
        public static PlayerManager PlayerManagerInstance { get; private set; }
        public static GamePageViewModel GamePageViewModelInstance { get; private set; }
        public static PlayerViewModel PlayerViewModelInstance { get; private set; }
        public static EsportStatsViewModel EsportStatsViewModelInstance { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            PlayerManagerInstance = new PlayerManager();
            GamePageViewModelInstance = new GamePageViewModel(PlayerManagerInstance);
            PlayerViewModelInstance = new PlayerViewModel(PlayerManagerInstance);
            EsportStatsViewModelInstance = new EsportStatsViewModel(PlayerManagerInstance);
        }

    }
}
