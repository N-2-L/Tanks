namespace Tanks_Client.UI
{
    partial class ClientUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.ShootButton = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveRightButton = new System.Windows.Forms.Button();
            this.MoveLeftButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.JoinGameButton = new System.Windows.Forms.Button();
            this.MsgConsole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MapPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.MapPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ShootButton);
            this.panel2.Controls.Add(this.MoveDownButton);
            this.panel2.Controls.Add(this.MoveRightButton);
            this.panel2.Controls.Add(this.MoveLeftButton);
            this.panel2.Controls.Add(this.MoveUpButton);
            this.panel2.Controls.Add(this.JoinGameButton);
            this.panel2.Controls.Add(this.MsgConsole);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(507, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 500);
            this.panel2.TabIndex = 1;
            // 
            // ShootButton
            // 
            this.ShootButton.Location = new System.Drawing.Point(277, 284);
            this.ShootButton.Name = "ShootButton";
            this.ShootButton.Size = new System.Drawing.Size(87, 36);
            this.ShootButton.TabIndex = 7;
            this.ShootButton.Text = "FIRE";
            this.ShootButton.UseVisualStyleBackColor = true;
            this.ShootButton.Click += new System.EventHandler(this.ShootButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(163, 378);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(50, 50);
            this.MoveDownButton.TabIndex = 6;
            this.MoveDownButton.Text = "DOWN";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveRightButton
            // 
            this.MoveRightButton.Location = new System.Drawing.Point(211, 331);
            this.MoveRightButton.Name = "MoveRightButton";
            this.MoveRightButton.Size = new System.Drawing.Size(50, 50);
            this.MoveRightButton.TabIndex = 5;
            this.MoveRightButton.Text = "RIGHT";
            this.MoveRightButton.UseVisualStyleBackColor = true;
            this.MoveRightButton.Click += new System.EventHandler(this.MoveRightButton_Click);
            // 
            // MoveLeftButton
            // 
            this.MoveLeftButton.Location = new System.Drawing.Point(115, 331);
            this.MoveLeftButton.Name = "MoveLeftButton";
            this.MoveLeftButton.Size = new System.Drawing.Size(50, 50);
            this.MoveLeftButton.TabIndex = 4;
            this.MoveLeftButton.Text = "LEFT";
            this.MoveLeftButton.UseVisualStyleBackColor = true;
            this.MoveLeftButton.Click += new System.EventHandler(this.MoveLeftButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(163, 284);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(50, 50);
            this.MoveUpButton.TabIndex = 3;
            this.MoveUpButton.Text = "UP";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // JoinGameButton
            // 
            this.JoinGameButton.AccessibleName = "";
            this.JoinGameButton.Location = new System.Drawing.Point(13, 284);
            this.JoinGameButton.Name = "JoinGameButton";
            this.JoinGameButton.Size = new System.Drawing.Size(87, 36);
            this.JoinGameButton.TabIndex = 2;
            this.JoinGameButton.Text = "Join Game";
            this.JoinGameButton.UseVisualStyleBackColor = true;
            this.JoinGameButton.Click += new System.EventHandler(this.JoinGameButton_Click);
            // 
            // MsgConsole
            // 
            this.MsgConsole.Location = new System.Drawing.Point(13, 42);
            this.MsgConsole.Multiline = true;
            this.MsgConsole.Name = "MsgConsole";
            this.MsgConsole.ReadOnly = true;
            this.MsgConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MsgConsole.Size = new System.Drawing.Size(351, 223);
            this.MsgConsole.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Communication With Server";
            // 
            // MapPanel
            // 
            this.MapPanel.Controls.Add(this.label3);
            this.MapPanel.Controls.Add(this.label2);
            this.MapPanel.Location = new System.Drawing.Point(4, 2);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(500, 500);
            this.MapPanel.TabIndex = 2;
            this.MapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MapPanel_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // ClientUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 508);
            this.Controls.Add(this.MapPanel);
            this.Controls.Add(this.panel2);
            this.Name = "ClientUI";
            this.Text = "ClientUI";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.MapPanel.ResumeLayout(false);
            this.MapPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MsgConsole;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveRightButton;
        private System.Windows.Forms.Button MoveLeftButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button ShootButton;
        private System.Windows.Forms.Button JoinGameButton;
        private System.Windows.Forms.Panel MapPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}

        
