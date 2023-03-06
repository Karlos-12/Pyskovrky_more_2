using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
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
        Game game;

        int cntx = 3;
        int cnty = 3;

        int disx = 5;
        int disy = 3;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game(null, value.X);
            for(int i = 1; i < 6; i++)
            {
                game.add_field(new fullfield(2, i, value.X));
                game.add_field(new fullfield(5, i, value.Y));
            }

            display();
        }

        public void display()
        {
            int x = disx;
            int y = disy;
            fullfield cnt = new fullfield(cntx, cnty, value.X);

            fullfield[,] field = game.fieldalize(cnt, x, y);
            _out.Text = "";
            for(int i = (y*2); i >= 0; i--)
            {
                for(int j = (x*2); j >= 0; j--)
                {
                    if (field[i, j] == null)
                    {
                        _out.Text += " _ ";
                        if (j == 0)
                        {
                            _out.Text += "\n";
                        }
                    }
                    else
                    {
                        _out.Text += " " + field[i, j].val.ToString() + " ";
                        if (j == 0)
                        {
                            _out.Text += "\n";
                        }
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cntx++;
            display();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cntx--;
            display();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            cnty++;
            display();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            cnty--;
            display();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(game.save());
            File.WriteAllText("resources\\Save.txt", output);
        }
    }
}
