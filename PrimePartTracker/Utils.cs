using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimePartTracker
{
    internal class Utils
    {
        public static bool TabIsOpen(string name)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            bool isOpen = OpenForms.Any(q => q.Name == name);
            return isOpen;
        }
    }
}
