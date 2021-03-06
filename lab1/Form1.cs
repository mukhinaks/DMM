﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
		static int cols = 20; 
		static int rows = 20;
		static Field field = new Field(cols, rows);

        public Form1()
        {
            InitializeComponent();

			
			DEVS.AddStartEvent(new EventSecondType(field));
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
				//int cols = 20; // Convert.ToInt32(tbxCols.Text);
				//int rows = 20; // Convert.ToInt32(tbxRows.Text);

                if (cols > 0 && rows > 0)
                {
                    Graphics g = pnlGrid.CreateGraphics();
                    g.Clear(Color.FromKnownColor(KnownColor.Control));
					
                    Pen p = new Pen(Color.Black, 1.5f);
					Brush brushRed = new SolidBrush(Color.Red);
					Brush brushGray = new SolidBrush(Color.Gray);

                    Point start = new Point(0, 0);
					int size = (int) Math.Min((g.VisibleClipBounds.Height - 5) / rows, (g.VisibleClipBounds.Width - 5) / rows);
					

					for (int i = 0; i < rows; i++)
					{
						start.Y = size * i;		
						for (int j = 0; j < rows; j++)
						{
							start.X = size * j;
							if (field.getWatchField()[i][j] == 1)
							{
								g.FillRectangle(brushGray, start.X, start.Y, size, size);
							}
							switch (field.getNextField()[i][j])
							{
								case 0:
									g.DrawRectangle(p, start.X, start.Y, size, size);
									break;
								case 1:
									g.FillRectangle(brushGray, start.X, start.Y, size, size);
									break;
								case 2:
									g.FillRectangle(brushRed, start.X, start.Y, size, size);
									break;
								default:
									Console.WriteLine("Error");
									break;
							}							
						}
					}
					labelQueue.Text = "" + DEVS.EQ.QueueSize;
					double time = DEVS.GlobalTime;
					while (time == DEVS.GlobalTime)
					{
						DEVS.ProcessNextEvent();
					}										
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
           // btnDraw_Click(sender, e);
        }

		private void pnlGrid_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				Graphics g = pnlGrid.CreateGraphics();

				int x = e.X;
				int y = e.Y;
				int size = (int)Math.Min((g.VisibleClipBounds.Height - 5) / rows, (g.VisibleClipBounds.Width - 5) / rows);

				x /= size;
				y /= size;
				//x++;
				//y++;
				//field.getField()[y][x] = 2;
				field.getNextField()[y][x] = 2;
				//DEVS.EQ.GlobalTime ++;
				//EventSecondType eS = new EventSecondType(field);
				//eS.eTime = DEVS.GlobalTime;
				//DEVS.EQ.AddEvent(eS);
				//DEVS.ProcessNextEvent();

				Brush brushRed = new SolidBrush(Color.Red);
				g.FillRectangle(brushRed, size * x, size * y, size, size);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void pnlGrid_Paint (object sender, PaintEventArgs e)
		{
		}
	}
}
