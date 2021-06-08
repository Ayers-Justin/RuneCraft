
namespace SWRC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_CalcRune = new System.Windows.Forms.Button();
            this.btn_CalcSup = new System.Windows.Forms.Button();
            this.btn_CalcBalance = new System.Windows.Forms.Button();
            this.txt_UserIn = new System.Windows.Forms.TextBox();
            this.grp_Supplies = new System.Windows.Forms.GroupBox();
            this.txt_Supply4 = new System.Windows.Forms.TextBox();
            this.txt_Supply1 = new System.Windows.Forms.TextBox();
            this.txt_Supply3 = new System.Windows.Forms.TextBox();
            this.txt_Supply2 = new System.Windows.Forms.TextBox();
            this.lbl_Supply4 = new System.Windows.Forms.Label();
            this.lbl_Supply3 = new System.Windows.Forms.Label();
            this.lbl_Supply2 = new System.Windows.Forms.Label();
            this.lbl_Supply1 = new System.Windows.Forms.Label();
            this.lbl_TextToUser = new System.Windows.Forms.Label();
            this.grp_Runes = new System.Windows.Forms.GroupBox();
            this.lbl_Rune3 = new System.Windows.Forms.Label();
            this.txt_Rune3 = new System.Windows.Forms.TextBox();
            this.txt_Rune2 = new System.Windows.Forms.TextBox();
            this.txt_Rune1 = new System.Windows.Forms.TextBox();
            this.lbl_Rune2 = new System.Windows.Forms.Label();
            this.lbl_Rune1 = new System.Windows.Forms.Label();
            this.rad_Option1 = new System.Windows.Forms.RadioButton();
            this.rad_Option2 = new System.Windows.Forms.RadioButton();
            this.grp_BalanceOption = new System.Windows.Forms.GroupBox();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.grp_Supplies.SuspendLayout();
            this.grp_Runes.SuspendLayout();
            this.grp_BalanceOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CalcRune
            // 
            this.btn_CalcRune.Location = new System.Drawing.Point(0, 0);
            this.btn_CalcRune.Name = "btn_CalcRune";
            this.btn_CalcRune.Size = new System.Drawing.Size(106, 23);
            this.btn_CalcRune.TabIndex = 1;
            this.btn_CalcRune.Text = "Calculate Runes";
            this.btn_CalcRune.UseVisualStyleBackColor = true;
            this.btn_CalcRune.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_CalcSup
            // 
            this.btn_CalcSup.Location = new System.Drawing.Point(112, 0);
            this.btn_CalcSup.Name = "btn_CalcSup";
            this.btn_CalcSup.Size = new System.Drawing.Size(118, 23);
            this.btn_CalcSup.TabIndex = 2;
            this.btn_CalcSup.Text = "Calculate Supplies";
            this.btn_CalcSup.UseVisualStyleBackColor = true;
            this.btn_CalcSup.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_CalcBalance
            // 
            this.btn_CalcBalance.Location = new System.Drawing.Point(236, 0);
            this.btn_CalcBalance.Name = "btn_CalcBalance";
            this.btn_CalcBalance.Size = new System.Drawing.Size(115, 23);
            this.btn_CalcBalance.TabIndex = 3;
            this.btn_CalcBalance.Text = "Calculate Balance";
            this.btn_CalcBalance.UseVisualStyleBackColor = true;
            this.btn_CalcBalance.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_UserIn
            // 
            this.txt_UserIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_UserIn.Location = new System.Drawing.Point(12, 351);
            this.txt_UserIn.Name = "txt_UserIn";
            this.txt_UserIn.Size = new System.Drawing.Size(246, 23);
            this.txt_UserIn.TabIndex = 4;
            this.txt_UserIn.Text = "0";
            // 
            // grp_Supplies
            // 
            this.grp_Supplies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_Supplies.Controls.Add(this.txt_Supply4);
            this.grp_Supplies.Controls.Add(this.txt_Supply1);
            this.grp_Supplies.Controls.Add(this.txt_Supply3);
            this.grp_Supplies.Controls.Add(this.txt_Supply2);
            this.grp_Supplies.Controls.Add(this.lbl_Supply4);
            this.grp_Supplies.Controls.Add(this.lbl_Supply3);
            this.grp_Supplies.Controls.Add(this.lbl_Supply2);
            this.grp_Supplies.Controls.Add(this.lbl_Supply1);
            this.grp_Supplies.Location = new System.Drawing.Point(148, 29);
            this.grp_Supplies.Name = "grp_Supplies";
            this.grp_Supplies.Size = new System.Drawing.Size(192, 162);
            this.grp_Supplies.TabIndex = 5;
            this.grp_Supplies.TabStop = false;
            this.grp_Supplies.Text = "Supplies";
            this.grp_Supplies.Visible = false;
            // 
            // txt_Supply4
            // 
            this.txt_Supply4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Supply4.Location = new System.Drawing.Point(118, 105);
            this.txt_Supply4.Name = "txt_Supply4";
            this.txt_Supply4.Size = new System.Drawing.Size(68, 23);
            this.txt_Supply4.TabIndex = 8;
            this.txt_Supply4.Text = "0";
            this.txt_Supply4.Visible = false;
            // 
            // txt_Supply1
            // 
            this.txt_Supply1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Supply1.Location = new System.Drawing.Point(118, 18);
            this.txt_Supply1.Name = "txt_Supply1";
            this.txt_Supply1.Size = new System.Drawing.Size(68, 23);
            this.txt_Supply1.TabIndex = 5;
            this.txt_Supply1.Text = "0";
            this.txt_Supply1.Visible = false;
            // 
            // txt_Supply3
            // 
            this.txt_Supply3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Supply3.Location = new System.Drawing.Point(118, 76);
            this.txt_Supply3.Name = "txt_Supply3";
            this.txt_Supply3.Size = new System.Drawing.Size(68, 23);
            this.txt_Supply3.TabIndex = 7;
            this.txt_Supply3.Text = "0";
            this.txt_Supply3.Visible = false;
            // 
            // txt_Supply2
            // 
            this.txt_Supply2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Supply2.Location = new System.Drawing.Point(118, 47);
            this.txt_Supply2.Name = "txt_Supply2";
            this.txt_Supply2.Size = new System.Drawing.Size(68, 23);
            this.txt_Supply2.TabIndex = 6;
            this.txt_Supply2.Text = "0";
            this.txt_Supply2.Visible = false;
            // 
            // lbl_Supply4
            // 
            this.lbl_Supply4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Supply4.AutoSize = true;
            this.lbl_Supply4.Location = new System.Drawing.Point(6, 113);
            this.lbl_Supply4.Name = "lbl_Supply4";
            this.lbl_Supply4.Size = new System.Drawing.Size(52, 15);
            this.lbl_Supply4.TabIndex = 3;
            this.lbl_Supply4.Text = "Supply 4";
            this.lbl_Supply4.Visible = false;
            // 
            // lbl_Supply3
            // 
            this.lbl_Supply3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Supply3.AutoSize = true;
            this.lbl_Supply3.Location = new System.Drawing.Point(6, 84);
            this.lbl_Supply3.Name = "lbl_Supply3";
            this.lbl_Supply3.Size = new System.Drawing.Size(52, 15);
            this.lbl_Supply3.TabIndex = 2;
            this.lbl_Supply3.Text = "Supply 3";
            this.lbl_Supply3.Visible = false;
            // 
            // lbl_Supply2
            // 
            this.lbl_Supply2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Supply2.AutoSize = true;
            this.lbl_Supply2.Location = new System.Drawing.Point(6, 55);
            this.lbl_Supply2.Name = "lbl_Supply2";
            this.lbl_Supply2.Size = new System.Drawing.Size(52, 15);
            this.lbl_Supply2.TabIndex = 1;
            this.lbl_Supply2.Text = "Supply 2";
            this.lbl_Supply2.Visible = false;
            // 
            // lbl_Supply1
            // 
            this.lbl_Supply1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Supply1.AutoSize = true;
            this.lbl_Supply1.Location = new System.Drawing.Point(6, 26);
            this.lbl_Supply1.Name = "lbl_Supply1";
            this.lbl_Supply1.Size = new System.Drawing.Size(52, 15);
            this.lbl_Supply1.TabIndex = 0;
            this.lbl_Supply1.Text = "Supply 1";
            this.lbl_Supply1.Visible = false;
            // 
            // lbl_TextToUser
            // 
            this.lbl_TextToUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_TextToUser.Location = new System.Drawing.Point(12, 29);
            this.lbl_TextToUser.Name = "lbl_TextToUser";
            this.lbl_TextToUser.Size = new System.Drawing.Size(130, 240);
            this.lbl_TextToUser.TabIndex = 6;
            this.lbl_TextToUser.Text = "Choose an option above!";
            // 
            // grp_Runes
            // 
            this.grp_Runes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_Runes.Controls.Add(this.lbl_Rune3);
            this.grp_Runes.Controls.Add(this.txt_Rune3);
            this.grp_Runes.Controls.Add(this.txt_Rune2);
            this.grp_Runes.Controls.Add(this.txt_Rune1);
            this.grp_Runes.Controls.Add(this.lbl_Rune2);
            this.grp_Runes.Controls.Add(this.lbl_Rune1);
            this.grp_Runes.Location = new System.Drawing.Point(200, 197);
            this.grp_Runes.Name = "grp_Runes";
            this.grp_Runes.Size = new System.Drawing.Size(140, 138);
            this.grp_Runes.TabIndex = 7;
            this.grp_Runes.TabStop = false;
            this.grp_Runes.Text = "Rune Choice";
            this.grp_Runes.Visible = false;
            // 
            // lbl_Rune3
            // 
            this.lbl_Rune3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Rune3.AutoSize = true;
            this.lbl_Rune3.Location = new System.Drawing.Point(6, 87);
            this.lbl_Rune3.Name = "lbl_Rune3";
            this.lbl_Rune3.Size = new System.Drawing.Size(43, 15);
            this.lbl_Rune3.TabIndex = 5;
            this.lbl_Rune3.Text = "Rune 3";
            this.lbl_Rune3.Visible = false;
            // 
            // txt_Rune3
            // 
            this.txt_Rune3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Rune3.Location = new System.Drawing.Point(66, 79);
            this.txt_Rune3.Name = "txt_Rune3";
            this.txt_Rune3.Size = new System.Drawing.Size(74, 23);
            this.txt_Rune3.TabIndex = 4;
            this.txt_Rune3.Visible = false;
            // 
            // txt_Rune2
            // 
            this.txt_Rune2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Rune2.Location = new System.Drawing.Point(66, 49);
            this.txt_Rune2.Name = "txt_Rune2";
            this.txt_Rune2.Size = new System.Drawing.Size(74, 23);
            this.txt_Rune2.TabIndex = 3;
            this.txt_Rune2.Visible = false;
            // 
            // txt_Rune1
            // 
            this.txt_Rune1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Rune1.Location = new System.Drawing.Point(66, 18);
            this.txt_Rune1.Name = "txt_Rune1";
            this.txt_Rune1.Size = new System.Drawing.Size(74, 23);
            this.txt_Rune1.TabIndex = 2;
            this.txt_Rune1.Visible = false;
            // 
            // lbl_Rune2
            // 
            this.lbl_Rune2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Rune2.AutoSize = true;
            this.lbl_Rune2.Location = new System.Drawing.Point(6, 57);
            this.lbl_Rune2.Name = "lbl_Rune2";
            this.lbl_Rune2.Size = new System.Drawing.Size(43, 15);
            this.lbl_Rune2.TabIndex = 1;
            this.lbl_Rune2.Text = "Rune 2";
            this.lbl_Rune2.Visible = false;
            // 
            // lbl_Rune1
            // 
            this.lbl_Rune1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Rune1.AutoSize = true;
            this.lbl_Rune1.Location = new System.Drawing.Point(6, 26);
            this.lbl_Rune1.Name = "lbl_Rune1";
            this.lbl_Rune1.Size = new System.Drawing.Size(43, 15);
            this.lbl_Rune1.TabIndex = 0;
            this.lbl_Rune1.Text = "Rune 1";
            this.lbl_Rune1.Visible = false;
            // 
            // rad_Option1
            // 
            this.rad_Option1.AutoSize = true;
            this.rad_Option1.Location = new System.Drawing.Point(6, 22);
            this.rad_Option1.Name = "rad_Option1";
            this.rad_Option1.Size = new System.Drawing.Size(31, 19);
            this.rad_Option1.TabIndex = 8;
            this.rad_Option1.TabStop = true;
            this.rad_Option1.Text = "2";
            this.rad_Option1.UseVisualStyleBackColor = true;
            this.rad_Option1.CheckedChanged += new System.EventHandler(this.rad_Option1_CheckedChanged);
            // 
            // rad_Option2
            // 
            this.rad_Option2.AutoSize = true;
            this.rad_Option2.Location = new System.Drawing.Point(99, 22);
            this.rad_Option2.Name = "rad_Option2";
            this.rad_Option2.Size = new System.Drawing.Size(31, 19);
            this.rad_Option2.TabIndex = 9;
            this.rad_Option2.TabStop = true;
            this.rad_Option2.Text = "3";
            this.rad_Option2.UseVisualStyleBackColor = true;
            this.rad_Option2.CheckedChanged += new System.EventHandler(this.rad_Option2_CheckedChanged);
            // 
            // grp_BalanceOption
            // 
            this.grp_BalanceOption.Controls.Add(this.rad_Option1);
            this.grp_BalanceOption.Controls.Add(this.rad_Option2);
            this.grp_BalanceOption.Location = new System.Drawing.Point(12, 289);
            this.grp_BalanceOption.Name = "grp_BalanceOption";
            this.grp_BalanceOption.Size = new System.Drawing.Size(181, 46);
            this.grp_BalanceOption.TabIndex = 10;
            this.grp_BalanceOption.TabStop = false;
            this.grp_BalanceOption.Text = "Number of runes to balance";
            this.grp_BalanceOption.Visible = false;
            // 
            // btn_Enter
            // 
            this.btn_Enter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Enter.Location = new System.Drawing.Point(266, 351);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(68, 23);
            this.btn_Enter.TabIndex = 11;
            this.btn_Enter.Text = "Enter";
            this.btn_Enter.UseVisualStyleBackColor = true;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 386);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.grp_BalanceOption);
            this.Controls.Add(this.grp_Runes);
            this.Controls.Add(this.lbl_TextToUser);
            this.Controls.Add(this.grp_Supplies);
            this.Controls.Add(this.txt_UserIn);
            this.Controls.Add(this.btn_CalcBalance);
            this.Controls.Add(this.btn_CalcSup);
            this.Controls.Add(this.btn_CalcRune);
            this.MinimumSize = new System.Drawing.Size(368, 425);
            this.Name = "Form1";
            this.Text = "Summoners War Rune Crafting";
            this.grp_Supplies.ResumeLayout(false);
            this.grp_Supplies.PerformLayout();
            this.grp_Runes.ResumeLayout(false);
            this.grp_Runes.PerformLayout();
            this.grp_BalanceOption.ResumeLayout(false);
            this.grp_BalanceOption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_CalcRune;
        private System.Windows.Forms.Button btn_CalcSup;
        private System.Windows.Forms.Button btn_CalcBalance;
        private System.Windows.Forms.TextBox txt_UserIn;
        private System.Windows.Forms.GroupBox grp_Supplies;
        private System.Windows.Forms.TextBox txt_Supply4;
        private System.Windows.Forms.TextBox txt_Supply3;
        private System.Windows.Forms.TextBox txt_Supply2;
        private System.Windows.Forms.TextBox txt_Supply1;
        private System.Windows.Forms.Label lbl_Supply4;
        private System.Windows.Forms.Label lbl_Supply3;
        private System.Windows.Forms.Label lbl_Supply2;
        private System.Windows.Forms.Label lbl_Supply1;
        private System.Windows.Forms.Label lbl_TextToUser;
        private System.Windows.Forms.GroupBox grp_Runes;
        private System.Windows.Forms.Label lbl_Rune3;
        private System.Windows.Forms.TextBox txt_Rune3;
        private System.Windows.Forms.TextBox txt_Rune2;
        private System.Windows.Forms.TextBox txt_Rune1;
        private System.Windows.Forms.Label lbl_Rune2;
        private System.Windows.Forms.Label lbl_Rune1;
        private System.Windows.Forms.RadioButton rad_Option1;
        private System.Windows.Forms.RadioButton rad_Option2;
        private System.Windows.Forms.GroupBox grp_BalanceOption;
        private System.Windows.Forms.Button btn_Enter;
    }
}

