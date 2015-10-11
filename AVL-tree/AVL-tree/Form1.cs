using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVL_tree
{
    
    public partial class Form1 : Form
    {
       private AVLTree<Client> m_printerQueue = new AVLTree<Client>();
       private  Queue<Client> temp = new Queue<Client>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            int count = m_printerQueue.Count;
            int count2 = temp.Count;
            for (int i = 0; i < count2; i++)
            {
                Client peekedClient = temp.Dequeue();
                peekedClient.UpdateTimeInQueue();
                temp.Enqueue(peekedClient);
            }
            if (m_printerQueue.Count > 0)
            {
                Client peekedClient = m_printerQueue.MaxValue;
                peekedClient.DecLeftTime();
                if (peekedClient.GetLeftTime() == 0)
                {
                    m_printerQueue.Remove(peekedClient);
                    richTextBox2.Text += "  " + peekedClient.GetClientName() + " (priority: " + peekedClient.GetPriority().ToString() + ";time: " + peekedClient.GetPrintingTime().ToString() + ") has finished printing\n";
                }
                ShowPrintQueue(m_printerQueue.Count);
            }
           
            Random r = new Random();
            int rand = (int)(r.Next(7));
            if ((rand != 0 && m_printerQueue.Count > 3) || m_printerQueue.Count > 15) return;
            Client client = new Client();
            richTextBox1.Text = "> Client <" + client.GetClientName() + "> has joined to the printing queue...\n";
            richTextBox1.Text += "      " + client.GetClientName() + "'s priority is " + client.GetPriority().ToString() + "/100\n    " + client.GetClientName() + "'s time for printing is " + client.GetPrintingTime().ToString() + "sec.\n";
            m_printerQueue.Add(client);
            temp.Enqueue(client);
            ShowPrintQueue(m_printerQueue.Count);
        }
        private void ShowPrintQueue(int highlightedOne)
        {
            richTextBox3.Text = "";
            AVLTree<Client> reservedQueue = new AVLTree<Client>();
            Client[] clientArr = new Client[highlightedOne];
            m_printerQueue.CopyTo(clientArr);//copy queue
            foreach (Client element in clientArr)
                    {
                      reservedQueue.Add(element);
                    }
                int count = reservedQueue.Count;
            for (int i = 0; i < count; i++)
            {
                Client peekedClient = reservedQueue.MaxValue;
                bool d = reservedQueue.Remove(peekedClient);
                richTextBox3.Text += (i + 1).ToString() + ". " + peekedClient.GetClientName() + " (" + peekedClient.GetPriority() + ")" + "    [" + peekedClient.GetLeftTime() + "]";
                if (i == highlightedOne || peekedClient.GetTimeInQueue() < 3)
                richTextBox3.Text += "  <<<";
                richTextBox3.Text += "\n";
            }
        }

       
    }
}
