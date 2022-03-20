using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    internal class Read
    {
        public event EventHandler<char> OnKeyPressed;

        public void Run()
        {
            char input = ' ';
            while (input != 'c' && input != 'с')
            {
                input = Console.ReadKey().KeyChar;

                OnKeyPressed?.Invoke(this, input);
            }
        }
    }
}
