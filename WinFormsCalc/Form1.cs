using System;
using System.Windows.Forms;

namespace WinFormsCalculator
{
    public class Form1 : Form
    {
        TextBox txtDisplay;
        double value = 0;
        string operation = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            this.Text = "Calculator";
            this.Size = new System.Drawing.Size(300, 400);

            txtDisplay = new TextBox();
            txtDisplay.Font = new System.Drawing.Font("Arial", 20);
            txtDisplay.Text = "0";
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            txtDisplay.Dock = DockStyle.Top;
            this.Controls.Add(txtDisplay);

            string[] buttons = {
                "7","8","9","/",
                "4","5","6","*",
                "1","2","3","-",
                "0","C","=","+"
            };

            int x = 10, y = 60;
            int count = 0;

            foreach (var txt in buttons)
            {
                Button btn = new Button();
                btn.Text = txt;
                btn.Size = new System.Drawing.Size(60, 40);
                btn.Location = new System.Drawing.Point(x, y);

                if (txt == "+" || txt == "-" || txt == "*" || txt == "/")
                    btn.Click += operator_Click;
                else if (txt == "=")
                    btn.Click += equals_Click;
                else if (txt == "C")
                    btn.Click += clear_Click;
                else
                    btn.Click += number_Click;

                this.Controls.Add(btn);

                x += 65;
                count++;
                if (count % 4 == 0)
                {
                    x = 10;
                    y += 45;
                }
            }
        }

        void number_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "0") || isOperationPerformed)
                txtDisplay.Clear();

            isOperationPerformed = false;
            Button btn = (Button)sender;
            txtDisplay.Text += btn.Text;
        }

        void operator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            operation = btn.Text;
            value = Double.Parse(txtDisplay.Text);
            isOperationPerformed = true;
        }

        void equals_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+": txtDisplay.Text = (value + Double.Parse(txtDisplay.Text)).ToString(); break;
                case "-": txtDisplay.Text = (value - Double.Parse(txtDisplay.Text)).ToString(); break;
                case "*": txtDisplay.Text = (value * Double.Parse(txtDisplay.Text)).ToString(); break;
                case "/": txtDisplay.Text = (value / Double.Parse(txtDisplay.Text)).ToString(); break;
            }
        }

        void clear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            value = 0;
        }
    }
}
