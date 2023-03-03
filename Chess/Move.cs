using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum HorizontalDirection
    {
        Left = -1,
        None = 0,
        Right = 1,
    }
    public enum VerticalDirection
    {
        Down = -1,
        None = 0,
        Up = 1,
    }

    public class Move
    {
       
        public static Dictionary<FigureType, Action> FigureMoves;
        bool Attacking { get; set; }
        public void FindMoves()
        {
            //FigureMoves = new Dictionary<FigureType, Action<ChessBoard, (int row, int col)>>
            //{
            //    { FigureType.Pawn, FindPawnMoves },
            //    { FigureType.Rook, FindRookMoves },
            //    { FigureType.Knight, FindKnightMoves },
            //    { FigureType.Bishop, FindBishopMoves },
            //    { FigureType.Queen, FindQueenMoves },
            //    { FigureType.King, FindKingMoves }
            //};

        }
        public void FindPawnMoves(ChessBoard board, (int row, int col) position)
        {


        }
        public void FindRookMoves(ChessBoard board, (int row, int col) position) { }
        public void FindKnightMoves(ChessBoard board, (int row, int col) position) { }
        public void FindBishopMoves(ChessBoard board, (int row, int col) position) { }
        public void FindKingMoves(ChessBoard board, (int row, int col) position) { }
        public void FindQueenMoves(ChessBoard board, (int row, int col) position) { }


    }
}
