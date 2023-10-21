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

            Items.Add(text);
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

        // links to detailpage when clicked
        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}"); // Works with DetailViewModel.cs 
        }
     
    }
}
