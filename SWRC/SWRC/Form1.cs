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
        private Boolean runes = false;
        private Boolean supplies = false;
        private Boolean isBalance = false;
        private int numReagents = 0;
        private string[] listRunesBalance = { "", "", "" };
        private string[] ingredients = { "", "", "", "" };
        private int[] reagentTotals = { 0, 0, 0, 0 };
        private int exclusion = 0;
        private int cost = 0;
        private int numRunes = 0;
        private int totalCost = 0;
        private int numLegend = 0;
        private Boolean isGiants = false;
        private Boolean isDragons = false;
        private Boolean isNecro = false;
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
                lbl_TextToUser.Text = "Choose an option above!";
                grp_Runes.Visible = false;
                grp_BalanceOption.Visible = false;
                RemoveSupplies();
            }
            else
            {
                lbl_TextToUser.Text = "Enter your rune type in Rune 1! You can enter \"anicent\" to calculate ancient rune crafts!";
                grp_BalanceOption.Visible = false; ;
                grp_Runes.Visible = true;
                lbl_Rune1.Visible = true;
                lbl_Rune2.Visible = false;
                lbl_Rune3.Visible = false;
                txt_Rune1.Visible = true;
                txt_Rune2.Visible = false;
                txt_Rune3.Visible = false;
                numEnters = 0;
                runes = true;
                RemoveSupplies();
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
                lbl_TextToUser.Text = "Choose an option above!";
                grp_Runes.Visible = false;
                grp_BalanceOption.Visible = false;
                RemoveSupplies();
            }
            else
            {
                lbl_TextToUser.Text = "Enter the rune you want to craft in Rune 1! You can enter \"anicent\" to calculate ancient rune crafts!";
                grp_BalanceOption.Visible = false;
                grp_Runes.Visible = true;
                lbl_Rune1.Visible = true;
                lbl_Rune2.Visible = false;
                lbl_Rune3.Visible = false;
                txt_Rune1.Visible = true;
                txt_Rune2.Visible = false;
                txt_Rune3.Visible = false;
                numEnters = 0;
                supplies = true;
                RemoveSupplies();
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
                lbl_TextToUser.Text = "Choose an option above!";
                grp_Runes.Visible = false;
                grp_BalanceOption.Visible = false;
                RemoveSupplies();
            }
            else
            {
                lbl_TextToUser.Text = "Enter the runes in the Rune Choice box, then hit enter.";
                grp_Runes.Visible = true;
                grp_BalanceOption.Visible = true;
                lbl_Rune1.Visible = false;
                txt_Rune1.Visible = false;
                numEnters = 0;
                isBalance = true;
                RemoveSupplies();
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
            lbl_Rune1.Visible = true;
            lbl_Rune2.Visible = true;
            lbl_Rune3.Visible = false;
            txt_Rune1.Visible = true;
            txt_Rune2.Visible = true;
            txt_Rune3.Visible = false;
        }

        /// <summary>
        /// Sets the number of runes to balance to 3
        /// </summary>
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

        /// <summary>
        /// Methods of code that get used during multiple stages.
        /// </summary>
        #region Helper Methods

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
        private Boolean CheckRunes(string name)
        {
            Boolean isValid = false;
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

            else
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

            else
            {
                lbl_Supply1.Text = ingredients[0];
                lbl_Supply2.Text = ingredients[1];
                lbl_Supply3.Text = ingredients[2];
                lbl_Supply4.Text = ingredients[3];
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
        /// Works with IsInt to convert the string on the text boxes to integers
        /// </summary>
        private int GetInput(string input, TextBox box)
        {
            int numCheck = 0;
            numCheck = IsInt(input);
            return numCheck;
        }

        /// <summary>
        /// Works with GetInput to conver the string on the text boxes to integers
        /// </summary>
        private int IsInt(String input)
        {
            int i = -1; 
            i = Int32.Parse(input);
            return i;
        }

        #endregion

        /// <summary>
        /// Methods that cause the program to enter the next state.
        /// </summary>
        #region Change State

        /// <summary>
        /// Moves from state 0 to state 1 to state 2
        /// </summary>
        private void btn_Enter_Click(object sender, EventArgs e)
        {
            numEnters++;
            rune1 = txt_Rune1.Text;
            rune2 = txt_Rune2.Text;
            rune3 = txt_Rune3.Text;
            supply1 = GetInput(txt_Supply1.Text, txt_Supply1);
            supply2 = GetInput(txt_Supply2.Text, txt_Supply2);
            supply3 = GetInput(txt_Supply3.Text, txt_Supply3);
            supply4 = GetInput(txt_Supply4.Text, txt_Supply4);
            

            NextStep();
        }

        /// <summary>
        /// Logic to determine what actions need performed at each state
        /// </summary>
        private void NextStep()
        {
            if ((numEnters == 1) && runes)
            {
                if (CheckRunes(rune1))
                {
                    GetRuneInfo(rune1);
                    SetSupplies();
                    SetIngredients();
                    lbl_TextToUser.Text = "Enter the number of supplies, then hit enter!";
                }
                else
                {
                    TextClear(txt_Rune1);
                    lbl_TextToUser.Text = "Please enter a valid rune!";
                    numEnters = 0;
                }
            }

            if ((numEnters == 1) && supplies)
            {
                if (CheckRunes(rune1))
                {
                    GetRuneInfo(rune1);
                    SetSupplies();
                    SetIngredients();
                    lbl_TextToUser.Text = "Enter the desired number of runes below, then hit enter!";
                }
                else
                {
                    TextClear(txt_Rune1);
                    lbl_TextToUser.Text = "Please enter a valid rune!";
                    numEnters = 0;
                }
            }

            if ((numEnters == 1) && isBalance)
            {
                if (rad_Option1.Checked)
                {
                    if((CheckRunes(rune1)) && CheckRunes(rune2))
                    {
                        GetRuneInfo(rune1);
                        GetRuneInfo(rune2);
                        numReagents = 4;
                        SetSupplies();
                        SetIngredients(4);
                        lbl_TextToUser.Text = "Enter the number of supplies, then hit enter!";
                    }
                    else
                    {
                        TextClear(txt_Rune1);
                        TextClear(txt_Rune2);
                        lbl_TextToUser.Text = "Please enter a valid rune!";
                        numEnters = 0;
                    }
                }

                if (rad_Option2.Checked){
                    if((CheckRunes(rune1)) && (CheckRunes(rune2)) && (CheckRunes(rune3)))
                    {
                        GetRuneInfo(rune1);
                        GetRuneInfo(rune2);
                        GetRuneInfo(rune3);
                        numReagents = 4;
                        SetSupplies();
                        SetIngredients(4);
                        lbl_TextToUser.Text = "Enter the number of supplies, the hit enter!";
                    }
                    else
                    {
                        TextClear(txt_Rune1);
                        TextClear(txt_Rune2);
                        TextClear(txt_Rune3);
                        lbl_TextToUser.Text = "Please enter a valid rune!";
                        numEnters = 0;
                    }
                }
            }

            if ((numEnters >= 2) && runes)
            {
                CalculateRunes();
                lbl_TextToUser.Text = "You can craft " + numRunes + " " + rune1 + " runes!" + '\n'
                    + "It will cost " + totalCost + " mana stones! Be sure to save up!" + '\n' +
                    "You should get approximately " + numLegend + " legendary 6* runes!";

            }

            if ((numEnters >= 2) && supplies)
            {
                CalculateSupplies();
                lbl_TextToUser.Text = "It will cost " + totalCost + " mana stones! Be sure to save up!" 
                    + '\n' + "You should get approximately " + numLegend + " legendary 6* runes!";
                txt_Supply1.Text = reagentTotals[0].ToString();
                txt_Supply2.Text = reagentTotals[1].ToString();
                txt_Supply3.Text = reagentTotals[2].ToString();
                txt_Supply4.Text = reagentTotals[3].ToString();

            }

            if ((numEnters == 2) && isBalance)
            {
                if (rad_Option1.Checked)
                {
                    CalculateBalance(new Boolean[] { isGiants, isDragons, isNecro });
                    lbl_TextToUser.Text = "You can craft a total of " + numRunes + " runes!" + '\n'
                        + numRune1 + " " + rune1 + '\n' + numRune2 + " " + rune2 + '\n'
                        + "It will cost " + totalCost + " mana stones! Be sure to save up!" + '\n' +
                        "You should get approximately " + numLegend + " legendary 6* runes!";
                }

                else
                {
                    CalculateBalance(new Boolean[] { isGiants, isDragons, isNecro });
                    lbl_TextToUser.Text = "You can craft a total of " + numRunes + " runes!" + '\n'
                        + numRune1 + " " + rune1 + '\n' + numRune2 + " " + rune2 + '\n'
                        + numRune3 + " " + rune3 + '\n'
                        + "It will cost " + totalCost + " mana stones! Be sure to save up!" + '\n' +
                        "You should get approximately " + numLegend + " legendary 6* runes!";
                }
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
        private Boolean RuneValid(string name)
        {
            string runeTL = name.ToLower();
            switch (runeTL)
            {
                case "energy":
                case "swift":
                case "blade":
                case "fatal":
                case "despair":
                case "guard":
                case "focus":
                case "endure":
                case "violent":
                case "shield":
                case "revenge":
                case "rage":
                case "vampire":
                case "nemesis":
                case "will":
                case "destroy":
                case "fight":
                case "determination":
                case "enhance":
                case "accuracy":
                case "ancient":
                    return true;
                default:
                    return false;
            }
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

            else
            {
                int primary = reagentTotals[0] / 60;
                int secondary = reagentTotals[1] / 20;
                int tertiary = reagentTotals[2] / 12;
                int quaternary = reagentTotals[3] / 60;

                numRunes = Smaller(primary, secondary, tertiary, quaternary);
                totalCost = cost * numRunes;
                numLegend = (int)(numRunes * 0.03);
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

            else
            {
                reagentTotals[0] = targetTotal * 60;
                reagentTotals[1] = targetTotal * 20;
                reagentTotals[2] = targetTotal * 12;
                reagentTotals[3] = targetTotal * 60;
                cost = 15000;
                totalCost = targetTotal * cost;
                numLegend = (int)(targetTotal * 0.03);
            }
        }

        /// <summary>
        /// Starts the balance calculation by determining what archtypes are being crafted.
        /// Archtypes are defined by their primary crafting ingredient, which is the dominant
        /// drop of the associated dungeon. Green = Giants, Red = Dragons, Purple = Necro.
        /// </summary>
        private void CalculateBalance(Boolean[] balanceTypes)
        {
            if (Array.Equals(balanceTypes, new Boolean[] { false, true, true }))
            {
                exclusion = 0;
            }
            else if (Array.Equals(balanceTypes, new Boolean[] { true, false, true }))
            {
                exclusion = 1;
            }
            else if (Array.Equals(balanceTypes, new Boolean[] { true, true, false }))
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
        private Boolean GreaterThan(int limit, int[] data)
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
