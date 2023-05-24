using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab_2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateClick(object sender, EventArgs e)
        {
            var start = new DateTime(startDatePicker.Date.Year, startDatePicker.Date.Month, startDatePicker.Date.Day, startTimePicker.Time.Hours, startTimePicker.Time.Minutes, 0);
            var end = new DateTime(endDatePicker.Date.Year, endDatePicker.Date.Month, endDatePicker.Date.Day, endTimePicker.Time.Hours, endTimePicker.Time.Minutes, 0);
            var difference = end - start;

            int years = (int)(difference.Days / 365.25);
            int months = (int)((difference.Days % 365.25) / 30.44);
            int days = difference.Days % 30;
            int hours = difference.Hours;
            int minutes = difference.Minutes;

            string result = "";
            if (years > 0)
                result += years.ToString() + " " + GetDeclension(years, "год", "года", "лет");

            if (months > 0)
                result += months.ToString() + " " + GetDeclension(months, "месяц", "месяца", "месяцев");

            if (days > 0)
                result += days.ToString() + " " + GetDeclension(days, "день", "дня", "дней");

            if (hours > 0)
                result += hours.ToString() + " " + GetDeclension(hours, "час", "часа", "часов");

            if (minutes > 0)
                result += minutes.ToString() + " " + GetDeclension(hours, "минута", "минуты", "минут");


            if (result == "")
                resultLabel.Text = "Разницы между датами нет";
            else
                resultLabel.Text = "Разница между датами: " + result;
        }

        private string GetDeclension(int value, string singular, string singularGenitive, string plural)
        {
            if (value % 10 == 1 && value % 100 != 11)
            {
                return singular;
            }
            else if (value % 10 >= 2 && value % 10 <= 4 && (value % 100 < 10 || value % 100 >= 20))
            {
                return singularGenitive;
            }
            else
            {
                return plural;
            }
        }

        private void ClearClick(object sender, EventArgs e)
        {
            endDatePicker.Date = DateTime.Now;
            startDatePicker.Date = DateTime.Now;
            resultLabel.Text = "";
        }
    }
}
