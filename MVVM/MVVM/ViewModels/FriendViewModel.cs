using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MVVM.Models;

namespace MVVM.ViewModels
{
    public class FriendViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        FriendsListViewModel lvm;
        public Friend Friend { get; set; }
        public FriendViewModel()
        {
            Friend= new Friend();
        }
        public FriendsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value) 
                {
                    lvm = value; 
                    OnPropertyChanged("ListViewModel"); 
                }
            }
        }
        public string Name
        {
            get { return Friend.Name; } 
            set { if (Friend.Name != value) { Friend.Name = value; OnPropertyChanged("Name"); } }
        }
        public string Email
        {
            get { return Friend.Email; }
            set { if (Friend.Email != value) { Friend.Email = value; OnPropertyChanged("Email"); } }
        }
        public string Phone
        {
            get { return Friend.Phone; }
            set { if (Friend.Phone != value) { Friend.Phone = value; OnPropertyChanged("Phone"); } }
        }
        public string Country
        {
            get { return Friend.Country; }
            set { if (Friend.Country != value) { Friend.Country = value; OnPropertyChanged("Country"); } }
        }
        public string Address
        {
            get { return Friend.Address; }
            set { if (Friend.Address != value) { Friend.Address = value; OnPropertyChanged("Address"); } }
        }
        public string Sugu
        {
            get { return Friend.Sugu; }
            set { if (Friend.Sugu != value) { Friend.Sugu = value; OnPropertyChanged("Sugu"); } }
        }
        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim()))) ||
                    (!string.IsNullOrEmpty(Phone.Trim())) ||
                    (!string.IsNullOrEmpty(Email.Trim())) ||
                    (!string.IsNullOrEmpty(Country.Trim())) ||
                    (!string.IsNullOrEmpty(Address.Trim()));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
