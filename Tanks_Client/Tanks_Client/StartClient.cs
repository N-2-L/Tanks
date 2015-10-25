//
//new start point
//
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks_Client
{
    class StartClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        //required variables and constant to update details of the game
        public int playerCount =0;
        public String playerName;
        public Dictionary<int, int> brick;
        public Dictionary<int, int> stone;
        public Dictionary<int, int> water;
        public Dictionary<int, int> bri;
        public int north = 0;
        public int east = 1;
        public int south = 2;
        public int west = 3;






        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
