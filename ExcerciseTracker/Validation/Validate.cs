using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTracker.Validation
{
    public class Validate
    {
        public (bool, int) ValidateMenuOption(string? option)
        {
            if (!int.TryParse(option, out int result))
            {
                Console.WriteLine("Wrong input!");
                return (false,-1);
            }

            return (true,result);
        }

        public DateTime ValidateTime(string? input)
        {
            if (DateTime.TryParse(input, CultureInfo.CurrentCulture, DateTimeStyles.None, out var timeResult))
                return timeResult;

            return DateTime.Now;
        }
    }
}
