using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimerUebungen
{
    public partial class FrmTimerUebungen : Form
    {
        Timer timer;
        Rectangle rect;
        int h;
        int w;

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

            
        }

        private void TickEreignis(Object myObject, EventArgs myEventArgs)
        {
            
            rect.X += 5;

            if(rect.Right >= w)
            {
                timer.Stop();
            } 
            else
            {
                Refresh();
            }

            
            
        }

        private void FrmTimerUebungen_Paint(object sender, PaintEventArgs e)
        {
            //Hilfsvariablen
            Graphics g = e.Graphics;
            h = this.ClientSize.Height;
            w = this.ClientSize.Width;

            //Zeichenmittel
            Brush brush = new SolidBrush(Color.MediumSpringGreen);

            if (timer.Enabled == false)
            {
                rect = new Rectangle(0, 0, 30, h);
                timer.Start();
            }


            g.FillRectangle(brush, rect);

        }
    }
}
