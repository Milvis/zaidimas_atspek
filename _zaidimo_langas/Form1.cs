using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _zaidimo_langas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        int likospejimu = 0;
      //  while (likospejimu<=10)
        public void button1_Click(object sender, EventArgs e)
        {
           

            if (likospejimu==11)
            {
                if(MessageBox.Show("GAME OVER\nAr norite pakartoti?", "Žaidimo pabaiga", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    likospejimu = 0;
                    textBox1.BackColor = Color.White;
                }

              
            }
            label2.Visible = false;
            Random sk = new Random();

            int randomnumber = sk.Next(1, 4);//0 ir 4 neima random skaicius nuo 1 iki 3
                                             
                                             // trikampis = 1;
                                             // apskritimas = 2;
                                             // keturkampis = 3;
            int atspeta = 0;
            //int kiek = 0;





            if (randomnumber == 1)
            {
                pictureBox1.Image = new Bitmap("trikampis.png");
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    atspeta++;
                }
            }
            else if (randomnumber == 2)
            {
                pictureBox1.Image = new Bitmap("apskritimas.png");
                if (checkBox2.CheckState == CheckState.Checked)
                {
                    atspeta++;
                }
            }
            else if (randomnumber == 3)
            {
                pictureBox1.Image = new Bitmap("keturkampis.png");
                if (checkBox3.CheckState == CheckState.Checked)
                {
                    atspeta++;
                }
            }

            //naujas random antram pav


            int randomnumber1 = sk.Next(1, 4);//0 ir 4 neima random skaicius nuo 1 iki 3
                                              // randomnumber1 = 1;
            if (randomnumber1 == 1)
            {
                pictureBox2.Image = new Bitmap("trikampis.png");
                if (checkBox4.CheckState == CheckState.Checked)
                {
                    atspeta++;
                }
            }
            else if (randomnumber1 == 2)
            {
                pictureBox2.Image = new Bitmap("apskritimas.png");
                if (checkBox5.CheckState == CheckState.Checked)
                {
                    atspeta++;
                }
            }
            else if (randomnumber1 == 3)
            {
                pictureBox2.Image = new Bitmap("keturkampis.png");
                if (checkBox6.CheckState == CheckState.Checked)
                {
                    atspeta++;
                }
            }

            //treciam pav.


            int randomnumber2 = sk.Next(1, 4);//0 ir 4 neima random skaicius nuo 1 iki 3
                                              //   randomnumber2 = 1;
            if (randomnumber2 == 1)
            {
                pictureBox3.Image = new Bitmap("trikampis.png");
                if (checkBox7.CheckState == CheckState.Checked)
                {
                    atspeta++;
                }
            }
            else if (randomnumber == 2)
            {
                pictureBox3.Image = new Bitmap("apskritimas.png");
                if (checkBox8.CheckState == CheckState.Checked)
                {
                    atspeta++;
                }
            }
            else if (randomnumber == 3)
            {
                pictureBox3.Image = new Bitmap("keturkampis.png");
                if (checkBox9.CheckState == CheckState.Checked)
                {
                    atspeta++;
                }
            }


            if (atspeta == 3)
            {
                label2.Visible = true;
                label2.Text = "Atspėjote!!!";
                label2.BackColor = Color.Green;
               var k = likospejimu;
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var gamerobject = new gamers
                        {
                            FirstName = this.gamers_name.Text,
                            Points = 10-this.likospejimu,
                        };
                        session.Save(gamerobject);
                        transaction.Commit();

                    }
                }

                if (MessageBox.Show("Žaidimas laimėtas.\nAr norite pakartoti?", "Žaidimo pabaiga", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    likospejimu = 0;
                    
                }

            }
            else
            {
                label2.Visible = true;
                label2.Text = "Neatspėjote. Bandykite dar karta";
                label2.BackColor = Color.Red;
            }


            textBox1.Visible = true;
            if (likospejimu < 10)
            {
                textBox1.Text = "Liko spėjimu: " + (10 - likospejimu);
                likospejimu++;
            }
            else if (likospejimu == 10)
            {
                textBox1.Text = "Paskutinis spėjimas! ";
                textBox1.BackColor = Color.Orange;
                likospejimu++;
            }




        } 




        private void label2_Click(object sender, EventArgs e)
        {
       //     label2.Text = "Atspejote!!!";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // this.Hide();
            Form2 forma2 = new Form2();
            forma2.ShowDialog();
        }

        private void gamers_name_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
