using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Engine
{
    public static class Solver
    {

        public static SodukuBoard Solve(SodukuBoard board)
        {
            board.CheckSolved();
            if (board.IsSolved) return board;

            board = CalculatePossibleValues(board);
            Cell cell = SelectCellWithFewestPossibleValues(board);

            if (!cell.IsSet && cell.PossibleValues.Length == 0)
                return board;

            for(int i=0; i<cell.PossibleValues.Length; i++)
            {
                SodukuBoard child = (SodukuBoard)board.Clone();
                child.SetCell(cell.Id, int.Parse(cell.PossibleValues.Substring(i, 1)));
                child = Solve(child);
                if(child.CheckSolved())
                {
                    board = child.Clone() as SodukuBoard;
                    break;
                }
            }

            return board;


        }



        private static SodukuBoard CalculatePossibleValues(SodukuBoard board)
        {
            board = CalculatePossibleValuesForRows(board);
            board = CalculatePossibleValuesForColumns(board);
            board = CalculatePossibleValuesForGrids(board);
            return board;
        }

        private static SodukuBoard CalculatePossibleValuesForGrids(SodukuBoard board)
        {
            for (int i = 0; i < 9; i++)
            {
                CellGroup grid = board.GetGrid(i);
                grid.SetPossibleValues();
            }
            return board;
        }

        private static SodukuBoard CalculatePossibleValuesForColumns(SodukuBoard board)
        {
            for (int i = 0; i < 9; i++)
            {
                CellGroup column = board.GetColumn(i);
                column.SetPossibleValues();
            }
            return board;
        }

        private static SodukuBoard CalculatePossibleValuesForRows(SodukuBoard board)
        {
            for(int i=0; i < 9; i++)
            {
                CellGroup row = board.GetRow(i);
                row.SetPossibleValues();
            }
            return board;
        }

        private static Cell SelectCellWithFewestPossibleValues(SodukuBoard board)
        {
            IQueryable<Cell> ordered = board.Cells.AsQueryable()
                .Where(c => !c.IsSet)
                .OrderBy(c => c.PossibleValues.Length);

            return (Cell)ordered.First();
        }
    }
}
