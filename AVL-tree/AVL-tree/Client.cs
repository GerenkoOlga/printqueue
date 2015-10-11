using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_tree
{
    public class Client :IComparable 
    {
        private String m_clientName;
        private int m_printingTime;
        private int m_leftTime;
        private int m_timeInQueue;
        private int m_priority;

        public Client()
		{
            Random rtime = new Random();
            int randtime = (int)(rtime.Next(5)+15);
            Random rprio = new Random();
            int randprio = (int)(rprio.Next(100));
            Random rchar = new Random();

            this.m_clientName += (char)(rchar.Next(25) + (int)'A');
            for (int i = 0; i < 7; i++) 
                this.m_clientName += (char)(rchar.Next(25)+(int)'a');
            this.m_printingTime = randtime;
            this.m_leftTime = this.m_printingTime;
            this.m_priority = randprio;
            this.m_timeInQueue = 0;
		}

        public String GetClientName()
        {
            return m_clientName;
        }

        public int GetPrintingTime()
        {
            return m_printingTime;
        }

        public int GetLeftTime()
        {
            return m_leftTime;
        }

        public int GetTimeInQueue()
        {
            return m_timeInQueue;
        }

        public int GetPriority()
        {
            return m_priority;
        }

        public void DecLeftTime()
        {
            if (this.m_leftTime > 0)
                this.m_leftTime--;
            else
                this.m_leftTime = 0;
        }

        public void UpdateTimeInQueue()
        {
            m_timeInQueue++;
        }
        public int CompareTo(object client)
        {
            const string s = "сравнимый объект не принадлежит классу Client";
            Client p = client as Client;
            if (!p.Equals(null))
                return m_priority.CompareTo(p.m_priority);
            throw new ArgumentException(s);
        }
        public static bool operator < (Client p1, Client p2)
        {
            return (p1.CompareTo(p2) < 0);
        }
        public static bool operator >(Client p1, Client p2)
        {
            return (p1.CompareTo(p2) > 0);
        }
        public static bool operator <= (Client p1, Client p2)
        {
            return (p1.CompareTo(p2) <= 0);
        }
        public static bool operator >=(Client p1, Client p2)
        {
            return (p1.CompareTo(p2) >= 0);
        }
    }
}
