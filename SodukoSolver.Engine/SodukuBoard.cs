using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Engine
{
    public class SodukuBoard :ICloneable
    {
        public Cell[] Cells { get; set; }

        private Dictionary<int, int> GridStartCells;

        public SodukuBoard()
        {
            this.Cells = new Cell[81];
            for(int i=0; i<81; i++)
            {
                this.Cells[i] = new Cell { Id = i };
            }

            GridStartCells = new Dictionary<int, int>();
            GridStartCells.Add(0, 0);
            GridStartCells.Add(1, 3);
            GridStartCells.Add(2, 6);
            GridStartCells.Add(3, 27);
            GridStartCells.Add(4, 30);
            GridStartCells.Add(5, 33);
            GridStartCells.Add(6, 54);
            GridStartCells.Add(7, 57);
            GridStartCells.Add(8, 60);

        }

        public void SetCell(int cellId, int value)
        {
            Cell c = this.Cells[cellId];
            c.Value = value;
        }

        public CellGroup GetRow(int rowNumber)
        {
            if (rowNumber < 0 || rowNumber > 8)
                throw new ArgumentOutOfRangeException("rowNumber", "rowNumber must be between 0 and 8");

            int firstCell = rowNumber * 9;

            CellGroup group = new CellGroup();
            for(int i=0; i < 9; i++)
            {
                group.Cells[i] = this.Cells[firstCell + i];
            }
            return group;
        }

        public CellGroup GetColumn(int columnNumber)
        {
            if (columnNumber < 0 || columnNumber > 8)
                throw new ArgumentOutOfRangeException("columnNumber", "columnNumber must be between 0 and 8");

            CellGroup group = new CellGroup();
            int currentCell = columnNumber;
            for (int i = 0; i < 9; i++)
            {
                group.Cells[i] = this.Cells[currentCell];
                currentCell += 9;
            }
            return group;
        }

        public CellGroup GetGrid(int gridNumber)
        {
            if (gridNumber < 0 || gridNumber > 8)
                throw new ArgumentOutOfRangeException("gridNumber", "gridNumber must be between 0 and 8");


            int currentCell = GridStartCells[gridNumber];

            CellGroup group = new CellGroup();
            int groupCell = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    group.Cells[groupCell] = this.Cells[currentCell];
                    groupCell++;
                    currentCell += 1;
                }
                currentCell += 6;
            }
            return group;
        }

        public bool IsSolved { get; private set; }

        public object Clone()
        {
            SodukuBoard clone = new SodukuBoard();
            clone.IsSolved = this.IsSolved;

            for (int i = 0; i < this.Cells.Length; i++)
            {
                clone.Cells[i] = Cells[i].Clone() as Cell;
            }
            return clone;
        }

        public bool CheckSolved()
        {
            int i = Cells.Where(c => !c.IsSet).Count();
            this.IsSolved = i == 0;
            return this.IsSolved;
        }
    }
}
