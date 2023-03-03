using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessBoard
    {
        public int Width { get; }
        public int Height { get; }
        public Figure[,] Board { get; set; }
        public ChessBoard(int width = 8, int height = 8)
        {
            Width = width;
            Height = height;
        }
        public void InitializeFigures()
        {
            Board = new Figure[Width, Height];
            string order = "RNBKQ";
            for(int i = 0; i < Width; ++i)
            {
                Board[1, i] = new Figure(FigureType.Pawn, FigureColor.White, (1, i));
                Board[Height - 2, i] = new Figure(FigureType.Pawn, FigureColor.Black, (Height - 2, i)); 
            }
            for (int i = 0; i < order.Length - 2; ++i)
            {
                Board[0, i] = new Figure((FigureType)order[i], FigureColor.White, (0, i));
                Board[Height - 1, i] = new Figure((FigureType)order[i], FigureColor.White, (Height - 1, i));
            }
        }
    }   
}
