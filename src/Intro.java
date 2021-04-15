import java.util.*;

public class Intro {

    public static String runeName = "";

    public static void intro() {
        System.out.println("Welcome to the crafting calculator!");
        System.out.println("Please enter the type of rune you wish to craft: ");
        System.out.println("You can type \"ancient\" to calculate ancient runes.");
        Intro.choose();
    }

    public static void choose() {

        Scanner choice = new Scanner(System.in);
        String rune = choice.nextLine();
        runeName = rune;

        if (rune.equals("quit")){
        System.exit(0);
    }
        else
    {
        Reagent.runeType(rune);
    }
}
}
