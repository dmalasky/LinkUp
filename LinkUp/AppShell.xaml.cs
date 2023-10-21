namespace LinkUp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            
            Routing.RegisterRoute("NewPage2", typeof(NewPage2));

            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
    }
}