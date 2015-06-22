using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
	class ClientEvent : DEVS.ModelEvent
	{
		int enterTime;

		public override void Execute()
		{
			DoctorEvent AE = new DoctorEvent();
			AE.eTime = this.eTime + 1;  // продвижение по времени                     
			DEVS.ModelEvent.Enque(AE);
		}
	}

	class DoctorEvent : DEVS.ModelEvent
	{
		Random rand = new Random();
		int waintingTime = 0;

		public override void Execute()
		{
			double probabilty = rand.NextDouble();
			if (probabilty < 0.9)
			{
				ClientEvent AE = new ClientEvent();
				AE.eTime = this.eTime;  // продвижение по времени                     
				DEVS.ModelEvent.Enque(AE);
			}
			else
			{
				ClientEvent AE = new ClientEvent();
				AE.eTime = this.eTime;  // продвижение по времени                     
				DEVS.ModelEvent.Enque(AE);
			}
			
		}
	}
}  
