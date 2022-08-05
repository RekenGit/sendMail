using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wyslijMaila
{
    public partial class Form1 : Form
    {
        bool badend = false;

        string mail1 = "";
        string mail2 = "";
        public Form1()
        {
            InitializeComponent();
            textOd.Text = mail2;
            textDo.Text = mail1;
        }

        private void button1_Click(object sender, EventArgs e) //WYSLIJ
        {
            MailMessage msg=null;
            try
            {
                msg = new MailMessage(textOd.Text, textDo.Text, textTitle.Text, textMail.Text);
                msg.IsBodyHtml = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Błędny mail");
                badend = true;
            }
            if (!badend)
            {
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential(textOd.Text, textPass.Text);
                sc.Credentials = cre;
                sc.EnableSsl = true;
                try
                {
                    sc.Send(msg);
                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd z logowaniem sie do maila");
                }
                MessageBox.Show("Mail został wysłany na adres " + textDo.Text);
            }
        }
    }
}
