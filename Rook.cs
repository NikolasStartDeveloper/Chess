using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Rook : ChessPiece
    {
         List<Texture2D> whiteRookTexture;
         List<Texture2D> blackRookTexture;
        private const int cellSize = 64;
        private const int pieceSize = 50;

        public Rook(Texture2D texture, Vector2 position, PieceType type, PieceColor color) : base(texture, position, type, color)
        {
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            
           
            base.Draw(spriteBatch);
        }
    }
}
