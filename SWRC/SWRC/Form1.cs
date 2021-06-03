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
        #region Variables
        private string rune1 = "";
        private string rune2 = "";
        private string rune3 = "";
        private string supply1 = "";
        private string supply2 = "";
        private string supply3 = "";
        private string supply4 = "";

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Menu Options

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Use supplies to calculate the number of runes you can craft!";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Cancel)
            {
                lbl_TextToUser.Text = "Choose an option above!";
                grp_Runes.Visible = false;
                grp_BalanceOption.Visible = false;
                grp_Supplies.Visible = false;
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
                lbl_TextToUser.Text = "Choose an option above!";
                grp_Runes.Visible = false;
                grp_BalanceOption.Visible = false;
                grp_Supplies.Visible = false;
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
                lbl_TextToUser.Text = "Choose an option above!";
                grp_Runes.Visible = false;
                grp_BalanceOption.Visible = false;
                grp_Supplies.Visible = false;
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

        #endregion

        #region Radial Options

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

        #endregion


        #region Helper Methods

        private void TextClear(TextBox box)
        {
            box.Text = string.Empty;
        }

        private Boolean ToggleVisible(Boolean state)
        {
            return (state ? !state : state) ;
        }

        #endregion

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            rune1 = txt_Rune1.Text;
            rune2 = txt_Rune2.Text;
            rune3 = txt_Rune3.Text;
            supply1 = txt_Supply1.Text;
            supply2 = txt_Supply2.Text;
            supply3 = txt_Supply3.Text;
            supply4 = txt_Supply4.Text;

            
        }
    }
}
