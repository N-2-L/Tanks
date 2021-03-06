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
        private MsgParser parser;
        private ClientClass networkClient;
        private string[,] map;
        private Timer timer;
        private string[,] mapDetails;
        private Label[,] mapLabels;
        private string[,] tableDetails;
        private Label[,] tableLabels;
        public ClientUI()
        {
            InitializeComponent();

            //initialize Map
            map = new string[Constant.MAP_SIZE, Constant.MAP_SIZE];
            for (int i = 0; i < Constant.MAP_SIZE; i++)
            {
                for (int j = 0; j < Constant.MAP_SIZE; j++)
                    map[i, j] = Constant.EMPTY;
            }

            mapDetails = new string[Constant.MAP_SIZE, Constant.MAP_SIZE];
            mapLabels = new Label[Constant.MAP_SIZE, Constant.MAP_SIZE];
            for (int i = 0; i < Constant.MAP_SIZE; i++)
            {
                for (int j = 0; j < Constant.MAP_SIZE; j++)
                    mapLabels[i, j] = (Label)tableLayoutPanel2.GetControlFromPosition(i,j);
            }
            //initialize details table
            tableDetails = new string[5,5];
            tableLabels = new Label[5,5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    tableLabels[i, j] = (Label)tableLayoutPanel1.GetControlFromPosition(i+1, j+1);
            }

            //instantiate message passer
            parser = new MsgParser();
            //instantiate network client
            networkClient = new ClientClass(parser);
            
            //Adding a timer
            timer = new Timer();
            timer.Interval = 100;

            //adding listeners
            timer.Tick += updateMap;
            timer.Tick += updateLabels;
            timer.Tick += updateCommConsole;
            timer.Start();
        }

        private void MapPanel_Paint(object sender, PaintEventArgs e)
        {
            drawMap();
        }

        private void JoinGameButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("JOIN#");
            MsgConsole.Text += "JOIN#\n";
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("UP#");
            MsgConsole.Text += "UP#\n";
        }

        private void MoveLeftButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("LEFT#");
            MsgConsole.Text += "LEFT#\n";
        }

        private void MoveRightButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("RIGHT#");
            MsgConsole.Text += "RIGHT#\n";
        }

        private void ShootButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("SHOOT#");
            MsgConsole.Text += "SHOOT#\n";
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            networkClient.Sender("DOWN#");
            MsgConsole.Text += "DOWN#\n";
        }

        //UI updating methods
        private void drawMap()
        {
            int offsetX = 1, offsetY = 1;
            Pen pen = new Pen(Color.Navy);
            pen.Width = 2;
            Graphics UIGraphics = tableLayoutPanel2.CreateGraphics();
            for (int i = 0; i <= Constant.MAP_SIZE; i++)
            {
                UIGraphics.DrawLine(pen, i * 48 + offsetX, 1, i * 48 + offsetX, 481);
            }
            for (int i = 0; i <= Constant.MAP_SIZE; i++)
            {
                UIGraphics.DrawLine(pen, 1, i * 48 + offsetY, 481, i * 48 + offsetY);
            }

            SolidBrush PaintEmptyCell = new SolidBrush(Color.LightGray);

            for (int i = 0; i < Constant.MAP_SIZE; i++)
            {
                for (int j = 0; j < Constant.MAP_SIZE; j++)
                {
                    UIGraphics.FillRectangle(PaintEmptyCell, new Rectangle(i * 48 + offsetX + 2, j * 48 + offsetY + 2, 44, 44));
                }
            }
            pen.Dispose();
            UIGraphics.Dispose();
        }

        public void updateMap(object sender, EventArgs e)
        {
            int offsetX = 3, offsetY = 3;
            Graphics UIGraphics = tableLayoutPanel2.CreateGraphics();

            SolidBrush PaintEmptyCell = new SolidBrush(Color.LightGray);
            SolidBrush PaintWaterCell = new SolidBrush(Color.Aqua);
            SolidBrush PaintStoneCell = new SolidBrush(Color.Gray);
            SolidBrush PaintBrickCell = new SolidBrush(Color.Maroon);

            //colours for lif and coin - keet
            SolidBrush PaintLifeCell = new SolidBrush(Color.White);
            SolidBrush PaintCoinCell = new SolidBrush(Color.Gold);
            //player colours - keet
            SolidBrush PaintP0Cell = new SolidBrush(Color.Orange);
            SolidBrush PaintP1Cell = new SolidBrush(Color.Red);
            SolidBrush PaintP2Cell = new SolidBrush(Color.Blue);
            SolidBrush PaintP3Cell = new SolidBrush(Color.Green);
            SolidBrush PaintP4Cell = new SolidBrush(Color.Yellow);
            

            map = parser.getMap();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Brush b = PaintEmptyCell;
                    //if (map[i, j] == Constant.EMPTY) b = PaintEmptyCell;
                    if (map[i, j] == Constant.WATER) b = PaintWaterCell;
                    if (map[i, j] == Constant.STONE) b = PaintStoneCell;
                    if (map[i, j] == Constant.BRICK) b = PaintBrickCell;
                    if (map[i, j] == Constant.LIFE) b = PaintLifeCell;
                    if (map[i, j] == Constant.COIN) b = PaintCoinCell;
                    if (map[i, j] == Constant.PLAYER_0) b = PaintP0Cell;
                    if (map[i, j] == Constant.PLAYER_1) b = PaintP1Cell;
                    if (map[i, j] == Constant.PLAYER_2) b = PaintP2Cell;
                    if (map[i, j] == Constant.PLAYER_3) b = PaintP3Cell;
                    if (map[i, j] == Constant.PLAYER_4) b = PaintP4Cell;
                        
                    UIGraphics.FillRectangle(b, new Rectangle(i * 48 + offsetX, j * 48 + offsetY, 44, 44));
                }
            }
            UIGraphics.Dispose();
        }

        public void updateLabels(object sender, EventArgs e)
        {
            mapDetails = parser.getMapHealth();
            tableDetails = parser.getPlayerDetails();
            //update map labels
            for (int i = 0; i < Constant.MAP_SIZE; i++)
            {
                for (int j = 0; j < Constant.MAP_SIZE; j++)
                    if (map[i, j] != Constant.BRICK && map[i, j] != Constant.COIN && !mapDetails[i, j].Equals(""))//remove this and check in parser
                    {
                        mapLabels[i, j].Text = "";
                    }
                    else
                    {
                        mapLabels[i, j].Text = mapDetails[i, j];
                    }
            }
            //update table labels
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    tableLabels[i, j].Text =tableDetails[j,i];
            }

        }

        public void updateCommConsole(object sender, EventArgs e)
        {
            MsgConsole.Text += parser.getMessage();
        }

        //UI processing methods end
    }
}

