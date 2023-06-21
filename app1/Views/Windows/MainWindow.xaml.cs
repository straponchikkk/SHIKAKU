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
            matrixViewModel.start1();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            matrixViewModel.start2();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            matrixViewModel.start3();
        }
    }
}
