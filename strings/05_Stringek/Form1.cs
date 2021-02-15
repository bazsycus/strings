using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_Stringek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //deklaráció
        string sEgyik, sMasik;

        private void alapReset()
        {
            label1.Text = "<<eredmény>>";
            //textBox3.Text = "";
            textBox3.Clear();
            sEgyik = textBox1.Text;
            sMasik = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alapReset();
            //int iHossz = sEgyik.Length;
            //label1.Text = iHossz.ToString();
            label1.Text=sEgyik.Length.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alapReset();
            //string sOsszefuz = sEgyik +" " +sMasik;
            //label1.Text = sOsszefuz;
            label1.Text= sEgyik + " " + sMasik;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            alapReset();
            bool bTartalmaz = false;
            /*sEgyik="Almafa"; //szöveg (string)
             * sEgyik[0] //char 
             * sEgyik[0]=="A"
             *    char  == string  |típus eltérés van
             * sEgyik[0] == 'A'
             *    char  == char
             * A L M A F A
             * 0 1 2 3 4 5
             */

            //label1.Text="Nem tartalmaz szóközt";
            for (int i = 0; i < sEgyik.Length; i++)
            {
                //char cVizsgalt = sEgyik[i];//kiemeltem a karakter
                if (sEgyik[i]==' ')
                {
                    bTartalmaz = true;
                    //label1.Text="TArtalmaz szóközt";
                }
            } //for i vége

            if (bTartalmaz)
            {
                label1.Text = "Tartalmaz szóközt";
            } else
            {
                label1.Text = "Nem tartalmaz szóközt";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            alapReset();
            if (sEgyik.Contains(" "))
            {
                label1.Text = "Tartalmaz";
            } else
            {
                label1.Text = "Nem tartalmaz";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            alapReset();
            sEgyik = sEgyik.ToUpper();
            sMasik = sMasik.ToUpper();
            if (sEgyik.Contains(sMasik))
            {
                label1.Text = "Tartalmaz";
            }else
            {
                label1.Text = "Nem tartalmaz";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            alapReset();
            int iSpaceindex = -1;
            for (int i = 0; i < sEgyik.Length; i++)
            {
                if (sEgyik[i]==' ')
                {
                    iSpaceindex = i;
                    //break;//abszoléút csak említés
                }
                //utasítás 2
                //utasítás 3
            }//vége i ciklus
            string sElso="", sMasodik = "";
            for (int i = 0; i < iSpaceindex; i++)
            {
                sElso += sEgyik[i].ToString();
            }
            for (int i = iSpaceindex+1; i < sEgyik.Length; i++)
            {
                sMasodik += sEgyik[i].ToString();
            }
            textBox3.Text = sElso + "\r\n"+sMasodik;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            alapReset();
            int iSpaceindex = sEgyik.IndexOf(" ");

            string sElso, sMasodik;
            sElso = sEgyik.Substring(0, iSpaceindex);
            sMasodik = sEgyik.Substring(iSpaceindex + 1);
            textBox3.Text += sElso + "\r\n" + sMasodik;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            alapReset();
            int iOsszeg = 0;
            string sTmp = "";
            //szám;szám;szám
            sEgyik += ";";
            //szám;szám;szám;
            for (int i = 0; i < sEgyik.Length; i++)
            {
                if (sEgyik[i]==';')
                {
                    iOsszeg += int.Parse(sTmp);
                    textBox3.Text += sTmp + "\r\n";
                    sTmp = "";
                }
                else
                {
                    sTmp += sEgyik[i];
                }
            }
            label1.Text = iOsszeg.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            alapReset();
            int iElozoindex = -1;
            int iOsszeg = 0;
            sEgyik += ";";
            //szám;szám;szám;
            while (sEgyik.IndexOf(";",iElozoindex+1)!=-1)
            {
                string sTmp = sEgyik.Substring(iElozoindex+1, sEgyik.IndexOf(";", iElozoindex + 1)-iElozoindex-1);
                textBox3.Text += sTmp + "\r\n";
                iOsszeg += int.Parse(sTmp);
                iElozoindex = sEgyik.IndexOf(";", iElozoindex + 1);
            }
            label1.Text = iOsszeg.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            alapReset();
            int iHasonlit = sEgyik.ToUpper().CompareTo(sMasik.ToUpper());
            if (iHasonlit<0)
            {
                textBox3.Text = sEgyik + "\r\n" + sMasik;
            } else
            {
                textBox3.Text = sMasik + "\r\n" + sEgyik;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            alapReset();
            bool bTartalmaz = false;
            for (int i = 0; i < sEgyik.Length-sMasik.Length+1; i++)
            {
                string sResz = "";
                for (int j = 0; j < sMasik.Length; j++)
                {
                    sResz = sResz + sEgyik[i + j];
                }
                if (sResz == sMasik)
                {
                    bTartalmaz = true;
                }
            }
            if (bTartalmaz)
            {
                label1.Text = "Tartalmazza";
            }
            else
            {
                label1.Text = "Nem tartalmazza";
            }
        }
    }
}
