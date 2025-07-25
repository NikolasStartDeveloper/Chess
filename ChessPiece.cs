using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Chess
{
    public class ChessPiece
    {
        // Свойства
        public Texture2D Texture { get; private set; }
        public Vector2 Position { get;  set; }
        public PieceType Type { get; private set; }
        public PieceColor Color { get; private set; }

        // Конструктор
        public ChessPiece(Texture2D texture, Vector2 position, PieceType type, PieceColor color )
        {
            SetTexture(texture);
            SetPosition(position);
            Type = type;
            Color = color;
        }

        // Метод для установки текстуры
        public void SetTexture(Texture2D texture)
        {
            Texture = texture ?? throw new ArgumentNullException(nameof(texture));
        }

        // Метод для установки позиции
        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        // Метод для отрисовки
        public  virtual void Draw(SpriteBatch spriteBatch)
        {
            int cellSize = 64;
            int pieceSize = 50;
            // Указываем размер прямоугольника для отрисовки (например, 50x50)
            Rectangle destinationRect = new Rectangle(
                (int)Position.X + (cellSize - pieceSize) / 2, // Центрирование по горизонтали
                (int)Position.Y + (cellSize- pieceSize) / 2, // Центрирование по вертикали
                pieceSize, // Ширина спрайта
                pieceSize  // Высота спрайта
            );

            SpriteEffects effects = Color == PieceColor.Black
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
    }

    // Перечисления для типа и цвета фигуры
    public enum PieceType { Pawn, Rook, Knight, Bishop, Queen, King }
    public enum PieceColor { White, Black }
}