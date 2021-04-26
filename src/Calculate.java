public class Calculate {

    /* Class to use the limiting reagent as the basis for single rune calculations.
    Use integer array to calculate crafts from user input.
    * */
    public static void calcRunes(int[] numReagents){
        if(Reagent.numReag == 2){
            int primary = numReagents[0] / 50;
            int secondary = numReagents[1] / 25;

            int runes = smaller(primary, secondary);
            runeNumbers(runes, 20000);
        }
        else if(Reagent.numReag == 3){
            int primary = numReagents[0] / 18;
            int secondary = numReagents[1] / 6;
            int tertiary = numReagents[2] / 12;

            int runes = smaller(primary, secondary, tertiary);
            runeNumbers(runes, 15000);

        }
        else{
            int primary = numReagents[0] / 60;
            int secondary = numReagents[1] / 20;
            int tertiary = numReagents[2] / 12;
            int quaternary = numReagents[3] / 60;

            int runes = smaller(primary, secondary, tertiary, quaternary);
            runeNumbers(runes, 15000);

        }
    }

    /* The following 3 methods simply find the smallest number from the given numbers to use
    * to determine how many rune crafts are possible with the given inputs.
    * */
    public static int smaller(int primary, int secondary){
        return(Math.min(primary, secondary));
    }

    public static int smaller(int primary, int secondary, int tertiary){
        int min = primary;

        if(secondary < min){
            min = secondary;
        }
        if (tertiary < min){
            min = tertiary;
        }
        return min;
    }

    public static int smaller(int primary, int secondary, int tertiary, int quaternary){
        int min = Math.min(primary, secondary);
        int min2 = Math.min(tertiary, quaternary);
        return(Math.min(min, min2));
    }

    /* Output the calculated numbers based on user input.
    * */
    public static void runeNumbers(int runes, int cost){
        int price = runes * cost;
        int legend = (int) (runes * 0.03);
        System.out.println("You can craft " + runes + " " + Intro.runeName + " runes!" );
        System.out.println("That will cost you " + price + " mana! Make sure to stock up!");
        System.out.println("With that many crafts, you should get approximately " + legend + " Legendary 6* runes!");
        System.out.println("To try a different rune, enter the type of rune you wish to craft. Type \"quit\" to exit.");
        Intro.choose();
    }

}
