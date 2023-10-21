namespace LinkUp;

public partial class TeamListPage : ContentPage
{
	public TeamListPage()
	{
        InitializeComponent();

		var teams = new List<Team>
        {
            new Team { Name = "Team 1" },
            new Team { Name = "Team 2" },
            new Team { Name = "Team 3" }
        };

        // Set the ItemsSource of the ListView to the list of teams
        listView.ItemsSource = teams;
    }

    private async void OnTeamTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Team selectedTeam)
        {
            // Navigate to a new page when a team is tapped
            await Navigation.PushAsync(new TeamDetailPage(selectedTeam));
        }

        // Deselect the tapped item
        ((ListView)sender).SelectedItem = null;
    }
}



public class Team
{
    public string Name { get; set; }
}