using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MenuMD.DataSource;
using Windows.UI.Popups;

namespace MenuMD
{
    
    public sealed partial class Login : Page
    {
        
        public Login()
        {
            this.InitializeComponent();

            //inicijalizacija data source
            var inicijalizacija= new DataSourceMenuMD();
        }
        //asinhrona metoda za provjeru prijave korisnika
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            var korisnickoIme = txtUsername.Text;
            var sifra = txtPassword.Password;

            var korisnik = DataSourceMenuMD.ProvjeraKorisnika(korisnickoIme, sifra);
            if (korisnik != null && korisnik.KorisnikId>0)
            {
                this.Frame.Navigate(typeof(MainPage), korisnik);
            }
            else
            {
                var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!","Neuspješna prijava");
                await dialog.ShowAsync();
            }

        }
    }
}
