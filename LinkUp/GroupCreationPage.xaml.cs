namespace LinkUp;

public partial class GroupCreationPage : ContentPage
{
	public GroupCreationPage()
	{
		InitializeComponent();
	}

	async void ButtonCreateGroup(object sender, EventArgs e)
	{
		await DisplayAlert("Title", "message", "olay");
	}
}