using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class Figure
    {
        public char Symbol { get; set; }
        public int Color { get; set; } // 0 - white, 1 - black
        protected (int, int) Position { get; set; }
        protected List<(int, int)>? Moves;
        protected Figure[,]? Board { get; set; }
        public override string ToString()
        {
            return Symbol.ToString();
        }
        public abstract void FindMoves();
        public abstract void Move();
    }
    public class Pawn : Figure
    {
        private bool MovedBy2 { get; set; }
        public Pawn((int, int) pos, Figure[,] board, int color)
        {
            Symbol = 'P';
            Color = color;
            Moves = new List<(int, int)>();
            MovedBy2 = false;
            Position = pos;
            Board = board;
        }
        public override void FindMoves() // add checkmate detection
        {
            if (Moves.Count > 0) return;
            int row = Position.Item1;
            int col = Position.Item2;
            int direction = Color == 0 ? 1 : -1;
            if(!MovedBy2 && Board[row + 2 * direction, col] == null && Board[row + direction, col] == null && row == 1 + Color * 5) // (Color == 0 && row == 1) || (Color == 1 && row == 6)
            {
                Moves.Add((row + 2 * direction, col));
            }
            if (Board[row + direction, col] == null)
                Moves.Add((row + direction, col));

            if (col != 0 && Board[row + direction, col - 1] != null && Board[row + direction, col - 1].Color == 1 - Color)
                Moves.Add((row + direction, col - 1));
            if (col != 7 && Board[row + direction, col + 1] != null && Board[row + direction, col + 1].Color == 1 - Color)
                Moves.Add((row + direction, col + 1));
            // add en passant
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }

    }
    public class Rook : Figure // add castling
    {
        private bool Moved { get; set; }
        public Rook((int, int) pos, Figure[,] board, int color)
        {
            Symbol = 'R';
            Color = color;
            Moves = new List<(int, int)>();
            Moved = false;
            Position = pos;
            Board = board;
        }
        public override void FindMoves()
        {
            if (Moves.Count > 0) return;
            int row = Position.Item1;
            int col = Position.Item2;
            for (int i = -1; i <= 1; i += 2)
            {
                int rowTemp = row;
                while ((rowTemp += i) >= 0 && rowTemp <= 7)
                {
                    if (Board[rowTemp, col] != null)
                    {
                        if(Board[rowTemp, col].Color == 1 -  Color) Moves.Add((rowTemp, col));
                        break;
                    }
                    Moves.Add((rowTemp, col));
                }
            }
            for (int j = -1; j <= 1; j += 2)
            {
                int colTemp = col;
                while ((colTemp += j) >= 0 && colTemp <= 7)
                {
                    if (Board[row, colTemp] != null)
                    {
                        if (Board[row, colTemp].Color == 1 - Color) Moves.Add((row, colTemp));
                        break;
                    }
                    Moves.Add((row, colTemp));
                }
            }
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
    public class Knight : Figure
    {
        public Knight((int, int) pos, Figure[,] board, int color)
        {
            Symbol = 'N';
            Color = color;
            Moves = new List<(int, int)>();
            Position = pos;
            Board = board;
        }
        public override void FindMoves() // Czy nie lepiej zaimplementować zmienną statyczną opisującą wszystkie możliwe zmiany pozycji L?
        {
            if (Moves.Count > 0) return;
            int row = Position.Item1;
            int col = Position.Item2;
            for(int i = -2; i <= 2; i += 4)
            {
                for(int j = -1; j <= 1; j += 2)
                {
                    int rowTemp = row + i;
                    int colTemp = col + j;
                    if(rowTemp >= 0 && rowTemp <= 7 && colTemp >= 0 && colTemp <= 7)
                    {
                        if (Board[rowTemp, colTemp] != null && Board[rowTemp, colTemp].Color == Color)
                        {
                            continue;
                        }
                        Moves.Add((rowTemp, colTemp));
                    }
                }
            }
            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = -2; j <= 2; j += 4)
                {
                    int rowTemp = row + i;
                    int colTemp = col + j;
                    if (rowTemp >= 0 && rowTemp <= 7 && colTemp >= 0 && colTemp <= 7)
                    {
                        if (Board[rowTemp, colTemp] != null && Board[rowTemp, colTemp].Color == Color)
                        {
                            continue;
                        }
                        Moves.Add((rowTemp, colTemp));
                    }
                }
            }
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
    public class Bishop : Figure
    {
        public Bishop((int, int) pos, Figure[,] board, int color)
        {
            Symbol = 'B';
            Color = color;
            Moves = new List<(int, int)>();
            Position = pos;
            Board = board;
        }
        public override void FindMoves()
        {
            if (Moves.Count > 0) return;
            int row = Position.Item1;
            int col = Position.Item2;
            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = -1; j <= 1; j += 2)
                {
                    int rowTemp = row;
                    int colTemp = col;
                    while ((rowTemp += i) >= 0 && rowTemp <= 7 && (colTemp += j) >= 0 && colTemp <= 7)
                    {
                        if (Board[rowTemp, colTemp] != null)
                        {
                            if (Board[rowTemp, colTemp].Color == 1 - Color)
                            {
                                Moves.Add((rowTemp, colTemp));
                            }
                            break;
                        }
                        Moves.Add((rowTemp, colTemp));
                    }
                }
            }
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
    public class Queen : Figure
    {
        public Queen((int, int) pos, Figure[,] board, int color)
        {
            Symbol = 'Q';
            Color = color;
            Moves = new List<(int, int)>();
            Position = pos;
            Board = board;
        }
        public override void FindMoves()
        {
            if (Moves.Count > 0) return;
            int row = Position.Item1;
            int col = Position.Item2;
            for (int i = -1; i <= 1; i += 2)
            {
                int rowTemp = row;
                while ((rowTemp += i) >= 0 && rowTemp <= 7)
                {
                    if (Board[rowTemp, col] != null)
                    {
                        if (Board[rowTemp, col].Color == 1 - Color) Moves.Add((rowTemp, col));
                        break;
                    }
                    Moves.Add((rowTemp, col));
                }
            }
            for (int j = -1; j <= 1; j += 2)
            {
                int colTemp = col;
                while ((colTemp += j) >= 0 && colTemp <= 7)
                {
                    if (Board[row, colTemp] != null)
                    {
                        if (Board[row, colTemp].Color == 1 - Color) Moves.Add((row, colTemp));
                        break;
                    }
                    Moves.Add((row, colTemp));
                }
            }
            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = -1; j <= 1; j += 2)
                {
                    int rowTemp = row;
                    int colTemp = col;
                    while ((rowTemp += i) >= 0 && rowTemp <= 7 && (colTemp += j) >= 0 && colTemp <= 7)
                    {
                        if (Board[rowTemp, colTemp] != null)
                        {
                            if (Board[rowTemp, colTemp].Color == 1 - Color)
                            {
                                Moves.Add((rowTemp, colTemp));
                            }
                            break;
                        }
                        Moves.Add((rowTemp, colTemp));
                    }
                }
            }
        }
        public override void Move()
        {
            
        }
    }
    public class King : Figure
    {
        public King((int, int) pos, Figure[,] board, int color)
        {
            Symbol = 'K';
            Color = color;
            Moves = new List<(int, int)>();
            Position = pos;
            Board = board;
        }
        public override void FindMoves()
        {
            if (Moves.Count > 0) return;
            int row = Position.Item1;
            int col = Position.Item2;
            for (int i = -1; i <= 1; ++i)
            {
                int rowTemp = row + i;
                if (rowTemp < 0 || rowTemp > 7) continue;
                for (int j = -1; j <= 1; ++j)
                {
                    int colTemp = col + j;
                    if (colTemp < 0 || colTemp > 7) continue;
                    if (Board[rowTemp, colTemp] != null && Board[rowTemp, colTemp].Color == Color) continue;
                    Moves.Add((rowTemp, colTemp));
                }
            }
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}

