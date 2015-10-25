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

            //Incoming messages processing
 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClientUI_Load(object sender, EventArgs e)
        {

        }

        private void JoinGameButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("JOIN#");
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("UP#");
        }

        private void MoveLeftButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("LEFT#");
        }

        private void MoveRightButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("RIGHT#");
        }

        private void ShootButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("SHOOT#");
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("DOWN#");
        }

        //UI processing methods
        private void ProcessIncomingMessages(object sender, EventArgs e)
        {
            //MsgConsole.Text += e.ToString();
        }
        //UI processing methods end
    }
}

