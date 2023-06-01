using app1.Models;
using CV23.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace app1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MatrixViewModel matrixViewModel;

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


        private List<Button> selecedButton;

        public MainWindow()
        {
            InitializeComponent();
            matrixViewModel = new MatrixViewModel();
            DataContext = matrixViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            matrixViewModel.OnButtonClick(sender);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            matrixViewModel.btnCheck_Click();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MatrixModel matrixModel = new MatrixModel(level1);
            matrixViewModel.start(level1Resut, matrixModel);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MatrixModel matrixModel = new MatrixModel(level2);
            matrixViewModel.start(level2Resut, matrixModel);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MatrixModel matrixModel = new MatrixModel(level3);
            matrixViewModel.start(level3Resut, matrixModel);
        }
    }
}
