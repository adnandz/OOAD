using MenuMD.Models;
using MenuMD.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MenuMD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPageOld : Page
    {
        public Frame AppFrame { get { return this.frame; } }
        public MainPageOld()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Korisnik korisnik = null;

            if (e.Parameter != null)
            {
             korisnik=(Korisnik)e.Parameter;
            }
            
            var stavke = MeniStavkeListView.ItemsSource as List<MeniStavkeViewModel>;

            if (stavke == null && korisnik!=null && korisnik.UlogaKorisnika!=null)
            {
                stavke = new List<MeniStavkeViewModel>();

                var ulogeKorisnika = korisnik.UlogaKorisnika.ToList();

                foreach (var uloga in ulogeKorisnika) {
                    foreach (var ulogaMeniStavka in uloga.Uloga.UlogaMeniStavke) {
                        stavke.Add(MeniStavkeViewModel.SaMeniStavke(ulogaMeniStavka.MeniStavka));
                    }
                }
               
                MeniStavkeListView.ItemsSource = stavke;
            }

        }

        private void OsnovniGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {

        }

        private void MeniStavkeListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            
           var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var x = (MeniStavka)item.Content;
                if (x.Podstranica != null &&
                    x.Podstranica != this.AppFrame.CurrentSourcePageType)
                {
                    this.AppFrame.Navigate(x.Podstranica, null);
                }
            }
        }

        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
        }

        private void OnNavigatedToPage(object sender, NavigationEventArgs e)
        {
          
        }
    }
}
