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

namespace Pyskovrky_more_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Game test = new Game(null, value.X);
            for(int i = 1; i < 6; i++)
            {
                test.add_field(new fullfield(2, i, value.X));
                test.add_field(new fullfield(5, i, value.Y));
            }

            fullfield[,] field = test.fieldalize(test.FieldList[3], 3, 3);

        }
    }
}
