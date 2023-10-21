using LinkUp.ViewModel;

namespace LinkUp;

public partial class GroupDetailsPage : ContentPage
{
	public GroupDetailsPage()
	{
		InitializeComponent();
		BindingContext = new GroupDetailPageViewModel();
        
    }
}