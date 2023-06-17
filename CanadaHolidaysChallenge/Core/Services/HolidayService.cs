using CanadaHolidaysChallenge.Core.Model;
using CanadaHolidaysChallenge.Core.ViewModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHolidaysChallenge.Core.Services;

public class HolidayService
{
    HttpClient httpClient;
    public HolidayService()
    {
        this.httpClient = new HttpClient();
    }

    List<Holiday> HolidayList;
    public async Task<List<Holiday>> GetMonkeys()
    {
        Console.WriteLine("Holiday Service is working");
        if (HolidayList?.Count > 0)
            return HolidayList;

        // api url
        var response = await httpClient.GetAsync("https://canada-holidays.ca/api/v1/holidays?year=2022&optional=false");
       
        if (response.IsSuccessStatusCode)
        {
            var rootHoliday = await response.Content.ReadFromJsonAsync<RootHoliday>();
            HolidayList= rootHoliday.holidays.ToList();
        }
        Console.WriteLine("Holiday List Size "+ HolidayList.Count.ToString());
    

        return HolidayList;
    }
}

