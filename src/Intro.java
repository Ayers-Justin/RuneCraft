import java.util.*;

public class Intro {

    public static String runeName = ""; // store rune name for reuse later

    // Introduction to the program. First thing the user sees upon runtime.
    public static void intro() {
        System.out.println("Welcome to the crafting calculator!");
        System.out.println("Please enter the type of rune you wish to craft: ");
        System.out.println("You can type \"ancient\" to calculate ancient runes.");
        System.out.println("You can type \"balance\" to choose 2 or 3 runes and optimize the number of crafts.");
        Intro.choose();
    }

    // Method to determine what aspect of the program the user wishes to interface with.
    public static void choose() {

        Scanner choice = new Scanner(System.in);
        String rune = choice.nextLine();
        runeName = rune;

        if (rune.equals("quit")){
        System.exit(0);
        }
        else
        {
        Reagent.runeCheck(rune);
        }
}
}
