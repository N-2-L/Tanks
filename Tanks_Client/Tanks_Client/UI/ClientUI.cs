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
        private MsgParser parser;
        private ClientClass networkClient;
        private string[,] map;
        private Timer timer;
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
            //instantiate message passer
            parser = new MsgParser();
            //instantiate network client
            networkClient = new ClientClass(parser);
            
            //Adding a timer
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += updateMap;//adding a listener
            timer.Start();
        }

        private void MapPanel_Paint(object sender, PaintEventArgs e)
        {
            drawMap();
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
                        UIGraphics.FillRectangle(b, new Rectangle(i * 48 + offsetX, j * 48 + offsetY, 44, 44));
                    }
                }
            
            UIGraphics.Dispose();
        }

        //UI processing methods end
    }
}

