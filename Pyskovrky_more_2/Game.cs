using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pyskovrky_more_2
{
    internal class Game
    {
        public List<fullfield> FieldList;
        public value round;

        public Game(List<fullfield> fieldList, value round)
        {
            if (fieldList == null)
            {
                FieldList = new List<fullfield>();
            }
            else
            {
                FieldList = fieldList;
            }

            if (round == null)
            {
                this.round = value.X;
            }
            else
            {
                this.round = round;
            }


        }

        public void add_field(fullfield temp)
        {
            if (temp.val == round && FieldList.Exists(x => (x.y == temp.y) && (x.x == temp.x)))
            {
                FieldList.Add(temp);
                eval(temp);
            }
            else
            {
                MessageBox.Show("Tam teď ne!");
            }
        }

        public void eval(fullfield temp)
        {
            fullfield[,] area = new fullfield[9, 9];
            foreach(fullfield n in FieldList)
            {
                if(n.x > temp.x -4 && n.x < temp.x +4 && n.y > temp.y -4 && n.y < temp.y +4)
                {
                    int vxn = n.x - temp.x;
                    int vyn = n.y - temp.y;
                    area[vyn, vxn] = n;
                }
            }

            if( 5 <= area.Cast<fullfield>().Count(x => x != null))
            {
                int[] way = new int[] { 0, 0 };
                for (int i = 0; i < 8; i++)
                {
                    switch(i)
                    {
                        case 0: way = new int[] { 0, 1 }; break;
                        case 1: way = new int[] { 0, -1 }; break;
                        case 2: way = new int[] { 1, 0 }; break;
                        case 3: way = new int[] { -1, 0 }; break;
                        case 4: way = new int[] { 1, 1 }; break;
                        case 5: way = new int[] { -1, 1 }; break;
                        case 6: way = new int[] { 1, -1 }; break;
                        case 7: way = new int[] { -1, -1 }; break;
                    }

                    for(int j = 4; j > 0; j--)
                    {

                    }

                }
            }
        }

        public void win(value winner)
        {

        }

    }
}
