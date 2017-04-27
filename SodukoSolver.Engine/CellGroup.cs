using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Engine
{
    public class CellGroup
    {
        public Cell[] Cells { get; set; }

        public CellGroup()
        {
            this.Cells = new Cell[9];
        }

        public void SetPossibleValues()
        {
            string usedValues = "";
            foreach(Cell c in this.Cells)
            {
                if(c.Value > 0)
                {
                    usedValues += c.Value.ToString();
                }
            }


            foreach (Cell c in this.Cells)
                if (c.Value == 0) c.PossibleValues = removeUsedValues(c.PossibleValues, usedValues);

        }

        private string removeUsedValues(string possibleValues, string usedValues)
        {
            for(int i=0; i< usedValues.Length; i++)
            {
                string val = usedValues.Substring(i, 1);
                int place = possibleValues.IndexOf(val);
                if ( place> -1)
                {
                    possibleValues= possibleValues.Remove(place, 1);
                }
            }
            return possibleValues;
        }

    }
}
