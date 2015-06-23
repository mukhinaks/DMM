using System;
using System.Collections.Generic;
namespace Game
{
	//изменение
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
				switch (field.getField()[X][Y] )
				{
					case 3:
						field.getField()[X][Y] = 0;
						break;
					case 4:
						field.getField()[X][Y] = 2;
						break;
					default:
						field.getField()[X][Y] = 0;
						break;
				}
			//field.getWatchField()[X][Y] = 0;
			//field.listToModify.AddLast(new Tuple<int,int>(X,Y));
				
			field.addBuddy(new Tuple<int,int>(X,Y));			
		}
	}

	//просмотр
	class EventSecondType : DEVS.ModelEvent
	{
		private Field field;
		private int X;
		private int Y;
		//private bool changes = false;
		//LinkedList<Tuple<int, int>> list = new LinkedList<Tuple<int,int>>();

		public EventSecondType (Field f, int x, int y)
			: base()
		{
			field = f;
			X = x;
			Y = y;
		}

		public override void Execute()
		{
			//field.swapArrays(true);		
			
			//foreach(var t in field.listToModify){
				//var cell = field.getField()[t.Item1][t.Item2];
			if (field.getWatchField()[X][Y] == 1)
			{
				var cell = field.getField()[X][Y];
				switch(cell){
					case 2:
						if(field.checkDead(X, Y)){
							field.getField()[X][Y] = 3;
							EventFirstType eF = new EventFirstType(this.field, X, Y);
							eF.eTime = this.eTime;
							DEVS.ModelEvent.Enque(eF);
							//changes = true;
						}
						break;
					case 0:
						if(field.checkAlive(X, Y)) {
							field.getField()[X][Y] = 4;
							EventFirstType eF = new EventFirstType(this.field, X, Y);
							eF.eTime = this.eTime;
							DEVS.ModelEvent.Enque(eF);
							//changes = true;
						}
						break;
					default:
						break;
				}
				field.getWatchField()[X][Y] = 0;
			}


		}
	}


}