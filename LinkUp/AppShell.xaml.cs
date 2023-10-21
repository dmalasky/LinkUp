namespace LinkUp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            
            Routing.RegisterRoute(nameof(GroupCreationPage), typeof(GroupCreationPage));
           
            
        }
    }
}