namespace LinkUp;

public partial class GroupCreationPage : ContentPage
{
	public GroupCreationPage()
	{
		InitializeComponent();
	}

	async void ButtonCreateGroup(object sender, EventArgs e)
	{
		await DisplayAlert("title", "message", "okay");
	}
}