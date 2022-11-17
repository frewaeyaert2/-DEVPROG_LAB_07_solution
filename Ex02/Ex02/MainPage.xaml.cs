using Ex02.Models;
using Ex02.Repositories;
using Ex02.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ex02
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            lvwAreas.ItemsSource = await QualityoflifeRepository.GetAreasAsync();
            lvwAreas.ItemSelected += LvwAreaNames_ItemSelected;
        }

        private void LvwAreaNames_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvwAreas.SelectedItem != null)
            {
                Navigation.PushAsync(new DetailPage(lvwAreas.SelectedItem as Area));
                lvwAreas.SelectedItem = null;
            }
        }
    }
}

