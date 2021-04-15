public class Calculate {
    public static void calcRunes(int primary, int secondary){
        primary = primary / 50;
        secondary = secondary / 25;

        int runes = smaller(primary, secondary);
        runeNumbers(runes, true);
    }

    public static void calcRunes(int primary, int secondary, int tertiary){
        primary = primary / 18;
        secondary = secondary / 6;
        tertiary = tertiary / 12;

        int runes = smaller(primary, secondary, tertiary);
        runeNumbers(runes, false);
    }

    public static void calcRunes(int primary, int secondary, int tertiary, int quaternary){
        primary = primary / 60;
        secondary = secondary / 20;
        tertiary = tertiary / 12;
        quaternary = quaternary / 60;

        int runes = smaller(primary, secondary, tertiary, quaternary);
        runeNumbers(runes, false);
    }

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

    public static void runeNumbers(int runes, boolean type){
        int price = runes * (!type ? 15000 : 20000);
        int legend = (int) (runes * .03);
        System.out.println("You can craft " + runes + " " + Intro.runeName + " runes!" );
        System.out.println("That will cost you " + price + " mana! Make sure to stock up!");
        System.out.println("With that many crafts, you should get approximately " + legend + " Legendary 6* runes!");
        System.out.println("To try a different rune, enter the type of rune you wish to craft. Type \"quit\" to exit.");
        Intro.choose();
    }

}
