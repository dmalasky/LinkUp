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

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            Items.Add(text);
            // Add our item
            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string s)
        {
            if (Items.Contains(s)) 
            {
                Items.Remove(s);
            }
        }

        // Generates command for us
        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}"); // Works with DetailViewModel.cs 
        }
     
    }
}
