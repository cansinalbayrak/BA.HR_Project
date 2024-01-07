using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Domain.Enums
{
    public enum DayOffType
    {
        AnnualDayOff = 0,                 // YillikIzin,
        MaternityDayOff = 2,              // DogumIzni,
        PaternityDayOff = 5,              // BabalikIzni,
        BereavementDayOff = 6,            // OlumIzni,
        JobSearchDayOff = 7,              // YeniIsAramaIzni,
        MarriageDayOff = 8,               // EvlilikIzni,
        ExcuseDayOff = 9,                 // MazeretIzni,
        SickDayOff = 10,          // RefakatIzni
        SoldierLeave = 11,

    }
}
