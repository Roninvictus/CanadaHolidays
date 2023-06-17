using CanadaHolidaysChallenge.Core.Model;
using CanadaHolidaysChallenge.Core.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHolidaysChallenge.Core.ViewModel;

public partial class HolidayViewModel : BaseViewModel
{
    public ObservableCollection<Holiday> Holidays { get; } = new();
    HolidayService holidayService;
    public Command GetHolidaysCommand { get; set; }
    public HolidayViewModel(HolidayService holidayService)
    {
        Console.WriteLine("Holiday ViewModel is working");
        Title = "Canada Holiday";
        this.holidayService = holidayService;
        GetHolidaysCommand = new Command(async () => await GetHolidayAsync());
        GetHolidayAsync();
    }

  
    async Task GetHolidayAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var monkeys = await holidayService.GetMonkeys();

            if (Holidays.Count != 0)
                Holidays.Clear();

            foreach (var Holiday in Holidays)
                Holidays.Add(Holiday);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }
}
