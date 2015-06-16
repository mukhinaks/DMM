using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	class Field
	{
		private int[][] field;
		private int[][] newField;
		private int[][] watchField;
		public  int cells;
		public LinkedList<Tuple<int, int>> listToModify = new LinkedList<Tuple<int,int>>();

		public Field(int cols, int rows)
		{
			cells = rows;		
			field = new int[cells][];
			newField = new int[cells][];
			watchField = new int[cells][];
			for (int i = 0; i < cells; i++)
			{
				field[i] = new int[cells];
				newField[i] = new int[cells];
				watchField[i] = new int[cells];
				for (int j = 0; j < cells; j++) 
				{
					field[i][j] = 0;
					newField[i][j] = 0;
					watchField[i][j] = 0; 
				}
			}
			//planer
			field[5][5] = 2;
			field[6][6] = 2;
			field[6][7] = 2;
			field[7][5] = 2;
			field[7][6] = 2;
			
			
			//squares
			//field[5][5] = 2;
			//field[5][6] = 2;
			//field[6][5] = 2;
			//field[6][6] = 2;

			//field[4][7] = 2;
			//field[4][8] = 2;
			//field[3][7] = 2;
			//field[3][8] = 2;

			//field[1][0] = 2;
			//field[1][1] = 2;
			//field[1][2] = 2;
			for (int i = 0; i < cells; i++)
			{
				for (int j = 0; j < cells; j++)
				{
					if (getField()[i][j] == 2)
					{
						var t = new Tuple<int,int>(i,j);
						//listToModify.AddLast(t);
						addBuddy(t);
					}
				}
			}
			swapArrays(false);
			//Array.Copy(field, newField, field.Length);
			//cellSize = size;
		}

		public void swapArrays(bool flag){
			if (flag)
			{
				for (int i = 0; i < cells; i++)
				{
					for (int j = 0; j < cells; j++)
						field[i][j] = newField[i][j];
				}
			}
			else
			{
				for (int i = 0; i < cells; i++)
				{
					for (int j = 0; j < cells; j ++ )
						newField[i][j] = field[i][j];
				}
			}
						
		}
		public int[][] getWatchField()
		{
			return watchField;
		}

		public int[][] getField(){
			return field;
		}
		public int[][] getNextField()
		{
			return newField;
		}

		public int tryBound(int idx)
		{
			if (idx == cells) return 0;
			if (idx == -1) return cells - 1;
			return idx;
		}

		public bool checkDead(int X, int Y){
			int alive = 0;			
			for (int k = 0; k < 3; k++)
			{
				for (int m = 0; m < 3; m++)
				{
					int x = tryBound(X - 1 + k);
					int y = tryBound(Y - 1 + m);
					if (getField()[x][y] == 2)
					{
						alive++;
					}
				}
			}
			alive--;
			return (alive < 2 || alive > 3) ;
		}

		public bool checkAlive(int X, int Y){
			int alive = 0;			
			for (int k = 0; k < 3; k++)
			{
				for (int m = 0; m < 3; m++)
				{
					int x = tryBound(X - 1 + k);
					int y = tryBound(Y - 1 + m);
					if (getField()[x][y] == 2)
					{
						alive++;
					}
				}
			}
			return alive == 3;
		}

		public void addBuddy(Tuple<int,int> t){
			int i = t.Item1;
			int j = t.Item2;
			for (int k = 0; k < 3; k++)
			{
				for (int m = 0; m < 3; m++)
				{
					int x = tryBound(i - 1 + k);
					int y = tryBound(j - 1 + m);
					//if (x==i && y==j) continue;
					if (getWatchField()[x][y] != 1)
					{
						getWatchField()[x][y] = 1;
						listToModify.AddLast(new Tuple<int,int>(x,y));
					}								
				}
			}
		}
	}
}
