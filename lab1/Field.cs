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
	}
}
