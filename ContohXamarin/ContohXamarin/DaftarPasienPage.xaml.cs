﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContohXamarin.ViewModels;
using ContohXamarin.Services;
using ContohXamarin.Models;
using System.Collections.ObjectModel;

namespace ContohXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DaftarPasienPage : ContentPage
    {
        ObservableCollection<Pasien> listPasien = null;

        public DaftarPasienPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            PasienServices pasienService = new PasienServices();
            listPasien = new ObservableCollection<Pasien>(await pasienService.GetAllPasien());
            lvPasien.ItemsSource = listPasien;
        }

        private async void lvPasien_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var currPasien = (Pasien)e.Item;
            DetailPasienPage detailPasienPage = new DetailPasienPage();
            detailPasienPage.BindingContext = currPasien;
            await Navigation.PushAsync(detailPasienPage);
        }

        private async void ToolbarTambahPasien_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TambahPasienPage());
        }
    }
}