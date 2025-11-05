using System;
using System.Drawing;
using System.Windows.Forms;

namespace LuckyTicket
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int number = generateNumber();
            lblClue.Text = "";
            lblOutputNumber.Text = number.ToString();
            if (numberIsLucky(number))
            {
                lblOutputIsLucky.ForeColor = Color.Green;
                lblOutputNumber.ForeColor = Color.Green;
                lblOutputIsLucky.Text = "Счастливый билет!";
            }
            else
            {
                lblOutputIsLucky.ForeColor = Color.Red;
                lblOutputNumber.ForeColor = Color.Red;
                lblOutputIsLucky.Text = "  Обычный билет  ";
            }
        }

        private int generateNumber()
        {
            return new Random().Next(100000, 1000000);
        }

        private bool numberIsLucky(int number)
        {
            int sum = 0;
            for (int i = 1; i <= 100000; i *= 10)
            {
                sum += ((int) Math.Truncate((double) number / i) % 10) * (i > 100 ? -1: 1);
            }
            return sum == 0;
        }
    }
}
