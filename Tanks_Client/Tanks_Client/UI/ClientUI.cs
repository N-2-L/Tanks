using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks_Client.UI
{
    public partial class ClientUI : Form
    {
        private ClientClass networkClient;
        public ClientUI()
        {
            InitializeComponent();

            //initialize grid

            //instantiate network client
            networkClient = new ClientClass();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClientUI_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void JoinGameButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("JOIN#");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

