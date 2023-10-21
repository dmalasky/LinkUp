using LinkUp.ViewModel;

namespace LinkUp;

public partial class GroupCreationPage : ContentPage
{
	public GroupCreationPage()
	{
		InitializeComponent();

        string groupName = GroupName.Text;
        string members = Members.Text;
        string goal = Goal.Text;
        DateTime day = Day.Date;

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        

        // populate list of groups

        // IF all not blank go back to main
        await Shell.Current.GoToAsync("..");

        
    }

    // Inside GroupCreationPage.xaml.cs
    //private async void SubmitButton_Clicked(object sender, EventArgs e)
    //{
    //    string groupName = groupNameEntry.Text; // Replace with the actual Entry field's name

    //    MainViewModel.AddGroupName(groupName); // Add the group name to MainViewModel

    //    await Navigation.PopAsync(); // Navigate back to MainPage
    //}
}