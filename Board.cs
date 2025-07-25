using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Board
    {
        private readonly Texture2D _whitechessSquare;
        private readonly Texture2D _blackchessSquare;

        private readonly Color colorSquare;

        private int BoardSize = 8;
        private int SquareSize = 64;

        public Board(Texture2D whiteSquare, Texture2D blackSquare)
        {
            _whitechessSquare = whiteSquare;
            _blackchessSquare = blackSquare;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Texture2D texture = (i + j) % 2 == 0 ? _whitechessSquare : _blackchessSquare;

                    Rectangle position = new Rectangle(i * SquareSize, j  * SquareSize, SquareSize,SquareSize);


                    spriteBatch.Draw(texture, position, Color.White);
                }
            }
        }



    }
}
