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
    public partial class ScorePage : ContentPage
    {
        public Guid AreaId { get; private set; }

        public ScorePage(Area area)
        {
            InitializeComponent();

            lblName.Text = area.Name;
            LoadData(area.Id);

            btnBackToDetails.Clicked += BtnBackToDetails_Clicked;
            btnBackToMain.Clicked += BtnBackToMain_Clicked;
        }

        private void BtnBackToDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void BtnBackToMain_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private async void LoadData(Guid areaId)
        {
            AreaId = areaId;
            lvwScores.ItemsSource = await QualityoflifeRepository.GetQualityScoresAsync(areaId);
        }

        private void ScoreMinus_Clicked(object sender, EventArgs e)
        {
            QualityScore score = (sender as Button).BindingContext as QualityScore;
            UpdateScore(score, -1);
        }

        private void ScorePlus_Cicked(object sender, EventArgs e)
        {
            QualityScore score = (sender as Button).BindingContext as QualityScore;
            UpdateScore(score, 1);
        }

        private async void UpdateScore(QualityScore score, int delta)
        {
            score.ScoreOutOf10 += delta;
            await QualityoflifeRepository.UpdateQualityScoreAsync(score);
            LoadData(AreaId);
        }
    }
}