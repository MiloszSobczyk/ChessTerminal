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
            ModifyBoardString();
        }
        public void CreateChessBoard()
        {
            for(int i = 0; i < standardSize; ++i)
            {
                Board[1, i] = new Pawn((1, i), Board, 0);
                Board[standardSize - 2, i] = new Pawn((standardSize - 2, i), Board, 1);
            }
            for (int color = 0; color <= 1; ++color)
            {
                int row = color * (standardSize - 1);
                Board[row, 0] = new Rook((row, 0), Board, row);
                Board[row, 7] = new Rook((row, 7), Board, row);
                Board[row, 1] = new Knight((row, 1), Board, row);
                Board[row, 6] = new Knight((row, 6), Board, row);
                Board[row, 2] = new Bishop((row, 2), Board, row);
                Board[row, 5] = new Bishop((row, 5), Board, row);
                Board[row, 3] = new King((row, 3), Board, row);
                Board[row, 4] = new Queen((row, 4), Board, row);
            }
        }
        public void ModifyBoardString()
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
