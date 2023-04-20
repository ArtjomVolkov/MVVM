using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendPage : ContentPage
    {
        public FriendViewModel ViewModel { get; private set; }
        public FriendPage(FriendViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }

        private async void sms_btn_Clicked(object sender, EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if(tel.Text == null || !tel.Text.StartsWith("+372"))
            {
                await DisplayAlert("Viga", "Sisesta telefoni", "Ok");
            }
            else if (sms.CanSendSms)
            {
                sms.SendSms(tel.Text, text.Text);
            }
        }

        private async void call_btn_Clicked(object sender, EventArgs e)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (tel.Text == null || !tel.Text.StartsWith("+372"))
            {
                await DisplayAlert("Viga", "Sisesta telefoni", "Ok");
            }
            else if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(tel.Text);
            }
        }
    }
}