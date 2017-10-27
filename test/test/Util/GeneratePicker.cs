using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace test
{
    public class GeneratePicker
    {
        public GeneratePicker()
        {
        }
        public static Picker PickerCreator(string title, List<string> listValues)
        {

            Picker picker = new Picker
            {
                Title = "Cities",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string value in listValues)
            {
                picker.Items.Add(value);
            }

            // Create BoxView for displaying picked Color

            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                }
                else
                {
                    string colorName = picker.Items[picker.SelectedIndex];
                }
            };

            // Accomodate iPhone status bar.
          //  this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.

            return picker;

        }

     
    }
}
