using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM.ViewModels
{
    public class FriendsListViewModel
    {
        public ObservableCollection<FriendViewModel> Friends { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateFriendCommand { protected get; set; }
        public ICommand DeleteFriendCommand { protected get; set; }
        public ICommand SaveFriendCommand { protected get; set; }
        public ICommand BackCommand { protected get; set; }
        FriendViewModel selectedFriend;
        public INavigation Navigation { get; set; }

        public FriendsListViewModel()
        {
            Friends = new ObservableCollection<FriendViewModel>();
            CreateFriendCommand = new Command(CreateFriend);
            DeleteFriendCommand = new Command(DeleteFriend);
            SaveFriendCommand = new Command(SaveFriend);
            BackCommand = new Command(Back);
        }
        public FriendViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                if (selectedFriend != value) { FriendViewModel tempFriend = value; selectedFriend = null; OnPropertyChanged("SelectedFriend"); Navigation.PushAsync(new FriendPage(tempFriend)); }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private void CreateFriend()
        {
            Navigation.PushAsync(new FriendPage(new FriendViewModel() { listViewModel=}))
        }
    }
}
