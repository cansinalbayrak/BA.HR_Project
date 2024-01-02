using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Domain.Entities
{
    public enum DayOffType
    {
        AnnualDayOff = 0,                 // YillikIzin,
        WeeklyDayOff=1,                   // HaftaTatili,
        MaternityDayOff = 2,              // DogumIzni,
        PregnancyCheckupDayOff = 3,       // GebelikKontrolIzni,
        BreastfeedingDayOff = 4,          // SutIzni,
        PaternityDayOff = 5,              // BabalikIzni,
        BereavementDayOff = 6,            // OlumIzni,
        JobSearchDayOff = 7,              // YeniIsAramaIzni,
        MarriageDayOff = 8,               // EvlilikIzni,
        ExcuseDayOff = 9,                 // MazeretIzni,
        AccompanyingDayOff = 10,          // RefakatIzni
        SoldierLeave =11,

    }
}
