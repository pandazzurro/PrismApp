using Prism.Mvvm;
using PrismUnityApp1.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PrismUnityApp1.ViewModels
{
    public class UserPageViewModel : BindableBase
    {
        public string Username { get; set; }
        public DateTime DataNascita { get; set; }
        public string Email { get; set; }
        public ImageSource FotoProfilo { get; set; }
        public UserPageViewModel(FacebookUser user)
        {
            Username = user.name;
            DataNascita = user.birthday;
            Email = user.email;
            FotoProfilo = ImageSource.FromStream(() => new MemoryStream(user.profile_image));
        }
    }
}
