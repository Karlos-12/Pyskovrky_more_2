using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyskovrky_more_2
{
    internal class SavedGame
    {
        public value turn { get; set; }
        public List<fullfield> field_list { get; set; }

        public SavedGame(value turn, List<fullfield> field_list)
        {
            this.turn = turn;
            this.field_list = field_list;
        }
    }
}
