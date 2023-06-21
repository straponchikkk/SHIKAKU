using app1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CV23.ViewModels.Base
{
    public class MatrixViewModel : INotifyPropertyChanged
    {
        private int[,] level1 = new int[,]
        {
            { 4, 0, 2, 0 },
            { 0, 0, 0, 2 },
            { 2, 0, 0, 0 },
            { 0, 2, 0, 4 }
        };

        private int[,] level1Resut = new int[,]
        {
            { 1, 1, 2, 2 },
            { 1, 1, 2, 2 },
            { 4, 4, 6, 6 },
            { 4, 4, 6, 6 }
        };

        private int[,] level2 = new int[,]
        {
            { 0, 0, 0, 2 },
            { 4, 0, 0, 4 },
            { 2, 0, 0, 0 },
        };

        private int[,] level2Resut = new int[,]
        {
            { 1, 1, 2, 2 },
            { 1, 1, 3, 3 },
            { 4, 4, 3, 3 },
        };

        private int[,] level3 = new int[,]
        {
            { 0, 0, 0, 5, 0, 0, 2, 0 },
            { 0, 0, 0, 6, 0, 0, 0, 0 },
            { 0, 0, 6, 0, 0, 0, 0, 0 },
            { 4, 0, 2, 0, 0, 4, 0, 6 },
            { 0, 0, 0, 0, 3, 0, 0, 3 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 10, 0, 0, 3, 0 },
            { 3, 0, 0, 0, 7, 0, 0, 0 },
        };

        private int[,] level3Resut = new int[,]
        {
            { 1, 1, 1, 1, 1, 2, 3, 3 },
            { 4, 4, 4, 5, 5, 2, 6, 6 },
            { 4, 4, 4, 5, 5, 2, 6, 6 },
            { 7, 7, 8, 5, 5, 2, 6, 6 },
            { 7, 7, 8, 9, 9, 9, 11, 10 },
            { 12, 13, 13, 13, 13, 13, 11, 10 },
            { 12, 13, 13, 13, 13, 13, 11, 10 },
            { 12, 14, 14, 14, 14, 14, 14, 14 },
        };

        private int[,] gameResult;

        public event PropertyChangedEventHandler PropertyChanged;
        public List<CellViewModel> selectedPosition = new List<CellViewModel>();
        public List<CellViewModel> closedCell = new List<CellViewModel>();
        private MatrixModel _matrixModel;
        ObservableCollection<CellViewModel> _cels;
        public ObservableCollection<CellViewModel> Cells
        {
            get { return _cels; }
            set 
            { 
                _cels = value;
                OnPropertyChanged(nameof(Cells));
            }
        }

        public void OnButtonClick(object sender)
        {
            var clickedButton = sender as Button;
            if (clickedButton != null)
            {
                CellViewModel cellViewModel = (clickedButton.Tag as CellViewModel);
                cellViewModel.IsEnable = false;
                selectedPosition.Add(cellViewModel);
            }
        }

        public MatrixViewModel()
        {
            Cells = new ObservableCollection<CellViewModel>();
        }

        public void start(int[,] gameResult, MatrixModel matrixModel)
        {
            this.gameResult= gameResult;
            _matrixModel = matrixModel;
            Cells.Clear();
            // Заполните коллекцию ячеек значениями из модели
            for (int row = 0; row < _matrixModel.Matrix.GetLength(0); row++)
            {
                for (int column = 0; column < _matrixModel.Matrix.GetLength(1); column++)
                {
                    Cells.Add(new CellViewModel(
                        _matrixModel.Matrix[row, column] == 0 ? "" : _matrixModel.Matrix[row, column].ToString(),
                        500 / _matrixModel.Matrix.GetLength(0) - 1,
                        500 / _matrixModel.Matrix.GetLength(1) - 1,
                        true,
                        new SolidColorBrush(Colors.LightGray),
                        row,
                        column));
                }
            }
        }

        public void btnCheck_Click()
        {
            int count = 0;
            int curCount = 0;
            int startNumber = 0;
            bool containsNumber = false;
            for (int i = 0; i < selectedPosition.Count; i++)
            {
                CellViewModel cellButton = selectedPosition[i];
                int row = cellButton.X;
                int col = cellButton.Y;

                if (count == 0)
                {
                    count = checkCount(gameResult[row, col]);
                    if (count == 0)
                        break;
                }
                if (startNumber == 0)
                    startNumber = gameResult[row, col];

                if (startNumber != gameResult[row, col])
                    break;

                if (_matrixModel.Matrix[row, col] != 0)
                {
                    containsNumber = true;
                    count = _matrixModel.Matrix[row, col];
                }

                curCount++;
            }

            if (count == curCount && count == selectedPosition.Count && containsNumber)
                stepTrue();
            else
                stepFalse();
        }

        private void IsGameEnd()
        {
            foreach (CellViewModel button in Cells)
            {
                if (IsBrushColorLightGray(button.Background))
                    return;
            }

            MessageBox.Show("Вы прошли уровень!");
        }

        public bool IsBrushColorLightGray(Brush brush)
        {
            if (brush is SolidColorBrush solidColorBrush)
            {
                Color color = solidColorBrush.Color;
                return color == Colors.LightGray;
            }
            return false;
        }

        private void stepTrue()
        {
            Random random = new Random();
            byte R = (byte)random.Next(0, 255);
            byte G = (byte)random.Next(0, 255);
            byte B = (byte)random.Next(0, 255);
            for (int i = 0; i < selectedPosition.Count; i++)
            {
                selectedPosition[i].Background = new SolidColorBrush(Color.FromRgb(R, G, B));
                selectedPosition[i].IsEnable = true;
            }
            selectedPosition.Clear();
            IsGameEnd();
        }

        private void stepFalse()
        {
            for (int i = 0; i < selectedPosition.Count; i++)
                selectedPosition[i].IsEnable = true;
            selectedPosition.Clear();
        }

        private int checkCount(int number)
        {
            int count = 0;
            for (int i = 0; i < gameResult.GetLength(0); i++)
            {
                for (int j = 0; j < gameResult.GetLength(1); j++)
                {
                    if (gameResult[i, j] == number)
                        count++;
                }
            }
            return count;
        }

        public void start1()
        {
            MatrixModel matrixModel = new MatrixModel(level1);
            start(level1Resut, matrixModel);
        }

        public void start2()
        {
            MatrixModel matrixModel = new MatrixModel(level2);
            start(level2Resut, matrixModel);
        }

        public void start3()
        {
            MatrixModel matrixModel = new MatrixModel(level3);
            start(level3Resut, matrixModel);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
