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
					case 2:
						field.getNextField()[X][Y] = 0;
						break;
					case 0:
						field.getNextField()[X][Y] = 2;
						break;
					default:
						field.getNextField()[X][Y] = 0;
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
		private bool changes = false;
		LinkedList<Tuple<int, int>> list = new LinkedList<Tuple<int,int>>();

		public EventSecondType (Field f)
			: base()
		{
			field = f;
		}

		public override void Execute()
		{
			field.swapArrays(true);		
			
			foreach(var t in field.listToModify){
				var cell = field.getField()[t.Item1][t.Item2];
				switch(cell){
					case 2:
						if(field.checkDead(t.Item1, t.Item2)){
							EventFirstType eF = new EventFirstType(this.field, t.Item1, t.Item2);
							eF.eTime = this.eTime;
							DEVS.ModelEvent.Enque(eF);
							changes = true;
						}
						break;
					case 0:
						if(field.checkAlive(t.Item1, t.Item2)) {
							EventFirstType eF = new EventFirstType(this.field, t.Item1, t.Item2);
							eF.eTime = this.eTime;
							DEVS.ModelEvent.Enque(eF);
							changes = true;
						}
						break;
					default:
						break;
				}
				field.getWatchField()[t.Item1][t.Item2] = 0;
			}

			if (changes)
			{
				field.listToModify.Clear();
				EventSecondType eS = new EventSecondType(this.field);
				eS.eTime = this.eTime;
				DEVS.ModelEvent.Enque(eS);	
				//EventThirdType eT = new EventThirdType(this.field);
				//eT.eTime = this.eTime;
				//DEVS.ModelEvent.Enque(eT);
			}
		}
	}


	//сдвиг по времени
	class EventThirdType : DEVS.ModelEvent
	{
		private Field field;

		public EventThirdType (Field f)
			: base()
		{
			field = f;
		}

		public override void Execute()
		{
			EventSecondType eS = new EventSecondType(this.field);
			eS.eTime = this.eTime + 1;
			DEVS.ModelEvent.Enque(eS);			
		}
	}
}