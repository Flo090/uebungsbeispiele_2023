using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class FormMain : Form
    {
        private double _zahl1;
        private double _zahl2;
        private bool _operatorClicked;
        private string _operator;

        public FormMain()
        {
            InitializeComponent();

            _zahl1 = 0;
            _zahl2 = 0;
            _operatorClicked = false;
            lbl_ausgabe.Text = "0";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;

            if (!_operatorClicked)
            {
                if (lbl_ausgabe.Text == "0")
                {
                    lbl_ausgabe.Text = clickedButton.Text;
                }
                else
                {
                    lbl_ausgabe.Text += clickedButton.Text;
                }
                _zahl1 = double.Parse(lbl_ausgabe.Text);
                lbl_zahl1.Text = "" + _zahl1;
            }
            else
            {
                if (lbl_ausgabe.Text == Convert.ToString(_zahl1))
                {
                    lbl_ausgabe.Text = clickedButton.Text;
                }
                else
                {
                    lbl_ausgabe.Text += clickedButton.Text;
                }
                _zahl2 = double.Parse(lbl_ausgabe.Text);
                lbl_zahl2.Text = "" + _zahl2;
            }
        }

        private void btn_operator_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;

            _operator = clickedButton.Text;
            _operatorClicked = true;
        }

        private void btn_komma_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            string lblAusgabe = lbl_ausgabe.Text;

            if (_operatorClicked)
            {
                lbl_ausgabe.Text = "0";
                lbl_ausgabe.Text += clickedButton.Text;
            }
            else
            {
                if (!lblAusgabe.Contains(","))
                {
                    lbl_ausgabe.Text += clickedButton.Text;
                }
            }
        }

        private void btn_gleich_Click(object sender, EventArgs e)
        {
            switch (_operator)
            {
                case "+":
                    lbl_ausgabe.Text = "" + (_zahl1 + _zahl2);
                    _zahl1 = _zahl1 + _zahl2;
                    break;

                case "-":
                    lbl_ausgabe.Text = "" + (_zahl1 - _zahl2);
                    _zahl1 = _zahl1 - _zahl2;
                    break;

                case "*":
                    lbl_ausgabe.Text = "" + (_zahl1 * _zahl2);
                    _zahl1 = _zahl1 * _zahl2;
                    break;

                case "/":
                    lbl_ausgabe.Text = "" + (_zahl1 / _zahl2);
                    _zahl1 = _zahl1 / _zahl2;
                    break;

                default:
                    break;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            _zahl1 = 0;
            _zahl2 = 0;
            _operatorClicked = false;
            lbl_ausgabe.Text = "0";
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lbl_ausgabe.Text.Length > 1)
            {
                lbl_ausgabe.Text = lbl_ausgabe.Text.Remove(lbl_ausgabe.Text.Length - 1, 1);
            }
            else
            {
                lbl_ausgabe.Text = "0";
            }
        }
    }
}
