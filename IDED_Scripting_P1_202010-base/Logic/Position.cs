using System;

namespace IDED_Scripting_P1_202010_base.Logic
{
    public struct Position
    {
        public int x;
        public int y;

        public Position(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        /// <summary>
        /// Generates a Position with random values.
        /// </summary>
        /// <param name="random"></param>
        public Position(int random)
        {
            Random rX = new Random();
            Random rY = new Random();

            x = rX.Next();
            y = rY.Next();
        }
    }
}