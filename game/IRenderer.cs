using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    interface IRenderer
    {
        void Draw(char c, int x, int y);
    }
}
