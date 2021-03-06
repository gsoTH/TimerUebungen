using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimerUebungen
{
    public partial class FrmTimerUebungen : Form
    {
        Timer timer;
        Rectangle[] rects = new Rectangle[2];
        int h;
        int w;
        Random rnd = new Random();

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
            HindernisBewegen();
            CheckObHindernisAusserhalbDerFormIst();

            Refresh();

        }

        private void CheckObHindernisAusserhalbDerFormIst()
        {
            if (rects[0].Right <= 0)
            {
                timer.Stop();
            }
        }

        private void HindernisBewegen()
        {
            for (int i = 0; i < rects.Length; i++)
            {
                rects[i].X -= 5;
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
                int anteil = h / 5;
                HindernisErzeugen(anteil);
                timer.Start();
            }

            foreach (Rectangle r in rects)
            {
                g.FillRectangle(brush, r);
            }

        }

        /// <summary>
        /// Erzeugt zwei Hindernisse mit einer Lücke.
        /// </summary>
        /// <param name="anteil">Größenfaktor für Position und Dimension der Lücke.</param>
        private void HindernisErzeugen(int anteil)
        {
            int positionLuecke = rnd.Next(anteil, anteil * 3);
            int dimensionLuecke = rnd.Next(Convert.ToInt32(anteil * 0.5), Convert.ToInt32(anteil * 1.5));

            rects[0] = new Rectangle(w, 0, 30, positionLuecke);
            rects[1] = new Rectangle(w, rects[0].Bottom + dimensionLuecke, 30, h);
        }
    }
}
