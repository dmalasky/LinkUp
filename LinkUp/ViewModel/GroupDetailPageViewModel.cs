

using CommunityToolkit.Mvvm.ComponentModel;

namespace LinkUp.ViewModel
{
    public partial class GroupDetailPageViewModel : ObservableObject
    {
        List<string> Options = new List<string>
        {
            "Option 1",
            "Option 2",
            "Option 3"
        };
}
}
