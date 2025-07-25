using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Chess
{
    public class Pawn : ChessPiece
    {
        public bool HasMoved { get; private set; }

        public Pawn(Texture2D texture, Vector2 position, PieceColor color)
            : base(texture, position, PieceType.Pawn, color)
        {
            HasMoved = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int cellSize = 64;
            int pieceSize = 50;

            Rectangle destinationRect = new Rectangle(
                (int)Position.X + (cellSize - pieceSize) / 2,
                (int)Position.Y + (cellSize - pieceSize) / 2,
                pieceSize,
                pieceSize
            );

            SpriteEffects effects = Color == Chess.PieceColor.Black
                ? SpriteEffects.FlipVertically
                : SpriteEffects.None;

            spriteBatch.Draw(
                Texture,
                destinationRect,
                null,
                Microsoft.Xna.Framework.Color.White,
                0f,
                Vector2.Zero,
                effects,
                0f
            );
        }

        public bool IsMoveValid(Vector2 newPosition, ChessPiece[,] boardPieces)
        {
            int direction = (Color == Chess.PieceColor.White) ? -1 : 1;
            Point current = Position.ToBoardCoordinates();
            Point target = newPosition.ToBoardCoordinates();

            // Ход на 1 клетку вперед
            if (target.X == current.X &&
                target.Y == current.Y + direction &&
                boardPieces[target.X, target.Y] == null)
            {
                return true;
            }

            // Первый ход на 2 клетки
            if (!HasMoved &&
                target.X == current.X &&
                target.Y == current.Y + 2 * direction &&
                boardPieces[target.X, target.Y] == null &&
                boardPieces[target.X, target.Y - direction] == null)
            {
                return true;
            }

            // Взятие по диагонали
            if (Math.Abs(target.X - current.X) == 1 &&
                target.Y == current.Y + direction &&
                boardPieces[target.X, target.Y] != null &&
                boardPieces[target.X, target.Y].Color != Color)
            {
                return true;
            }

            return false;
        }

        public void SetMoved()
        {
            HasMoved = true;
        }
    }
}