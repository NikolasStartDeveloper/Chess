using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Chess
{
    public class ChessGame : Game // ← Наследуемся от Game
    {
        private GraphicsDeviceManager _graphics;
        private ChessPiece _whitePawn;
        private SpriteBatch _spriteBatch;
        private Board _board;
        private Texture2D _whiteSquare, _blackSquare;
        private List<ChessPiece> _whitePawns = new List<ChessPiece>();
        private List<ChessPiece> _blackPawns = new List<ChessPiece>();
        private List<ChessPiece> whiteRookTexture = new List<ChessPiece>();
        private List<ChessPiece> blackRookTexture = new List<ChessPiece>();
        private List<ChessPiece> whiteKnightTexture = new List<ChessPiece>();
        private List<ChessPiece> blackKnightTexture = new List<ChessPiece>();
        private List<ChessPiece> whiteBishopTexture = new List<ChessPiece>();
        private List<ChessPiece> blackBishopTexture = new List<ChessPiece>();
        private List<ChessPiece> whiteQueenTexture = new List<ChessPiece>();
        private List<ChessPiece> blackQueenTexture = new List<ChessPiece>();
        private List<ChessPiece> whiteKingTexture = new List<ChessPiece>();
        private List<ChessPiece> blackKingTexture = new List<ChessPiece>();

        public ChessGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 8 * 64; // Размер под доску
            _graphics.PreferredBackBufferHeight = 8 * 64;
            _graphics.ApplyChanges();
            base.Initialize();
        }
        private ChessPiece whitePawn;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var pawnTexture = Content.Load<Texture2D>("wPawn");
            for (int x = 0; x < 8; x++)
            {
                _whitePawns.Add(new Pawn(pawnTexture, new Vector2(x * 64, 6 * 64), PieceColor.White));
            }
            var blackPawnTexture = Content.Load<Texture2D>("blackPawn");
            for (int y = 0; y < 8; y++)
            {
                _blackPawns.Add(new Pawn(blackPawnTexture, new Vector2(y * 64, 1 * 64), PieceColor.Black));
            }

            var rookTexture = Content.Load<Texture2D>("whiteRook");
            whiteRookTexture.Add(new Rook(rookTexture, new Vector2(0 * 64, 7 * 64), PieceType.Rook, PieceColor.White)); // a1
            whiteRookTexture.Add(new Rook(rookTexture, new Vector2(7 * 64, 7 * 64), PieceType.Rook, PieceColor.White)); // h1

            var blackRook = Content.Load<Texture2D>("blackRook");
            blackRookTexture.Add(new Rook(blackRook, new Vector2(0 * 64, 0 * 64), PieceType.Rook, PieceColor.Black)); // a8
            blackRookTexture.Add(new Rook(blackRook, new Vector2(7 * 64, 0 * 64), PieceType.Rook, PieceColor.Black)); // h8

            var whiteKnight = Content.Load<Texture2D>("whiteKnight");
            whiteKnightTexture.Add(new Knight(whiteKnight, new Vector2(1 * 64, 7 * 64), PieceType.Knight, PieceColor.White)); // b1
            whiteKnightTexture.Add(new Knight(whiteKnight, new Vector2(6 * 64, 7 * 64), PieceType.Knight, PieceColor.White)); // g1

            var blackKnight = Content.Load<Texture2D>("blackKnight");
            blackKnightTexture.Add(new Knight(blackKnight, new Vector2(1 * 64, 0 * 64), PieceType.Knight, PieceColor.Black)); // b8
            blackKnightTexture.Add(new Bishop(blackKnight, new Vector2(6 * 64, 0 * 64), PieceType.Knight, PieceColor.Black)); // g8

            var whiteBishop = Content.Load<Texture2D>("whiteBishop");
            whiteBishopTexture.Add(new Bishop(whiteBishop, new Vector2(2 * 64, 7 * 64), PieceType.Bishop, PieceColor.White)); // b8
            whiteBishopTexture.Add(new Bishop(whiteBishop, new Vector2(5 * 64, 7 * 64), PieceType.Bishop, PieceColor.White)); // g8

            var blackBishop = Content.Load<Texture2D>("blackBishop");
            blackBishopTexture.Add(new Bishop(blackBishop, new Vector2(2 * 64, 0 * 64), PieceType.Bishop, PieceColor.Black)); // b8
            blackBishopTexture.Add(new Bishop(blackBishop, new Vector2(5 * 64, 0 * 64), PieceType.Bishop, PieceColor.Black)); // g8

            var whiteQueen = Content.Load<Texture2D>("whiteQueen");
            whiteQueenTexture.Add(new Queen(whiteQueen, new Vector2(3 * 64, 7 * 64), PieceType.Queen, PieceColor.White)); // b8
                                      
            var blackQueen = Content.Load<Texture2D>("blackQueen");
            blackQueenTexture.Add(new Queen(blackQueen, new Vector2(3 * 64, 0 * 64), PieceType.Queen, PieceColor.Black)); // b8

            var whiteKing = Content.Load<Texture2D>("whiteKing");
            whiteKingTexture.Add(new King(whiteKing, new Vector2(4 * 64, 7 * 64), PieceType.King, PieceColor.White)); // b8

            var blackKing = Content.Load<Texture2D>("blackKing");
            blackKingTexture.Add(new King(blackKing, new Vector2(4 * 64, 0 * 64), PieceType.King, PieceColor.Black)); //
           
            //Chess Pieces textures
            
            
            //Board map textures
            _whiteSquare = new Texture2D(GraphicsDevice, 80, 80);
            Color[] whitePixels = new Color[80 * 80];
            Array.Fill(whitePixels, Color.White);
            _whiteSquare.SetData(whitePixels);

            _blackSquare = new Texture2D(GraphicsDevice, 80, 80);
            Color[] blackPixels = new Color[80 * 80];
            Array.Fill(blackPixels, Color.Gray);
            _blackSquare.SetData(blackPixels);

            _board = new Board(_whiteSquare, _blackSquare);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(
            sortMode: SpriteSortMode.Deferred,
            blendState: BlendState.AlphaBlend,
            samplerState: SamplerState.LinearClamp, // Линейная фильтрация
            depthStencilState: DepthStencilState.None,
            rasterizerState: RasterizerState.CullNone
            );
            _board.Draw(_spriteBatch);    // Сначала доска
            foreach (var pawn in _whitePawns)
            {
                pawn.Draw(_spriteBatch);
            }
            foreach (var pawn in _blackPawns)
            {
                pawn.Draw(_spriteBatch);
            }
            foreach (var rook in blackRookTexture)
            {
                rook.Draw(_spriteBatch);
            }
            foreach (var rook in whiteRookTexture)
            {
                rook.Draw(_spriteBatch);
            }
            foreach (var knight in whiteKnightTexture)
            {
                knight.Draw(_spriteBatch);
            }
            foreach (var knight in blackKnightTexture)
            {
                knight.Draw(_spriteBatch);
            }
            foreach (var bishop in whiteBishopTexture)
            {
                bishop.Draw(_spriteBatch);
            }
            foreach (var bishop in blackBishopTexture)
            {
                bishop?.Draw(_spriteBatch);
            }
            foreach(var queen in whiteQueenTexture)
            {
                queen.Draw(_spriteBatch);
            }
            foreach(var queen in blackQueenTexture)
            {
                queen.Draw(_spriteBatch);
            }
            foreach (var king in whiteKingTexture)
            {
                king.Draw(_spriteBatch);
            }
            foreach (var king in blackKingTexture)
            {
                king.Draw(_spriteBatch);
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}