using System;
using Chess;

ChessBoard board = new ChessBoard();

int x = 0;
int y = 3;
board.PrintBoard((x, y));
board.Board[x, y].FindMoves();
foreach(var move in board.Board[x, y].Moves)
{
    Console.WriteLine($"{move.Item1}, {move.Item2}");
}