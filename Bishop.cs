using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Bishop : ChessPiece
    {
        public Bishop(Texture2D texture, Vector2 position, PieceType type, PieceColor color) : base(texture, position, type, color)
        {
        }
    }
}
