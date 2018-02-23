using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Entities
{
    struct Coordinate
    {
        public Coordinate(char x, char y)
        {
            X = x;
            Y = y;
        }

        public char X { get; set; }
        public char Y { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Coordinate)) return false;

            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            const int prime = 1000357;
            int n = prime;

            unchecked
            {
                n = (X * prime) + n;
                n = (Y * prime) + n;
            }

            return n;
        }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }
    }
}
