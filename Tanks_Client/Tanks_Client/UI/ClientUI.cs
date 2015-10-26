﻿using System;
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
        private string[,] map;
        public ClientUI()
        {
            InitializeComponent();

            //initialize Map
            map = new string[Constant.MAP_SIZE, Constant.MAP_SIZE];
            for (int i = 0; i < Constant.MAP_SIZE; i++)
            {
                for (int j = 0; j < Constant.MAP_SIZE; j++)
                    map[i, j] = "E";
            }
            drawMap();//not working
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
            drawMap();
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

        private void drawMap()
        {
            int offsetX = 10, offsetY = 10;
            Pen pen = new Pen(Color.Red);
            Graphics UIGraphics = flowLayoutPanel1.CreateGraphics();
            UIGraphics.DrawLine(pen, 10, 10, 480, 10);
            UIGraphics.DrawLine(pen, 0, 0, 200, 200);

            SolidBrush PaintEmptyCell = new SolidBrush(Color.Black);

            for (int i = 0; i < Constant.MAP_SIZE; i++)
            {
                for (int j = 0; j < Constant.MAP_SIZE; j++)
                {
                    Brush brush = PaintEmptyCell;
                    UIGraphics.FillRectangle(brush, new Rectangle(i * 20 + offsetX, j * 20 + offsetY, 10, 10));
                }
            }
            pen.Dispose();
            UIGraphics.Dispose();
        }

        public void updateMap()
        {
            int offsetX = 10, offsetY = 10;
            Pen pen = new Pen(Color.Red);
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.DrawLine(pen, 0, 0, 200, 200);

            SolidBrush brushEmpty = new SolidBrush(Color.White);
            SolidBrush brushWater = new SolidBrush(Color.CadetBlue);
            SolidBrush brushStone = new SolidBrush(Color.Black);
            SolidBrush brushBrick = new SolidBrush(Color.Brown);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Brush b = brushEmpty;
                    //if (map[i, j] == Constant.WATER) b = brushWater;
                    //if (map[i, j] == Constant.STONE) b = brushStone;
                    //if (map[i, j] == Constant.BRICK) b = brushBrick;
                    formGraphics.FillRectangle(b, new Rectangle(i * 20 + offsetX, j * 20 + offsetY, 10, 10));

                }
            }
            pen.Dispose();
            formGraphics.Dispose();
        }
        //UI processing methods end
    }
}

