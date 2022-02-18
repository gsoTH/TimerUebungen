using System;
using System.Windows.Forms;

namespace TimerUebungen
{
    public partial class FrmTimerUebungen : Form
    {
        Timer timer;

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

    }
}
