using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watches
{
    public enum WatchType
    {
        Mechanical,
        Electronic,
    }

    public enum Descriptions
    {
        Mainspring, // 0   Mechanical
        WheelTrain, // 1  Mechanical
        Escapement, // 2  Mechanical
        KeylessWork, // 3  Mechanical
        BalanceWheel, // 4 for both
        CenterSeconds, // 5  Electronic
        ElectroMagnecital, // 6  Electronic
        TuningFork, // 7  Electronic
        Battery // 8  Electronic
    }

    public enum Brands
    {
        Rollex,
        Hubolt,
        Hamilton,
        Tissot
    }

    public enum AdditionalFunctions
    {
        Calendar,
        Navigation,
        Smart
    }

    public enum HumanSex
    {
        male,
        female
    }

    public enum Colours
    {
        Black,
        Blue,
        Brown,
        Red,
        White
    }
}
