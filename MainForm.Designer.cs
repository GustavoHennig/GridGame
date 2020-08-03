namespace GridGame
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnPlayer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.icon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMoney = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBlocks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.objResource = new System.Windows.Forms.RadioButton();
            this.objCombat = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPlayers = new System.Windows.Forms.NumericUpDown();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(317, 295);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPlayer,
            this.icon,
            this.columnMoney,
            this.columnScore,
            this.columnBlocks});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(335, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(433, 106);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnPlayer
            // 
            this.columnPlayer.Text = "Player";
            this.columnPlayer.Width = 85;
            // 
            // icon
            // 
            this.icon.Text = "";
            this.icon.Width = 50;
            // 
            // columnMoney
            // 
            this.columnMoney.Text = "Money";
            // 
            // columnScore
            // 
            this.columnScore.Text = "Score";
            this.columnScore.Width = 48;
            // 
            // columnBlocks
            // 
            this.columnBlocks.Text = "Blocks";
            this.columnBlocks.Width = 55;
            // 
            // objResource
            // 
            this.objResource.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.objResource.Image = global::GridGame.Properties.Resources.coins16;
            this.objResource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.objResource.Location = new System.Drawing.Point(335, 152);
            this.objResource.Name = "objResource";
            this.objResource.Size = new System.Drawing.Size(92, 18);
            this.objResource.TabIndex = 2;
            this.objResource.TabStop = true;
            this.objResource.Text = "Recursos";
            this.objResource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.objResource.UseVisualStyleBackColor = true;
            // 
            // objCombat
            // 
            this.objCombat.Image = global::GridGame.Properties.Resources.sword16;
            this.objCombat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.objCombat.Location = new System.Drawing.Point(335, 176);
            this.objCombat.Name = "objCombat";
            this.objCombat.Size = new System.Drawing.Size(89, 24);
            this.objCombat.TabIndex = 3;
            this.objCombat.TabStop = true;
            this.objCombat.Text = "Combate";
            this.objCombat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.objCombat.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(535, 179);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtPlayers
            // 
            this.txtPlayers.Location = new System.Drawing.Point(535, 153);
            this.txtPlayers.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.txtPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtPlayers.Name = "txtPlayers";
            this.txtPlayers.Size = new System.Drawing.Size(75, 20);
            this.txtPlayers.TabIndex = 5;
            this.txtPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Location = new System.Drawing.Point(336, 125);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(0, 13);
            this.lblRemaining.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 319);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRemaining);
            this.Controls.Add(this.txtPlayers);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.objCombat);
            this.Controls.Add(this.objResource);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnPlayer;
        private System.Windows.Forms.ColumnHeader columnScore;
        private System.Windows.Forms.RadioButton objResource;
        private System.Windows.Forms.RadioButton objCombat;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown txtPlayers;
        private System.Windows.Forms.ColumnHeader columnBlocks;
        private System.Windows.Forms.ColumnHeader columnMoney;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.ColumnHeader icon;
        private System.Windows.Forms.Label label1;
    }
}

