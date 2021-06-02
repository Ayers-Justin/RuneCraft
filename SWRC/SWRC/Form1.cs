using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWRC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Use supplies to calculate the number of runes you can craft!";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Cancel)
            {
                
            }
            else
            {
                lbl_TextToUser.Text = "Enter your rune type in Rune 1!";
                grp_BalanceOption.Visible = false; ;
                grp_Runes.Visible = true;
                lbl_Rune1.Visible = true;
                lbl_Rune2.Visible = false;
                lbl_Rune3.Visible = false;
                txt_Rune1.Visible = true;
                txt_Rune2.Visible = false;
                txt_Rune3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Determine how many supplies you need to craft a set number of runes!";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Cancel)
            {
                
            }
            else
            {
                lbl_TextToUser.Text = "Enter the rune you want to craft in Rune 1!";
                grp_BalanceOption.Visible = false;
                grp_Runes.Visible = true;
                lbl_Rune1.Visible = true;
                lbl_Rune2.Visible = false;
                lbl_Rune3.Visible = false;
                txt_Rune1.Visible = true;
                txt_Rune2.Visible = false;
                txt_Rune3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Use supplies to optimize between types of runes to craft! (Cairos Only)";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Cancel)
            {
                
            }
            else
            {
                lbl_TextToUser.Text = "Enter the runes in the Rune Choice box.";
                grp_Runes.Visible = true;
                grp_BalanceOption.Visible = true;
                lbl_Rune1.Visible = false;
                txt_Rune1.Visible = false;

            }
        }

        private void rad_Option1_CheckedChanged(object sender, EventArgs e)
        {
            lbl_Rune1.Visible = true;
            lbl_Rune2.Visible = true;
            lbl_Rune3.Visible = false;
            txt_Rune1.Visible = true;
            txt_Rune2.Visible = true;
            txt_Rune3.Visible = false;
        }

        private void rad_Option2_CheckedChanged(object sender, EventArgs e)
        {
            lbl_Rune1.Visible = true;
            lbl_Rune2.Visible = true;
            lbl_Rune3.Visible = true;
            txt_Rune1.Visible = true;
            txt_Rune2.Visible = true;
            txt_Rune3.Visible = true;
        }
    }
}
