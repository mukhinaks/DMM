using System;
namespace Game
{
	class EventFirstType : DEVS.ModelEvent
	{
		private int X;
		private int Y;
		private Field field;

		public EventFirstType(Field f, int x, int y)
			: base()
		{
			field = f;
			X = x;
			Y = y;
		}

		public override void Execute()
		{
			int alive = 0;			
			for (int k = 0; k < 3; k++)
			{
				for (int m = 0; m < 3; m++)
				{
					int x = field.tryBound(X - 1 + k);
					int y = field.tryBound(Y - 1 + m);
					if (field.getField()[x][y] == 2)
					{
						alive++;
					}
				}
			}

			if (field.getField()[X][Y] == 0)
			{
				if (alive == 3) field.getNextField()[X][Y] = 2;
			}
			else
			{
				alive--;
				switch (alive)
				{
					case 2:
						field.getNextField()[X][Y] = 2;
						break;
					case 3:
						field.getNextField()[X][Y] = 2;
						break;
					default:
						field.getNextField()[X][Y] = 0;
						break;
				}
			}
			
			field.getWatchField()[X][Y] = 0;
		}
	}

	class EventSecondType : DEVS.ModelEvent
	{
		private Field field;
		private bool changes = false;

		public EventSecondType (Field f)
			: base()
		{
			field = f;
		}

		public override void Execute()
		{
			field.swapArrays(true);		

			for (int i = 0; i < field.cells; i++)
			{
				for (int j = 0; j < field.cells; j++)
				{
					if (field.getField()[i][j] == 2)
					{
						for (int k = 0; k < 3; k++)
						{
							for (int m = 0; m < 3; m++)
							{
								int x = field.tryBound(i - 1 + k);
								int y = field.tryBound(j - 1 + m);
								if (field.getWatchField()[x][y] != 1)
								{
									field.getWatchField()[x][y] = 1;
									EventFirstType eF = new EventFirstType(this.field, x, y);
									eF.eTime = this.eTime;
									DEVS.ModelEvent.Enque(eF);
									//DEVS.ProcessNextEvent();
								}								
							}
						}
						changes = true;
					}
				}
			}
			//if (changes)
			{
				EventSecondType eS = new EventSecondType(this.field);
				eS.eTime = this.eTime + 1;
				DEVS.ModelEvent.Enque(eS);
			}
		}
	}
}