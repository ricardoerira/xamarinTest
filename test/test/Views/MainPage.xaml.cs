using System;
using System.Collections.Generic;
using test.Data;
using Xamarin.Forms;

namespace test.Views
{
    public partial class MainPage : ContentPage
    {
        RepositoryList data;

        async  void  Handle_Clicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;

            if (button.AutomationId== "btn_show_flights"){
                await Navigation.PushAsync(new ShowFlightsPage(data));

                
            }
            if (button.AutomationId == "btn_books_flights")
            {
                await Navigation.PushAsync(new BookFlights(data));

            }
            if (button.AutomationId == "btn_books_by_client")
            {
                await Navigation.PushAsync(new BookbyClient(data));

            }

        }

        public MainPage()
        {
            InitializeComponent();

            data = new RepositoryList();


        }
    }
}
