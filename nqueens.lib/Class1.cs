using System;

namespace nqueens.lib {
  public class SafeChecker { }

  /*
  Data representation board = [1, 2, 3, etc...] where each column of N will note the location of
  the queen in that column.
  
  Every solution to the N queens problem must be a permutation of the numbers [0..N-1]
  
  will check the board from left-to-right
  
  *** ALGORITHM ***
  1-Start in the leftmost column
  2-If all queens are placed return true
  3-Try all rows in the current column.  Do following for every tried row.
    a-If the queen can be placed safely in this row then mark this [row, column] as part of the solution and recursively check if placing queen here leads to a solution.
    b-If placing the queen in [row, column] leads to a solution then return true.
    c-If placing queen doesn't lead to a solution then umark this [row, column] (Backtrack) and go to step (a) to try other rows.
  4-If all rows have been tried and nothing worked, return false to trigger backtracking.
  *** END ALGORITHM ***
  */

  public class NQueensSolver {
  }
}