using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimerUebungen
{
    public partial class FrmTimerUebungen : Form
    {
        Timer timer;
        Rectangle rect;

        public FrmTimerUebungen()
        {
            InitializeComponent();

            TimerEinstellenUndStarten();

        }

        private void TimerEinstellenUndStarten()
        {
            //Timer initialisieren, er ist noch nicht gestartet
            timer = new Timer();

            //Zeit zwischen Ereignissen in ms festlegen
            timer.Interval = 10;

            // Methode zuweisen, die ausgeführt wird, wenn der Intervall abgelaufen ist.
            timer.Tick += new EventHandler(TickEreignis); //Hier wird ein Delegat erzeugt.

            timer.Start();
        }

        private void TickEreignis(Object myObject, EventArgs myEventArgs)
        { 
           // Code einfügen, der nach jedem Tick ausgeführt werden soll.
        }

        private void FrmTimerUebungen_Paint(object sender, PaintEventArgs e)
        {
            //Hilfsvariablen
            Graphics g = e.Graphics;
            int h = this.ClientSize.Height;
            int w = this.ClientSize.Width;
        }
    }
}
