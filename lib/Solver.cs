using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Security.Principal;

namespace nQueens.lib
{
  /// <summary>
  /// Data representation board = [1, 2, 3, etc...] where each column of N will note the location of
  /// the queen in that column.
  /// 
  /// Every solution to the N queens problem must be a permutation of the numbers [0..N-1]
  /// 
  /// will check the board from left-to-right
  /// </summary>

  public class Solver
  {
    public int N { get; private set; }
    private List<Board> _solutions;
    private readonly double _totalPermutations;


    public Solver(int n)
    {
      N = n;
      _solutions = new List<Board>();
      _totalPermutations = MathNet.Numerics.Combinatorics.Permutations(n);
    }

    public List<Board> Solve(bool uniqueSolutionsOnly = true)
    {
      var board = InitializeBoard();
      var tries = 1;

      do
      {
        if (uniqueSolutionsOnly)
        {
          if (IsAUniqueSolution(board)) _solutions.Add(board);
        }
        else
        {
          if (IsASolution(board)) _solutions.Add(board);
        }

        board = GetNextBoard(board);
        tries++;
      } while (board != null);

      return _solutions;
    }

    private static Board GetNextBoard(Board board)
    {
      var boardPieces = board.ToIntArray();
      var nextPerm = PermutationCalculator<int>.GetNextPermutation(boardPieces);

      return nextPerm == null
        ? null
        : new Board(nextPerm.ToArray());
    }

    private bool IsAUniqueSolution(Board board)
    {
      if (!IsASolution(board)) return false;

      return IsUnique(board);
    }

    private bool IsASolution(Board board)
    {
      var clashChecker = new BoardClashChecker();
      if (clashChecker.Execute(board)) return false;

      return true;
    }

    private  bool IsUnique(Board board)
    {
      if (IsAlreadySolution(board)) return false;

      var rotator = new BoardTransformer();

      var copy = rotator.ReflectOverXAxis(board);
      if (IsAlreadySolution(copy)) return false;

      copy = rotator.ReflectOverYAxis(board);
      if (IsAlreadySolution(copy)) return false;

      copy = rotator.ReflectOverYEqualsX(board);
      if (IsAlreadySolution(copy)) return false;

      copy = rotator.ReflectOverYEqualsMinusX(board);
      if (IsAlreadySolution(copy)) return false;

      copy = rotator.Rotate90Degrees(board);
      if (IsAlreadySolution(copy)) return false;

      copy = rotator.Rotate180Degrees(board);
      if (IsAlreadySolution(copy)) return false;

      copy = rotator.Rotate270Degrees(board);
      if (IsAlreadySolution(copy)) return false;
      
      return true;
    }

    private bool IsAlreadySolution(Board potantialSolution)
    {
      return _solutions.Any(solution => AreEqualBoards(potantialSolution, solution));
    }

    private static bool AreEqualBoards(Board left, Board right)
    {
      if (left.N != right.N) return false;

      for (var i = 0; i < left.N; i++)
      {
        if (left[i] != right[i]) return false;
      }

      return true;
    }

    private static Board Shuffle(Board board)
    {
      var shuffler = new ArrayShuffler();
      var shuffledBoard = new Board(shuffler.Execute(board.ToIntArray()));
      return shuffledBoard;
    }

    private Board InitializeBoard()
    {
      var board = new Board(N);
      for (int i = 0; i < N; i++)
        board[i] = i;
      return board;
    }
  }
}
