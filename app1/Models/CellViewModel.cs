using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace app1.Models
{
    public class CellViewModel : INotifyPropertyChanged
    {
        public bool isEnable;
        public Brush background;
        public String Value { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged(nameof(IsEnable));
            }
        }
        public Brush Background
        {
            get
            {
                return background;
            }

            set { background = value; OnPropertyChanged(nameof(Background)); }
        }
        public ICommand ButtonClickCommand { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public CellViewModel Tag { get { return this; } }

        public CellViewModel(string value, int width, int height, bool isEnable, Brush background, int x, int y)
        {
            Value = value;
            Width = width;
            Height = height;
            IsEnable = isEnable;
            Background = background;
            X = x;
            Y = y;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
