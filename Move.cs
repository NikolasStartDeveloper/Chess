using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Chess
{
    public static class Move
    {
        public static Microsoft.Xna.Framework.Point ToBoardCoordinates(this Microsoft.Xna.Framework.Vector2 pixelPosition,int cellSize = 64)
        {
            return new Microsoft.Xna.Framework.Point((int)pixelPosition.X / cellSize,
                (int)pixelPosition.Y / cellSize);
        }
    }
}
