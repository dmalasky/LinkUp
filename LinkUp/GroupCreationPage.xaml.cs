using LinkUp.ViewModel;

namespace LinkUp;

public partial class GroupCreationPage : ContentPage
{
	public GroupCreationPage()
	{
		InitializeComponent();
	}

	async void ButtonCreateGroup(object sender, EventArgs e)
	{
		//await DisplayAlert("Current Directory:", FileSystem.Current.AppDataDirectory, "done");
		//return;

		if (string.IsNullOrEmpty(gName.Text))
		{
			await DisplayAlert("Group creation error:", "Group name must not be blank", "Okay");
			return;
		}

		GroupList g = new();
		g.Add(new(gName.Text));

		string listStats = "Number of lists: " + g.Count.ToString();
		listStats += "\n";
		foreach (Group item in g)
		{
			listStats += "\n";
			listStats += "Group: " + item.name + "\n";
			listStats += "\tUID: " + item.uid + "\n";
		}

		await DisplayAlert("GroupList Stats:", listStats, "done");

		g.SaveAll();
	}
}