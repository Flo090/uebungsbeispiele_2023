using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taschenrechner.OperatorTypes;

namespace Taschenrechner
{
    public partial class FormMain : Form
    {
        private double _zahl1;
        private double _zahl2;
        private bool _operatorClicked;
        private string _operator;
        private bool _clear;

        private OperatorHandler _selectedOperator;

        public FormMain()
        {
            InitializeComponent();

            _zahl1 = 0;
            _zahl2 = 0;
            _operatorClicked = false;
            _clear = false;
            lbl_ausgabe.Text = "0";

            btn_plus.Tag = new OperatorHandler(OperatorMethods.Addition);
            btn_minus.Tag = new OperatorHandler(OperatorMethods.Subtraction);
            btn_mal.Tag = new OperatorHandler(OperatorMethods.Multiplication);
            btn_geteilt.Tag = new OperatorHandler(OperatorMethods.Division);
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
            _selectedOperator = clickedButton.Tag as OperatorHandler;
            _operatorClicked = true;
        }

        private void btn_komma_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            string lblAusgabe = lbl_ausgabe.Text;

            if (!lblAusgabe.Contains(","))
            {
                lbl_ausgabe.Text += clickedButton.Text;
            }
        }

        private void btn_gleich_Click(object sender, EventArgs e)
        {
            var erg = _selectedOperator?.Invoke(_zahl1, _zahl2);
            _zahl1 = Convert.ToDouble(erg);

            lbl_ausgabe.Text = erg.ToString();
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
