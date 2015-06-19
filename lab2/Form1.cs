using System;
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
		static int rows = 10;
		static Field field = new Field(cols, rows);

        public Form1()
        {
            InitializeComponent();

			
			DEVS.AddStartEvent(new EventSecondType(field, 0, 0));
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
					Brush brushPurple = new SolidBrush(Color.Purple);
					Brush brushGreen = new SolidBrush(Color.Green);

                    Point start = new Point(0, 0);
					int size = (int) Math.Min((g.VisibleClipBounds.Height - 5) / rows, (g.VisibleClipBounds.Width - 5) / rows);
					

					for (int i = 0; i < rows; i++)
					{
						start.Y = size * i;		
						for (int j = 0; j < rows; j++)
						{
							start.X = size * j;
							if (field.getWatchField()[i][j] == 1)
								//if (field.listToModify.Contains(new Tuple<int,int>(i,j)))
							{
								g.FillRectangle(brushGray, start.X, start.Y, size, size);
							}
							switch (field.getField()[i][j])
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
								case 3:
									g.FillRectangle(brushPurple, start.X, start.Y, size, size);
									break;
								case 4:
									g.FillRectangle(brushGreen, start.X, start.Y, size, size);
									break;
								default:
									Console.WriteLine("Error");
									break;
							}							
						}
					}


					labelIteration.Text = "" + DEVS.GlobalTime;
					labelQueue.Text = "" + DEVS.EQ.QueueSize;
					double time = DEVS.EQ.GlobalTime;
					
					//while (time == DEVS.EQ.GlobalTime)
					{
						DEVS.ProcessNextEvent();
						//if (DEVS.EQ.QueueSize == 0) break;
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
				field.getField()[y][x] = 2;
				field.getNextField()[y][x] = 2;
				Tuple<int, int> t = new Tuple<int,int>(y,x); 
				field.addBuddy(t);
				//EventSecondType eS = new EventSecondType(field);
				//eS.eTime = DEVS.GlobalTime;
				//DEVS.EQ.AddEvent(eS);

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

		private void buttonModify_Click(object sender, EventArgs e)
		{
			//EventThirdType eT = new EventThirdType(field);
			//eT.eTime = DEVS.GlobalTime;
			//DEVS.EQ.AddEvent(eT);

			double time = DEVS.EQ.GlobalTime;

			//while (time == DEVS.EQ.GlobalTime)
			{
				DEVS.ProcessNextEvent();
				//if (DEVS.EQ.QueueSize == 0) break;
			}

		}
	}
}
