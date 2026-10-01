namespace CPE4_SoftDev3_2627_1stSem_Tolentino
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "CPE4_SoftDev3_2627_1stSem_Tolentino" };
        }
    }
}
