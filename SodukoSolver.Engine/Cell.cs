using System;
using System.ComponentModel;

namespace SodukoSolver.Engine
{
    public class Cell : ICloneable, INotifyPropertyChanged
    {

        public int Id { get; set; }
        public bool IsSet { get; private set; }
        public string PossibleValues { get; set; }

        private int cellValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnValueChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int Value
        {
            get { return cellValue; }
            set {
                if (value != cellValue)
                {
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
                    OnValueChanged("Value");
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