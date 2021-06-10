#region Imported libraries
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace SWRC
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// Stores all information to be processed by the calculator.
        /// </summary>
        #region Variables
        private string rune1 = "";
        private string rune2 = "";
        private string rune3 = "";
        private int supply1 = 0;
        private int supply2 = 0;
        private int supply3 = 0;
        private int supply4 = 0;
        private int numEnters = 0;
        private bool isRunes = false;
        private bool isSupplies = false;
        private bool isBalance = false;
        private int numReagents = 0;
        private string[] listRunesBalance = { "", "", "" };
        private string[] ingredients = { "", "", "", "" };
        private int[] reagentTotals = { 0, 0, 0, 0 };
        private int exclusion = 0;
        private int cost = 0;
        private int numRunes = 0;
        private int totalCost = 0;
        private int numLegend = 0;
        private bool isGiants = false;
        private bool isDragons = false;
        private bool isNecro = false;
        private static int main_cost = 18;
        private static int alt_cost = 6;
        private static int piece_cost = 12;
        private int[] giant_cost_vec = new int[] { main_cost, 0, alt_cost, piece_cost };
        private int[] dragon_cost_vec = new int[] { alt_cost, main_cost, 0, piece_cost };
        private int[] necro_cost_vec = new int[] { 0, alt_cost, main_cost, piece_cost };
        private int numRune1 = 0;
        private int numRune2 = 0;
        private int numRune3 = 0;

        #endregion

        /// <summary>
        /// Auto-generated Form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds functionality to the menu options listed at the top of the program.
        /// </summary>
        #region Menu Options

        /// <summary>
        /// Allows user to choose to calculate how many runes they can craft of a single type
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Use supplies to calculate the number of runes you can craft!";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Cancel)
            {
                SetDefaults();
                SetState(0);
            }
            else if (result == DialogResult.OK)
            {
                SetDefaults();
                isRunes = true;
                SetState(1);
            }
            else
            {
                WarnUser("unspecified");
            }
        }

        /// <summary>
        /// Allows user to choose to calculate the amount of supplie they need for a set number of a single type of rune
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Determine how many supplies you need to craft a set number of runes!";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Cancel)
            {
                SetDefaults();
                SetState(0);
            }
            else if (result == DialogResult.OK)
            {
                SetDefaults();
                isSupplies = true;
                SetState(1);
            }
            else
            {
                WarnUser("unspecified");
            }
        }

        /// <summary>
        /// Allows user to choose to calculate the optimal amount of runes they can craft given their total supplies
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Use supplies to optimize between types of runes to craft! (Cairos Only)";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Cancel)
            {
                SetDefaults();
                SetState(0);
            }
            else if(result == DialogResult.OK)
            {
                SetDefaults();
                isBalance = true;
                SetState(1);
            }
            else
            {
                WarnUser("unspecified");
            }
        }

        #endregion

        /// <summary>
        /// Adds functionality to the radio buttons when the user chooses to balance runes.
        /// </summary>
        #region Radio Options

        /// <summary>
        /// Sets the number of runes to balance to 2
        /// </summary>
        private void rad_Option1_CheckedChanged(object sender, EventArgs e)
        {
            ClearRunes();
            SetRunes(2);
            lbl_TextToUser.Text = "Type the runes you want to balance in Rune Choice, and hit enter!";
            BalanceInfo();
        }

        /// <summary>
        /// Sets the number of runes to balance to 3
        /// </summary>
        private void rad_Option2_CheckedChanged(object sender, EventArgs e)
        {
            ClearRunes();
            SetRunes(3);
            lbl_TextToUser.Text = "Type the runes you want to balance in Rune Choice, and hit enter!";
            BalanceInfo();
        }

        #endregion

        /// <summary>
        /// Methods of code that get used during multiple stages.
        /// </summary>
        #region Helper Methods

        /// <summary>
        /// Inform the user the restrictions for using Balance.
        /// </summary>
        private void BalanceInfo()
        {
            string title = "Information";
            string message = "The balance feature requires you to choose runes of different types, determined by their drop location. To use this feature, " +
                "please ensure that you are choosing runes that drop from different dungeons. Remember, this is Cairos only, so you may only choose from" +
                " Giants, Dragons, or Necropolis. Thank you!";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Method to identify where an issue has occured, and how the user might fix it.
        /// </summary>
        private void WarnUser(string error)
        {
            string message = "";
            string title = "";
            if (error.Equals("rune"))
            {
                message = "Please enter a valid rune type!";
                title = "Rune Type Error";
            }
            else if (error.Equals("number"))
            {
                supply1 = 0;
                message = "Please enter a number between 0 and 9999";
                title = "Number Error";
            }
            else if (error.Equals("numberSupplies"))
            {
                supply1 = 0;
                message = "Please enter a number between 0 and 555.";
                title = "Exceed Supplies Error";
            }
            else if (error.Equals("typeConflict"))
            {
                supply1 = 0;
                message = "Runes must be dropped from different dungeons to be balanced!";
                title = "Invalid Rune Types";
            }
            else if (error.Equals("unspecified"))
            {
                message = "An unknown error has occured.";
                title = "Unknown Error";
            }
            else
            {
                WarnUser("unspecified");
            }
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Method to clear radio button selections
        /// </summary>
        private void ClearRadio()
        {
            rad_Option1.Checked = false;
            rad_Option2.Checked = false;
        }

        /// <summary>
        /// Method to "factory reset" the settings... to be used when shifting from one function of the calculator to another
        /// </summary>
        private void SetDefaults()
        {
            rune1 = "";
            rune2 = "";
            rune3 = "";
            supply1 = 0;
            supply2 = 0;
            supply3 = 0;
            supply4 = 0;
            numEnters = 0;
            isRunes = false;
            isSupplies = false;
            isBalance = false;
            numReagents = 0;
            listRunesBalance = new string[] { "", "", "" };
            ingredients = new string[] { "", "", "", "" };
            reagentTotals = new int[] { 0, 0, 0, 0 };
            exclusion = 0;
            cost = 0;
            numRunes = 0;
            totalCost = 0;
            numLegend = 0;
            isGiants = false;
            isDragons = false;
            isNecro = false;
            main_cost = 18;
            alt_cost = 6;
            piece_cost = 12;
            giant_cost_vec = new int[] { main_cost, 0, alt_cost, piece_cost };
            dragon_cost_vec = new int[] { alt_cost, main_cost, 0, piece_cost };
            necro_cost_vec = new int[] { 0, alt_cost, main_cost, piece_cost };
            numRune1 = 0;
            numRune2 = 0;
            numRune3 = 0;
            ClearRadio();
        }

        /// <summary>
        /// Logic to determine what actions need performed at each state
        /// </summary>
        private void SetState(int num)
        {
            if (num == 0)
            {
                RemoveSupplies();
                ClearSupplies();
                RemoveRunes();
                ClearRunes();
                txt_UserIn.Visible = false;
                txt_UserIn.Text = string.Empty;
                grp_BalanceOption.Visible = false;
                lbl_TextToUser.Text = "Choose an option above!";
            }
            else if (num == 1)
            {
                numEnters = 0;
                if (isBalance)
                {
                    SetState(0);
                    grp_BalanceOption.Visible = true;
                    lbl_TextToUser.Text = "Choose the number of runes to balance below!";
                }
                else if (isSupplies)
                {
                    SetState(0);
                    lbl_TextToUser.Text = "Enter the type of rune you wish to craft in Rune 1! You can enter \"anicent\" to calculate ancient rune crafts!";
                    SetRunes(1);
                }
                else if (isRunes)
                {
                    SetState(0);
                    lbl_TextToUser.Text = "Enter your rune type in Rune 1! You can enter \"anicent\" to calculate ancient rune crafts!";
                    SetRunes(1);
                }
                else
                {
                    WarnUser("unspecified");
                }
            }
            else if (num == 2)
            {
                if (isRunes)
                {
                    rune1 = txt_Rune1.Text;
                    if (CheckRunes(rune1))
                    {
                        GetRuneInfo(rune1);
                        SetSupplies();
                        SetIngredients();
                        lbl_TextToUser.Text = "Enter the number of supplies, then hit enter!";
                    }
                    else if(!CheckRunes(rune1))
                    {
                        TextClear(txt_Rune1);
                        WarnUser("rune");
                        SetState(1);
                    }
                    else
                    {
                        WarnUser("unspecified");
                    }
                }
                else if(isSupplies)
                {
                    rune1 = txt_Rune1.Text;
                    if (CheckRunes(rune1))
                    {
                        GetRuneInfo(rune1);
                        SetSupplies();
                        SetIngredients();
                        txt_UserIn.Visible = true;
                        lbl_TextToUser.Text = "Enter the desired number of runes below, then hit enter!";
                    }
                    else if(!CheckRunes(rune1))
                    {
                        TextClear(txt_Rune1);
                        WarnUser("rune");
                        SetState(1);
                    }
                    else
                    {
                        WarnUser("unspecified");
                    }
                }
                else if (isBalance)
                {
                    if (rad_Option1.Checked)
                    {
                        rune1 = txt_Rune1.Text;
                        rune2 = txt_Rune2.Text;
                        if ((CheckRunes(rune1)) && (CheckRunes(rune2)))
                        {
                            GetRuneInfo(rune1);
                            GetRuneInfo(rune2);
                            numReagents = 4;
                            SetSupplies();
                            SetIngredients(4);
                            lbl_TextToUser.Text = "Enter the number of supplies, then hit enter!";
                        }
                        else if ((!CheckRunes(rune1)) || (!CheckRunes(rune2)))
                        {
                            if (!CheckRunes(rune1))
                            {
                                TextClear(txt_Rune1);
                                WarnUser("rune");
                                SetState(1);
                            }
                            else if (!CheckRunes(rune2))
                            {
                                TextClear(txt_Rune2);
                                WarnUser("rune");
                                SetState(1);
                            }
                            else
                            {
                                WarnUser("unspecified");
                            }
                        }
                        else
                        {
                            WarnUser("unspecified");
                        }
                    }

                    else if (rad_Option2.Checked)
                    {
                        rune1 = txt_Rune1.Text;
                        rune2 = txt_Rune2.Text;
                        rune3 = txt_Rune3.Text;
                        if ((CheckRunes(rune1)) && (CheckRunes(rune2)) && (CheckRunes(rune3)))
                        {
                            GetRuneInfo(rune1);
                            GetRuneInfo(rune2);
                            GetRuneInfo(rune3);
                            numReagents = 4;
                            SetSupplies();
                            SetIngredients(4);
                            lbl_TextToUser.Text = "Enter the number of supplies, the hit enter!";
                        }
                        else if ((!CheckRunes(rune1)) || (!CheckRunes(rune2)) || (!CheckRunes(rune3)))
                        {
                            if (!CheckRunes(rune1))
                            {
                                TextClear(txt_Rune1);
                                WarnUser("rune");
                                SetState(1);
                            }
                            else if(!CheckRunes(rune2))
                            {
                                TextClear(txt_Rune2);
                                WarnUser("rune");
                                SetState(1);
                            }
                            else if (!CheckRunes(rune3))
                            {
                                TextClear(txt_Rune3);
                                WarnUser("rune");
                                SetState(1);
                            }
                            else
                            {
                                WarnUser("unspecified");
                            }
                        }
                        else
                        {
                            WarnUser("unspecified");
                        }
                    }
                    else
                    {
                        WarnUser("unspecified");
                    }
                }
            }
            else if (num == 3)
            {
                StoreSupplies();
                if (supply1 != 0)
                {
                    if (isRunes)
                    {
                        CalculateRunes();
                        MessageOut("runes");

                    }
                    else if (isSupplies)
                    {
                        CalculateSupplies();
                        MessageOut("supplies");
                    }
                    else if (isBalance)
                    {
                        OrderRunes();
                        CalculateBalance(new bool[] { isGiants, isDragons, isNecro });
                        MessageOut("balance");
                    }
                    else
                    {
                        WarnUser("unspecified");
                    }
                }
            }
            else
            {
                WarnUser("unspecified");
            }
        }

        /// <summary>
        /// Reorganizes the runes that the user entered into the "correct" order for the calculator to make sense of.
        /// </summary>
        private void OrderRunes()
        {
            string[] giants = { "despair", "energy", "fatal", "blade", "swift" };
            string[] dragons = { "violent", "focus", "guard", "endure", "shield", "revenge" };
            string[] necro = { "rage", "will", "vampire", "nemesis", "destroy" };
            if (rad_Option1.Checked)
            {
                rune1 = rune1.ToLower();
                rune2 = rune2.ToLower();
                string temp = "";
                if (isGiants && isDragons)
                {
                    foreach (string x in giants)
                    {
                        if (rune2.Contains(x))
                        {
                            temp = rune1;
                            rune1 = rune2;
                            rune2 = temp;
                        }
                    }
                }
                else if (isGiants && isNecro)
                {
                    foreach (string x in giants)
                    {
                        if (rune2.Contains(x))
                        {
                            temp = rune1;
                            rune1 = rune2;
                            rune2 = temp;
                        }
                    }
                }
                else if (isDragons && isNecro)
                {
                    foreach (string x in dragons)
                    {
                        if (rune2.Contains(x))
                        {
                            temp = rune1;
                            rune1 = rune2;
                            rune2 = temp;
                        }
                    }
                }
                else if (isGiants || isDragons || isNecro)
                {
                    WarnUser("typeConflict");
                    ClearRunes();
                    SetState(2);
                }
                else
                {
                    WarnUser("unspecified");
                }
                txt_Rune1.Text = rune1;
                txt_Rune2.Text = rune2;
            }
            else if (rad_Option2.Checked)
            {
                rune1 = rune1.ToLower();
                rune2 = rune2.ToLower();
                rune3 = rune3.ToLower();
                string temp = "";
                if (isGiants && isDragons && isNecro)
                {
                    foreach (string x in giants)
                    {
                        if (rune3.Contains(x))
                        {
                            temp = rune1;
                            rune1 = rune3;
                            rune3 = temp;
                        }
                        if (rune2.Contains(x))
                        {
                            temp = rune1;
                            rune1 = rune2;
                            rune2 = temp;
                        }
                    }
                    foreach (string x in dragons)
                    {
                        if (rune1.Contains(x))
                        {
                            temp = rune2;
                            rune2 = rune1;
                            rune1 = temp;
                        }
                        if (rune3.Contains(x))
                        {
                            temp = rune2;
                            rune2 = rune3;
                            rune3 = temp;
                        }
                    }
                    foreach (string x in necro)
                    {
                        if (rune1.Contains(x))
                        {
                            temp = rune3;
                            rune3 = rune1;
                            rune1 = temp;
                        }
                        if (rune2.Contains(x))
                        {
                            temp = rune3;
                            rune3 = rune2;
                            rune2 = temp;
                        }
                    }
                }
                else if(!isGiants || !isDragons || !isNecro)
                {
                    WarnUser("typeConflict");
                    ClearRunes();
                    SetState(2);
                }
                else
                {
                    WarnUser("unspecified");
                }
                txt_Rune1.Text = rune1;
                txt_Rune2.Text = rune2;
                txt_Rune3.Text = rune3;
            }
            else
            {
                WarnUser("unspecified");
            }
        }

        /// <summary>
        /// Method to store the inputs from user in supply group for the calculator to use later.
        /// </summary>
        private void StoreSupplies()
        {
            if (!isSupplies)
            {
                if (numReagents == 2)
                {
                    supply1 = GetInput(txt_Supply1.Text, txt_Supply1);
                    supply2 = GetInput(txt_Supply2.Text, txt_Supply2);
                }
                else if (numReagents == 3)
                {
                    supply1 = GetInput(txt_Supply1.Text, txt_Supply1);
                    supply2 = GetInput(txt_Supply2.Text, txt_Supply2);
                    supply3 = GetInput(txt_Supply3.Text, txt_Supply3);
                }
                else if (numReagents == 4)
                {
                    supply1 = GetInput(txt_Supply1.Text, txt_Supply1);
                    supply2 = GetInput(txt_Supply2.Text, txt_Supply2);
                    supply3 = GetInput(txt_Supply3.Text, txt_Supply3);
                    supply4 = GetInput(txt_Supply4.Text, txt_Supply4);
                }
            }
        }

        /// <summary>
        /// Method to empty all supply values
        /// </summary>
        private void ClearSupplies()
        {
            txt_Supply1.Text = string.Empty;
            txt_Supply2.Text = string.Empty;
            txt_Supply3.Text = string.Empty;
            txt_Supply4.Text = string.Empty;
        }

        /// <summary>
        /// Method to empty all rune values
        /// </summary>
        private void ClearRunes()
        {
            txt_Rune1.Text = string.Empty;
            txt_Rune2.Text = string.Empty;
            txt_Rune3.Text = string.Empty;
        }

        /// <summary>
        /// Method to set visibility of runes to false
        /// </summary>
        private void RemoveRunes()
        {
            grp_Runes.Visible = false;
            lbl_Rune1.Visible = false;
            lbl_Rune2.Visible = false;
            lbl_Rune3.Visible = false;
            txt_Rune1.Visible = false;
            txt_Rune2.Visible = false;
            txt_Rune3.Visible = false;
        }

        /// <summary>
        /// Sets the number of runes visible based on the chosen option.
        /// </summary>
        private void SetRunes(int num)
        {
            if(num == 1)
            {
                grp_Runes.Visible = true;
                lbl_Rune1.Visible = true;
                lbl_Rune2.Visible = false;
                lbl_Rune3.Visible = false;
                txt_Rune1.Visible = true;
                txt_Rune2.Visible = false;
                txt_Rune3.Visible = false;
            }
            else if(num == 2)
            {
                grp_Runes.Visible = true;
                lbl_Rune1.Visible = true;
                lbl_Rune2.Visible = true;
                lbl_Rune3.Visible = false;
                txt_Rune1.Visible = true;
                txt_Rune2.Visible = true;
                txt_Rune3.Visible = false;
            }
            else if (num == 3)
            {
                grp_Runes.Visible = true;
                lbl_Rune1.Visible = true;
                lbl_Rune2.Visible = true;
                lbl_Rune3.Visible = true;
                txt_Rune1.Visible = true;
                txt_Rune2.Visible = true;
                txt_Rune3.Visible = true;
            }
            else
            {
                WarnUser("unspecified");
            }
        }

        /// <summary>
        /// Method to convert the first letter to a capitalized
        /// </summary>
        public string FirstLetterToUpper(string str)
        {
            if (str == null)
            {
                return null;
            }
            else if (str.Length > 1)
            {
                str = str.ToLower();
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            else
            {
                WarnUser("unspecified");
            }
            return str.ToUpper();
        }

        ///<summary>
        /// Method to send the final information to the user.
        /// </summary>
        private void MessageOut(string messageType)
        {
            string toFormat = totalCost.ToString("#,##0");
            if (messageType.Equals("runes"))
            {
                rune1 = FirstLetterToUpper(rune1);
                lbl_TextToUser.Text = "You can craft " + numRunes + " " + rune1 + " runes!" + '\n'
                    + "It will cost " + toFormat + " mana stones! Be sure to save up!" + '\n' +
                    "You should get approximately " + numLegend + " legendary 6* runes!";
            }

            else if (messageType.Equals("supplies"))
            {
                rune1 = FirstLetterToUpper(rune1);
                lbl_TextToUser.Text = "It will cost " + toFormat + " mana stones! Be sure to save up!"
                + '\n' + "You should get approximately " + numLegend + " legendary 6* runes!";
                txt_Supply1.Text = reagentTotals[0].ToString();
                txt_Supply2.Text = reagentTotals[1].ToString();
                txt_Supply3.Text = reagentTotals[2].ToString();
                txt_Supply4.Text = reagentTotals[3].ToString();
            }
            else if (messageType.Equals("balance"))
            {
                if (rad_Option1.Checked)
                {
                    rune1 = FirstLetterToUpper(rune1);
                    rune2 = FirstLetterToUpper(rune2);
                    lbl_TextToUser.Text = "You can craft a total of " + numRunes + " runes!" + '\n'
                        + numRune1 + " " + rune1 + '\n' + numRune2 + " " + rune2 + '\n'
                        + "It will cost " + toFormat + " mana stones! Be sure to save up!" + '\n' +
                        "You should get approximately " + numLegend + " legendary 6* runes!";
                }
                else if (rad_Option2.Checked)
                {
                    rune1 = FirstLetterToUpper(rune1);
                    rune2 = FirstLetterToUpper(rune2);
                    rune3 = FirstLetterToUpper(rune3);
                    lbl_TextToUser.Text = "You can craft a total of " + numRunes + " runes!" + '\n'
                        + numRune1 + " " + rune1 + '\n' + numRune2 + " " + rune2 + '\n'
                        + numRune3 + " " + rune3 + '\n'
                        + "It will cost " + toFormat + " mana stones! Be sure to save up!" + '\n' +
                        "You should get approximately " + numLegend + " legendary 6* runes!";
                }
                else
                {
                    WarnUser("unspecified");
                }
            }
            else
            {
                WarnUser("unspecified");
            }
        }

        ///<summary>
        /// Empties the specified text box
        /// </summary>
        private void TextClear(TextBox box)
        {
            box.Text = string.Empty;
        }

        /// <summary>
        /// Verify user input runes are valid
        /// </summary>
        private bool CheckRunes(string name)
        {
            bool isValid = false;
            isValid = RuneValid(name);
            return isValid;
        }

        /// <summary>
        /// Sets the number of supplies visible based on the cosen runes
        /// </summary>
        private void SetSupplies()
        {
            grp_Supplies.Visible = true;
            if (numReagents == 2)
            {
                lbl_Supply1.Visible = true;
                lbl_Supply2.Visible = true;
                txt_Supply1.Visible = true;
                txt_Supply2.Visible = true;
            }
            else if (numReagents == 3)
            {
                lbl_Supply1.Visible = true;
                lbl_Supply2.Visible = true;
                lbl_Supply3.Visible = true;
                txt_Supply1.Visible = true;
                txt_Supply2.Visible = true;
                txt_Supply3.Visible = true;
            }
            else if (numReagents == 4)
            {
                lbl_Supply1.Visible = true;
                lbl_Supply2.Visible = true;
                lbl_Supply3.Visible = true;
                lbl_Supply4.Visible = true;
                txt_Supply1.Visible = true;
                txt_Supply2.Visible = true;
                txt_Supply3.Visible = true;
                txt_Supply4.Visible = true;
            }
            else
            {
                WarnUser("unspecified");
            }
        }

        /// <summary>
        /// Sets the labels of the supplies based on the chosen rune
        /// </summary>
        private void SetIngredients()
        {
            if (ingredients.Length == 2)
            {
                lbl_Supply1.Text = ingredients[0];
                lbl_Supply2.Text = ingredients[1];
            }
            else if (ingredients.Length == 3)
            {
                lbl_Supply1.Text = ingredients[0];
                lbl_Supply2.Text = ingredients[1];
                lbl_Supply3.Text = ingredients[2];
            }
            else if(ingredients.Length == 4)
            {
                lbl_Supply1.Text = ingredients[0];
                lbl_Supply2.Text = ingredients[1];
                lbl_Supply3.Text = ingredients[2];
                lbl_Supply4.Text = ingredients[3];
            }
            else
            {
                WarnUser("unspecified");
            }

        }

        /// <summary>
        /// Sets the labels of the supplies to all Cairos materials for balance calculation.
        /// </summary>
        private void SetIngredients(int num)
        {
            lbl_Supply1.Text = "Green Symbols";
            lbl_Supply2.Text = "Red Symbols";
            lbl_Supply3.Text = "Purple Symbols";
            lbl_Supply4.Text = "Rune Pieces";
        }

        /// <summary>
        /// Clears the supply box from view when not needed.
        /// </summary>
        private void RemoveSupplies()
        {
            grp_Supplies.Visible = false;
            lbl_Supply1.Visible = false;
            lbl_Supply2.Visible = false;
            lbl_Supply3.Visible = false;
            lbl_Supply4.Visible = false;
            txt_Supply1.Visible = false;
            txt_Supply2.Visible = false;
            txt_Supply3.Visible = false;
            txt_Supply4.Visible = false;
        }

        /// <summary>
        /// Convert the string on the text boxes to integers if possible. Message box error if not.
        /// </summary>
        private int GetInput(string input, TextBox box)
        {
            int numCheck = -1;
            if (box.Equals(txt_UserIn))
            {
                if (int.TryParse(input, out numCheck))
                {
                    if((numCheck < 0) || (numCheck > 555))
                    {
                        TextClear(box);
                        WarnUser("numberSupplies");
                        SetState(2);
                    }
                    else
                    {
                        return numCheck;
                    }
                }
                else
                {
                    TextClear(box);
                    WarnUser("numberSupplies");
                    SetState(2);
                    return -1; // or error int
                }
            }
            else
            {
                if (int.TryParse(input, out numCheck))
                {
                    if ((numCheck < 0) || (numCheck > 9999))
                    {
                        TextClear(box);
                        WarnUser("number");
                        SetState(2);
                    }
                    else
                    {
                        return numCheck;
                    }
                }
                else
                {
                    TextClear(box);
                    WarnUser("number");
                    SetState(2);
                    return -1; // or error int
                }
            }
            return -1;
        }

        #endregion

        /// <summary>
        /// Methods that cause the program to enter the next state.
        /// </summary>
        #region Change State

        /// <summary>
        /// Moves the program from state 1 to state 2 to state 3
        /// </summary>
        private void btn_Enter_Click(object sender, EventArgs e)
        {
            numEnters++;
            if(numEnters == 1)
            {
                SetState(2);
            }
            else if(numEnters > 1)
            {
                SetState(3);
            }
            else
            {
                WarnUser("unspecified");
            }
        }
        #endregion

        /// <summary>
        /// Methods to verify valid rune entry, and to get the info that composes each rune type.
        /// </summary>
        #region Rune Info

        /// <summary>
        /// Method to ensure user inputs a valid rune name.
        /// </summary>
        static bool RuneValid(string name)
        {
            string runeTL = name.ToLower();
            string[] possibleRunes = { "energy", "swift", "blade", "fatal", "despair", "guard", "focus", 
                "endure", "violent", "shield", "revenge", "rage", "vampire", "nemesis", "will", "destroy",
                "fight", "determination", "enhance", "accuracy", "tolerance", "ancient"};
            return Array.Exists<string>(possibleRunes, element => element == runeTL);
        }

        /// <summary>
        /// Sets up the required information that each chosen rune is composed of.
        /// </summary>
        private void GetRuneInfo(string rune)
        {
            String runeTL = rune.ToLower();
            switch (runeTL)
            {
                case "energy":
                case "swift":
                case "blade":
                case "fatal":
                case "despair":
                    isGiants = true;
                    numReagents = 3;
                    listRunesBalance[0] = rune;
                    ingredients = new string[] { "Green Symbols", "Purple Symbols", "Rune Pieces" };
                    break;
                case "guard":
                case "focus":
                case "endure":
                case "violent":
                case "shield":
                case "revenge":
                    isDragons = true;
                    numReagents = 3;
                    listRunesBalance[1] = rune;
                    ingredients = new string[] { "Red Symbols", "Green Symbols", "Rune Pieces" };
                    break;
                case "rage":
                case "vampire":
                case "nemesis":
                case "will":
                case "destroy":
                    isNecro = true;
                    numReagents = 3;
                    listRunesBalance[2] = rune;
                    ingredients = new string[] { "Purple Symbols", "Red Symbols", "Rune Pieces" };
                    break;
                case "fight":
                    numReagents = 4;
                    ingredients = new string[] { "Red crystals", "White crystals", "Rune Pieces", "Magic Crystal" };
                    break;
                case "determination":
                    numReagents = 4;
                    ingredients = new string[] { "Blue crystals", "White crystals", "Rune Pieces", "Magic Crystal" };
                    break;
                case "enhance":
                    numReagents = 4;
                    ingredients = new string[] { "Yellow crystals", "Purple crystals", "Rune Pieces", "Magic Crystal" };
                    break;
                case "accuracy":
                    numReagents = 4;
                    ingredients = new string[] { "White crystals", "Purple crystals", "Rune Pieces", "Magic Crystal" };
                    break;
                case "tolerance":
                    numReagents = 4;
                    ingredients = new string[] { "Purple crystals", "White crystals", "Rune Pieces", "Magic Crystal" };
                    break;
                case "ancient":
                    numReagents = 2;
                    ingredients = new string[] { "Ancient Stone", "Rune Ore" };
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Contains all logic used for the calculations
        /// </summary>
        #region Math

        /// <summary>
        /// Calculates the number of runes the user can craft based on their input supplies
        /// </summary>
        private void CalculateRunes()
        {

            reagentTotals = new int[] { supply1, supply2, supply3, supply4 };

            if (numReagents == 2)
            {
                int primary = reagentTotals[0] / 50;
                int secondary = reagentTotals[1] / 25;
                cost = 20000;
                numRunes = Smaller(primary, secondary);
                totalCost = cost * numRunes;
                numLegend = (int)(numRunes * 0.03);
            }
            else if(numReagents == 3)
            {
                int primary = reagentTotals[0] / 18;
                int secondary = reagentTotals[1] / 6;
                int tertiary = reagentTotals[2] / 12;
                cost = 15000;
                numRunes = Smaller(primary, secondary, tertiary);
                totalCost = cost * numRunes;
                numLegend = (int)(numRunes * 0.03);
            }
            else if(numReagents == 4)
            {
                int primary = reagentTotals[0] / 60;
                int secondary = reagentTotals[1] / 20;
                int tertiary = reagentTotals[2] / 12;
                int quaternary = reagentTotals[3] / 60;

                numRunes = Smaller(primary, secondary, tertiary, quaternary);
                totalCost = cost * numRunes;
                numLegend = (int)(numRunes * 0.03);
            }
            else
            {
                WarnUser("unspecified");
            }
        }

        /// <summary>
        /// Calculates the number of supplies the user needs to craft a chosen number of runes
        /// </summary>
        private void CalculateSupplies()
        {
            int targetTotal = GetInput(txt_UserIn.Text, txt_UserIn);
            reagentTotals = new int[] { supply1, supply2, supply3, supply4 };
            if (numReagents == 2)
            {
                reagentTotals[0] = targetTotal * 50;
                reagentTotals[1] = targetTotal * 25;
                cost = 20000;
                totalCost = targetTotal * cost;
                numLegend = (int)(targetTotal * 0.03);
            }
            else if (numReagents == 3)
            {
                reagentTotals[0] = targetTotal * 18;
                reagentTotals[1] = targetTotal * 6;
                reagentTotals[2] = targetTotal * 12;
                cost = 15000;
                totalCost = targetTotal * cost;
                numLegend = (int)(targetTotal * 0.03);
            }
            else if (numReagents == 4)
            {
                reagentTotals[0] = targetTotal * 60;
                reagentTotals[1] = targetTotal * 20;
                reagentTotals[2] = targetTotal * 12;
                reagentTotals[3] = targetTotal * 60;
                cost = 15000;
                totalCost = targetTotal * cost;
                numLegend = (int)(targetTotal * 0.03);
            }
            else
            {
                WarnUser("unspecified");
            }
        }

        /// <summary>
        /// Starts the balance calculation by determining what archtypes are being crafted.
        /// Archtypes are defined by their primary crafting ingredient, which is the dominant
        /// drop of the associated dungeon. Green = Giants, Red = Dragons, Purple = Necro.
        /// </summary>
        private void CalculateBalance(bool[] balanceTypes)
        {
            if (Array.Equals(balanceTypes, new bool[] { false, true, true }))
            {
                exclusion = 0;
            }
            else if (Array.Equals(balanceTypes, new bool[] { true, false, true }))
            {
                exclusion = 1;
            }
            else if (Array.Equals(balanceTypes, new bool[] { true, true, false }))
            {
                exclusion = 2;
            }
            else
            {
                exclusion = 3;
            }

            Balance(exclusion);
        }

        /// <summary>
        /// The logic that makes tha balancing work. Iterates through each craft one at a time.
        /// When crafting materials run out, removes that rune from iteration, and keeps going.
        /// When all crafting materials run out, stops, sets variable data accordingly.
        /// </summary>
        private void Balance(int exclusion)
        {
            reagentTotals = new int[] { supply1, supply2, supply3, supply4 };
            // these are inputs that need to be fed in: crafting materials available for the given player
            int harmony = reagentTotals[0];        //'green'
            int transcendence = reagentTotals[1]; //'red'
            int chaos = reagentTotals[2];           //'purple'
            int pieces = reagentTotals[3];     //'rune pieces'

            int[] supply_vec = new int[] { harmony, transcendence, chaos, pieces };

            int[][] total_cost = new int[][] { giant_cost_vec, dragon_cost_vec, necro_cost_vec };

            int x = 0; 
            int y = 0; 
            int z = 0; 
            int prevX = 0;
            int prevY = 0;
            int prevZ = 0;

            List<int> fixed_runes = new List<int>();
            fixed_runes.Add(exclusion);

            int[] residual;

            while (fixed_runes.Count() < total_cost.Length)
            {
                residual = ComputeResidual(x, y, z, supply_vec);

                if (GreaterThan(0, residual))
                {
                    prevX = x;
                    prevY = y;
                    prevZ = z;
                    //force any locked runes to be uncraftable (either by user choice or by no craft materials remaining)
                    foreach (Int32 fixed_rune in fixed_runes)
                    {
                        residual[fixed_rune] = 0;
                    }

                    switch (FindMaxIndex(CopyOfRange(residual, 0, 3)))
                    {
                        case 0:
                            x += 1;
                            break;
                        case 1:
                            y += 1;
                            break;
                        case 2:
                            z += 1;
                            break;
                    }
                }
                else
                {
                    //if negative residual, find 'problem' craft and prevent that craft type from being considered further
                    fixed_runes.Add(FindErrorCraft(x, y, z, prevX, prevY, prevZ));
                    x = prevX;
                    y = prevY;
                    z = prevZ;
                }
            }

            numRune1 = x;
            numRune2 = y;
            numRune3 = z;


            int totalCraft = x + y + z;
            cost = 15000;
            int[] runes = { x, y, z };
            numLegend = (int)(totalCraft * 0.03);
            totalCost = cost * totalCraft;
            numRunes = totalCraft;
        }

        /// <summary>
        /// Used to convert the original java function of Arrays.copyOfRange to C# compatable version.
        /// </summary>
        private int[] CopyOfRange(int[] src, int start, int end)
        {
            int len = end - start;
            int[] dest = new int[len];
            Array.Copy(src, start, dest, 0, len);
            return dest;
        }

        /// <summary>
        /// Used to find the greatest value on the list, to use that as the primary crafting
        /// ingredient of the next iteration.
        /// </summary>
        private bool GreaterThan(int limit, int[] data)
        {
            /*
            determines if all of vector data is greater than some limit

            returns true if yes, false if no
             */
            foreach (int datum in data)
            {
                if (datum < limit)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Adds to the crafted runes index.
        /// </summary>
        private int FindMaxIndex(int[] data)
        {
            /*
            finds index containing the maximum value of data vector
             */
            int max = 0;
            for (int k = 1; k < data.Length; k++)
            {
                if (data[k] > data[max])
                {
                    max = k;
                }
            }
            return max;
        }

        /// <summary>
        /// Finds the problematic crafting ingredient and returns that information
        /// to Balance so that it can be removed from the next iteration.
        /// </summary>
        private int FindErrorCraft(int x, int y, int z, int prevX, int prevY, int prevZ)
        {
            /*
            gross if block recovering the most recently made rune craft
             */
            int errorCraft = -1;
            if (x - prevX > 0)
            {
                errorCraft = 0;
            }
            else if (y - prevY > 0)
            {
                errorCraft = 1;
            }
            else if (z - prevZ > 0)
            {
                errorCraft = 2;
            }
            return errorCraft;
        }

        /// <summary>
        /// Determines the remaining values of the crafting supplies at each step of the way.
        /// </summary>
        private int[] ComputeResidual(int x, int y, int z, int[] supply_vec)
        {
            /*
            computes the residual in rune craft materials between inventory and what is currently being used for the proposed
            craft setup. The goal of the program is to maximize the # of rune crafts by minimizing this residual.
             */
            int[] costVec = new int[4];
            int[] cap = new int[4];
            for (int k = 0; k < cap.Length; k++)
            {
                costVec[k] = x * giant_cost_vec[k] + y * dragon_cost_vec[k] + z * necro_cost_vec[k];
                cap[k] = supply_vec[k] - costVec[k];
            }
            return cap;
        }

        /// <summary>
        /// Finds the smallest value between 2 integers
        /// </summary>
        private int Smaller(int primary, int secondary)
        {
            return (Math.Min(primary, secondary));
        }

        /// <summary>
        /// Finds the smallest value between 3 integers
        /// </summary>
        private int Smaller(int primary, int secondary, int tertiary)
        {
            int min = primary;

            if (secondary < min)
            {
                min = secondary;
            }
            if (tertiary < min)
            {
                min = tertiary;
            }
            return min;
        }

        /// <summary>
        /// Finds the smallest value between 4 integers
        /// </summary>
        private int Smaller(int primary, int secondary, int tertiary, int quaternary)
        {
            int min = Math.Min(primary, secondary);
            int min2 = Math.Min(tertiary, quaternary);
            return (Math.Min(min, min2));
        }
        #endregion
    }
}
