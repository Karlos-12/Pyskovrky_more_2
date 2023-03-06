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

        }
    }
}
