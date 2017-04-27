using System;

namespace SodukoSolver.Engine
{
    public class Cell : ICloneable
    {

        public int Id { get; set; }
        public bool IsSet { get; private set; }
        public string PossibleValues { get; set; }

        private int cellValue;

        public int Value
        {
            get { return cellValue; }
            set {
                cellValue = value;
                if (value > 0)
                {
                    IsSet = true;
                    PossibleValues = "";
                }
                else
                {
                    IsSet = false;
                    PossibleValues = "123456789";
                }
            }
        }


        public Cell()
        {
            IsSet = false;
            PossibleValues = "123456789";
            Value = 0;
        }

        public object Clone()
        {
            Cell clone = new Cell { Id = this.Id, Value = this.Value, PossibleValues = this.PossibleValues };
            return clone;
        }
    }
}