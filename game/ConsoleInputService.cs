using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public class ConsoleInputService : IInputService
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
