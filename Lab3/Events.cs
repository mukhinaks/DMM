﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    /// <summary>
    /// Класс для дискретно-событийного моделирования
    /// </summary>
    public class DEVS
    {
        /// <summary>
        /// Внутренняя очерель для моделирования
        /// </summary>
        static EventsQueue EQ = new EventsQueue();


        public static double GlobalTime
        {
            get { return EQ.GlobalTime; }
        }

        /// <summary>
        /// Добавить стартовое событие
        /// </summary>
        public static void AddStartEvent(ModelEvent ME)
        {
            if (EQ.QueueSize == 0) EQ.AddEvent(ME);
        }
        
        /// <summary>
        /// Обработать очередное событие
        /// </summary>
        public static void ProcessNextEvent()
        {
            EQ.ProcessNextEvent();
        }
  
        /// <summary>
        /// Класс для модельного события
        /// </summary>
        public abstract class ModelEvent
        {
            /// <summary>
            /// Добавить данное событие в очередь
            /// </summary>            
            protected void Enque()
            {
                EQ.AddEvent(this);
            }

            /// <summary>
            /// Добавить другое событие в очередь
            /// </summary>
            /// <param name="ME">Добавляемое событие</param>
            protected static void Enque(ModelEvent ME)
            {
                EQ.AddEvent(ME);
            }

            double _eTime;

            /// <summary>
            /// Время наступления события
            /// </summary>
            public double eTime
            {
                get { return _eTime; }
                set { _eTime = value; }
            }

            /// <summary>
            /// Вывести отладочную информацию
            /// </summary>
            public void Debug()
            {
                
                Console.WriteLine("Type of Event " + this.GetType().ToString() + "at time " + _eTime.ToString("F3"));
            }

            /// <summary>
            /// Выполнить полезное действие
            /// </summary>
            public abstract void Execute();
        }
    }

    /// <summary>
    /// Очередь событий
    /// </summary>
    public class EventsQueue
    {
        /// <summary>
        /// Глобальное время
        /// </summary>
        double globalTime = 0;

        /// <summary>
        /// Поток событий
        /// </summary>
        List<DEVS.ModelEvent> MEvents = new List<DEVS.ModelEvent>();

        /// <summary>
        /// Размер очереди
        /// </summary>
        /// <returns>Размер очереди</returns>
        public int QueueSize
        {
            get { return MEvents.Count;  }
        }

        public double GlobalTime
        {
            get { return globalTime; }
            set { globalTime = value; }
        }

        /// <summary>
        /// Добавить событие к списку
        /// </summary>
        /// <param name="MEvent">Добавляемое событие</param>        
        public void AddEvent(DEVS.ModelEvent MEvent)
        {
            int count =  MEvents.Count ;

            if (count == 0) 
            {
                MEvents.Add(MEvent); 
                return; 
            }

            if (MEvent.eTime >= MEvents[count - 1].eTime) 
            { 
                MEvents.Add(MEvent); 
                return; 
            }

            if (MEvent.eTime <= MEvents[1].eTime) 
            { 
                MEvents.Insert(1, MEvent); 
                return;                                           
            }

            for (int i = 0; i < count - 1; i++)
                if (MEvent.eTime >= MEvents[i].eTime)
                    if (MEvent.eTime < MEvents[i + 1].eTime)
                    {
                        MEvents.Insert(i + 1, MEvent);
                        return;
                    }
        }

        /// <summary>
        /// Обработать очередное событие
        /// </summary>        
        public void ProcessNextEvent()
        {
            if (MEvents.Count == 0) return;
            MEvents[0].Execute() ;
            globalTime = MEvents[0].eTime ;
            MEvents.RemoveAt(0);         
        }

    }    
}