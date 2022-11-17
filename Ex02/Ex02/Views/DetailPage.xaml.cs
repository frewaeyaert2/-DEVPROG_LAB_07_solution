using Ex02.Models;
using Ex02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ex02.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public Area AreaContent { get; set; }
        public AreaData AreaDataContent { get; private set; }

        public DetailPage(Area area)
        {
            InitializeComponent();

            this.AreaContent = area;
            LoadData(area.Id);

            btnBack.Clicked += BtnBack_Clicked;
            btnQualityScores.Clicked += BtnQualityScores_Clicked;
        }

        private void BtnQualityScores_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScorePage(AreaContent));
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void LoadData(Guid id)
        {
            AreaDataContent = await QualityoflifeRepository.GetAreaDataAsync(id);
            imgArea.Source = AreaDataContent.ImageData.Mobile;
            lblContinent.Text = AreaDataContent.Continent;
            lblFullName.Text = AreaDataContent.FullName;
            lblMayor.Text = AreaDataContent.Mayor;
            lblName.Text = AreaDataContent.Name;
        }
    }
}