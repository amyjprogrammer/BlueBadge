using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.UI//had to rebuild..don't use bluebadge.console.  the console part was messing up console.readline or console.clear
{
    class Program
    {
        static void Main(string[] args)
        {
            BadgeUI ui = new BadgeUI();
            ui.Run();
        }
    }
}
