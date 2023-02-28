using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessBoard
    {
        public Figure[,] Board { get; set; } // change later to protected
        char[,] boardString;
        int standardSize;
        int width;
        int height;
        public ChessBoard()
        {
            Board = new Figure[8, 8];
            standardSize = 8;
            width = 6 * standardSize + 1;
            height = 4 * standardSize + 1;
            boardString = new char[height, width];
            CreateChessBoard();
            CreateBoardString();
        }
        public void CreateChessBoard()
        {
            for(int i = 0; i < 8; ++i)
            {
                Board[1, i] = new Pawn((1, i), Board, 0);
                Board[6, i] = new Pawn((1, i), Board, 1);
            }

            Board[0, 0] = new Rook((0, 0), Board, 0);
            Board[0, 7] = new Rook((0, 7), Board, 0);
            Board[0, 1] = new Knight((0, 1), Board, 0);
            Board[0, 6] = new Knight((0, 6), Board, 0);
            Board[0, 2] = new Bishop((0, 2), Board, 0);
            Board[0, 5] = new Bishop((0, 5), Board, 0);
            Board[0, 3] = new King((0, 3), Board, 0);
            Board[0, 4] = new Queen((0, 4), Board, 0);

            Board[7, 0] = new Rook((7, 0), Board, 1);
            Board[7, 7] = new Rook((7, 7), Board, 1);
            Board[7, 1] = new Knight((7, 1), Board, 1);
            Board[7, 6] = new Knight((7, 6), Board, 1);
            Board[7, 2] = new Bishop((7, 2), Board, 1);
            Board[7, 5] = new Bishop((7, 5), Board, 1);
            Board[7, 4] = new Queen((7, 4), Board, 1);
            Board[7, 3] = new King((7, 3), Board, 1);
        }
        public void CreateBoardString()
        {
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    boardString[i, j] = ' ';
                }
            }
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j <= standardSize; ++j)
                {
                    boardString[i, 6 * j] = '|';
                }
            }
            for (int i = 0; i <= standardSize; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    boardString[4 * i, j] = '-';
                }
            }
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (Board[7 - i, j] != null)
                    {
                        boardString[4 * i + 2, 6 * j + 3] = Board[7 - i, j].Symbol;
                    }
                }
            }
        }
        public void PrintBoard((int, int) currentPos)
        {
            for(int i = 0; i < height; ++i)
            {
                for(int j = 0; j < width; ++j)
                {
                    Console.Write(boardString[i, j]);
                }
                Console.WriteLine();
            }

        }
        public void UpdatePositions()
        {
            ;
        }
    }
}
