namespace Game
{
    partial class Form1
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
			this.pnlGrid = new System.Windows.Forms.Panel();
			this.pnlOptions = new System.Windows.Forms.Panel();
			this.btnDraw = new System.Windows.Forms.Button();
			this.lblCols = new System.Windows.Forms.Label();
			this.lblRows = new System.Windows.Forms.Label();
			this.labelQueue = new System.Windows.Forms.Label();
			this.pnlOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlGrid
			// 
			this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlGrid.Location = new System.Drawing.Point(9, 10);
			this.pnlGrid.Margin = new System.Windows.Forms.Padding(2);
			this.pnlGrid.Name = "pnlGrid";
			this.pnlGrid.Size = new System.Drawing.Size(320, 320);
			this.pnlGrid.TabIndex = 0;
			//this.pnlGrid.MouseDown += new System.EventHandler(this.pnlGrid_MouseDown);
			// 
			// pnlOptions
			// 
			this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlOptions.Controls.Add(this.labelQueue);
			this.pnlOptions.Controls.Add(this.btnDraw);
			this.pnlOptions.Controls.Add(this.lblCols);
			this.pnlOptions.Controls.Add(this.lblRows);
			this.pnlOptions.Location = new System.Drawing.Point(357, 10);
			this.pnlOptions.Margin = new System.Windows.Forms.Padding(2);
			this.pnlOptions.Name = "pnlOptions";
			this.pnlOptions.Size = new System.Drawing.Size(150, 320);
			this.pnlOptions.TabIndex = 1;
			// 
			// btnDraw
			// 
			this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDraw.Location = new System.Drawing.Point(4, 299);
			this.btnDraw.Margin = new System.Windows.Forms.Padding(2);
			this.btnDraw.Name = "btnDraw";
			this.btnDraw.Size = new System.Drawing.Size(143, 19);
			this.btnDraw.TabIndex = 4;
			this.btnDraw.Text = "Дальше";
			this.btnDraw.UseVisualStyleBackColor = true;
			this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
			// 
			// lblCols
			// 
			this.lblCols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCols.AutoSize = true;
			this.lblCols.Location = new System.Drawing.Point(48, 227);
			this.lblCols.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCols.Name = "lblCols";
			this.lblCols.Size = new System.Drawing.Size(50, 13);
			this.lblCols.TabIndex = 1;
			this.lblCols.Text = "Очередь";
			this.lblCols.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRows
			// 
			this.lblRows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRows.AutoSize = true;
			this.lblRows.Location = new System.Drawing.Point(2, 8);
			this.lblRows.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblRows.Name = "lblRows";
			this.lblRows.Size = new System.Drawing.Size(98, 13);
			this.lblRows.TabIndex = 0;
			this.lblRows.Text = "Количество строк";
			// 
			// labelQueue
			// 
			this.labelQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelQueue.AutoSize = true;
			this.labelQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelQueue.Location = new System.Drawing.Point(10, 240);
			this.labelQueue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelQueue.MinimumSize = new System.Drawing.Size(130, 0);
			this.labelQueue.Name = "labelQueue";
			this.labelQueue.Size = new System.Drawing.Size(130, 51);
			this.labelQueue.TabIndex = 5;
			this.labelQueue.Text = "0";
			this.labelQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(516, 348);
			this.Controls.Add(this.pnlOptions);
			this.Controls.Add(this.pnlGrid);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
			this.pnlOptions.ResumeLayout(false);
			this.pnlOptions.PerformLayout();
			this.ResumeLayout(false);

        }

		
		
        #endregion

        private System.Windows.Forms.Panel pnlGrid;
		private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblCols;
		private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Button btnDraw;
		private System.Windows.Forms.Label labelQueue;
    }
}

