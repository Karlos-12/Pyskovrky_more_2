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

            game = Load();

            display();
        }

        public void display()
        {
            int x = disx;
            int y = disy;
            fullfield cnt = new fullfield(cntx, cnty, value.X);

            displaybox.RowDefinitions.Clear();
            displaybox.ColumnDefinitions.Clear();

            for(int k = (y*2); k >= 0; k--)
            {
                displaybox.RowDefinitions.Add(new RowDefinition());
            }
            for(int l = (x*2); l >= 0; l--)
            {
                displaybox.ColumnDefinitions.Add(new ColumnDefinition());
            }

            fullfield[,] field = game.fieldalize(cnt, x, y);
            for(int i = (y*2); i >= 0; i--)
            {
                for(int j = (x*2); j >= 0; j--)
                {
                    if (field[i, j] == null)
                    {
                        //gen empty field element
                        Button empty = new Button()
                        {
                            Margin = new Thickness(0,0,0,0),
                            Background = new SolidColorBrush(Colors.LightGray),
                            Tag = new int[] {i, j}
                        };

                        empty.Click += place;

                        Grid.SetRow(empty, i);
                        Grid.SetColumn(empty, j);
                        displaybox.Children.Add(empty);
                    }
                    else
                    {
                        //gen full field element
                        Button full = new Button()
                        {
                            Margin = new Thickness(0, 0, 0, 0),
                            Tag = field[i, j]
                        };

                        if (field[i, j].val == value.X)
                        {
                            full.Background = new SolidColorBrush(Colors.Red);
                            full.Content = "X";
                        }
                        else
                        {
                            full.Background = new SolidColorBrush(Colors.Blue);
                            full.Content = "O";
                        }

                        Grid.SetRow(full, i);
                        Grid.SetColumn(full, j);
                        displaybox.Children.Add(full);
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cntx--;
            display();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cntx++;
            display();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            cnty--;
            display();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            cnty++;
            display();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(game.save());
            File.WriteAllText("resources\\Save.txt", output);
        }

        private Game Load()
        {
            string input = File.ReadAllText("resources\\Save.txt");
            if (input == "" || input == null)
            {
                return new Game(null, value.X, this);
            }
            else
            {
                SavedGame temp = JsonConvert.DeserializeObject<SavedGame>(input);
                return new Game(temp.field_list, temp.turn, this);
            }
        }

        private void place(object sender, RoutedEventArgs e)
        {
            Button send = sender as Button;
            int[] pcords = send.Tag as int[];

            int py = pcords[0];
            int px = pcords[1];

            int ry = cnty - disy + py;
            int rx = cntx - disx + px;

            game.add_field(new fullfield(rx, ry, game.round));
            display();
        }

    }
}
