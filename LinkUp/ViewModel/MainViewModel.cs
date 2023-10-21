using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LinkUp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        
        public MainViewModel() 
        {
            items = new ObservableCollection<string>();

        }

        [ObservableProperty]
        ObservableCollection<string> items;
        
        // Takes user input
        [ObservableProperty]
        string text;

        // Adds a team/task
        [RelayCommand] // Generates command for us
        void Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            Items.Add(Text);
            // Add our item
            Text = string.Empty;
        }

        // Deletes the team/task
        [RelayCommand]
        void Delete(string s)
        {
            if (Items.Contains(s)) 
            {
                Items.Remove(s);
            }
        }

        
    
        // New method to add a group name
        public void AddGroupName(string groupName)
        {
            Items.Add(groupName);
        }

    }
}
