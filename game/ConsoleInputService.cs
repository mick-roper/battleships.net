using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public class ConsoleInputService : IInputService
    {
        public char ReadChar()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
