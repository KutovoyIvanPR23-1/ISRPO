using System;
using System.Windows.Forms;

namespace CezarShiphr
{
    public partial class s : Form
    {
        string ruso = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string ingles = "abcdefghijklmnopqrstuvwxyz";

        public s()
        {
            InitializeComponent();
            nudShift.Value = 3;
        }

        private void btnShifr_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.ToLower();
            if (String.IsNullOrEmpty(input) )
            {
                MessageBox.Show("Введите текст!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int shift = Convert.ToInt32(nudShift.Value);
            switch (cbxLengua.SelectedIndex)
            {
                case 0:
                    txtOutput.Text = shifrRuso(input, shift); 
                    break;
                case 1:
                    txtOutput.Text = shifrIngles(input, shift);
                    break;
                case -1:
                    MessageBox.Show("Выберите язык!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        public string shifrRuso(string text, int shift)
        {
            string output = "";
            foreach (char ch in text)
            {
                int index = ruso.IndexOf(ch);
                output += index == -1 ? ch : ruso[(index + shift) % 33];
            }
            return output;
        }
        public string shifrIngles(string text, int shift)
        {
            string output = "";
            foreach (char ch in text)
            {
                int index = ingles.IndexOf(ch);
                output += index == -1 ? ch : ingles[(index + shift) % 26];
            }
            return output;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = txtOutput.Text = "";
            nudShift.Value = 3;
            cbxLengua.SelectedIndex = -1;
        }

        private void btnDeshifr_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.ToLower();
            if (String.IsNullOrEmpty(input))
            {
                MessageBox.Show("Введите текст!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int shift = -Convert.ToInt32(nudShift.Value);
            switch (cbxLengua.SelectedIndex)
            {
                case 0:
                    txtOutput.Text = shifrRuso(input, shift);
                    break;
                case 1:
                    txtOutput.Text = shifrIngles(input, shift);
                    break;
                case -1:
                    MessageBox.Show("Выберите язык!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
