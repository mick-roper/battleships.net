﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class ConsoleInputHandler : IInputHandler
    {
        public string ReadInput() => Console.ReadLine();
    }
}
