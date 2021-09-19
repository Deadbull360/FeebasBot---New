namespace FeebasBot.Telas
{
    partial class Info
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
            this.components = new System.ComponentModel.Container();
            this.CharHP = new System.Windows.Forms.Label();
            this.PokeHP = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fish = new System.Windows.Forms.Label();
            this.pescados = new System.Windows.Forms.Label();
            this.chat = new System.Windows.Forms.Label();
            this.ping = new System.Windows.Forms.Label();
            this.attacked = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CharHP
            // 
            this.CharHP.AutoSize = true;
            this.CharHP.Dock = System.Windows.Forms.DockStyle.Top;
            this.CharHP.Location = new System.Drawing.Point(0, 0);
            this.CharHP.Name = "CharHP";
            this.CharHP.Size = new System.Drawing.Size(20, 13);
            this.CharHP.TabIndex = 0;
            this.CharHP.Text = "X: ";
            // 
            // PokeHP
            // 
            this.PokeHP.AutoSize = true;
            this.PokeHP.Dock = System.Windows.Forms.DockStyle.Top;
            this.PokeHP.Location = new System.Drawing.Point(0, 13);
            this.PokeHP.Name = "PokeHP";
            this.PokeHP.Size = new System.Drawing.Size(20, 13);
            this.PokeHP.TabIndex = 1;
            this.PokeHP.Text = "X: ";
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Dock = System.Windows.Forms.DockStyle.Top;
            this.X.Location = new System.Drawing.Point(0, 26);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(20, 13);
            this.X.TabIndex = 2;
            this.X.Text = "X: ";
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Dock = System.Windows.Forms.DockStyle.Top;
            this.Y.Location = new System.Drawing.Point(0, 39);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(20, 13);
            this.Y.TabIndex = 3;
            this.Y.Text = "X: ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fish
            // 
            this.fish.AutoSize = true;
            this.fish.Dock = System.Windows.Forms.DockStyle.Top;
            this.fish.Location = new System.Drawing.Point(0, 52);
            this.fish.Name = "fish";
            this.fish.Size = new System.Drawing.Size(20, 13);
            this.fish.TabIndex = 4;
            this.fish.Text = "X: ";
            // 
            // pescados
            // 
            this.pescados.AutoSize = true;
            this.pescados.Dock = System.Windows.Forms.DockStyle.Top;
            this.pescados.Location = new System.Drawing.Point(0, 65);
            this.pescados.Name = "pescados";
            this.pescados.Size = new System.Drawing.Size(20, 13);
            this.pescados.TabIndex = 5;
            this.pescados.Text = "X: ";
            // 
            // chat
            // 
            this.chat.AutoSize = true;
            this.chat.Dock = System.Windows.Forms.DockStyle.Top;
            this.chat.Location = new System.Drawing.Point(0, 78);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(20, 13);
            this.chat.TabIndex = 6;
            this.chat.Text = "X: ";
            // 
            // ping
            // 
            this.ping.AutoSize = true;
            this.ping.Dock = System.Windows.Forms.DockStyle.Top;
            this.ping.Location = new System.Drawing.Point(0, 91);
            this.ping.Name = "ping";
            this.ping.Size = new System.Drawing.Size(20, 13);
            this.ping.TabIndex = 7;
            this.ping.Text = "X: ";
            // 
            // attacked
            // 
            this.attacked.AutoSize = true;
            this.attacked.Dock = System.Windows.Forms.DockStyle.Top;
            this.attacked.Location = new System.Drawing.Point(0, 104);
            this.attacked.Name = "attacked";
            this.attacked.Size = new System.Drawing.Size(17, 13);
            this.attacked.TabIndex = 8;
            this.attacked.Text = "X:";
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(121, 169);
            this.Controls.Add(this.attacked);
            this.Controls.Add(this.ping);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.pescados);
            this.Controls.Add(this.fish);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.X);
            this.Controls.Add(this.PokeHP);
            this.Controls.Add(this.CharHP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Info";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Info_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Info_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CharHP;
        private System.Windows.Forms.Label PokeHP;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Label Y;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label fish;
        private System.Windows.Forms.Label pescados;
        private System.Windows.Forms.Label chat;
        private System.Windows.Forms.Label ping;
        private System.Windows.Forms.Label attacked;
    }
}