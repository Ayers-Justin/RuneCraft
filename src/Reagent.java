import java.util.*;

public class Reagent {
    public static Scanner input = new Scanner(System.in);
    public static boolean isBalance = false;
    public static String[] rune = {""}; // array to store rune ingredients.
    public static String r = ""; // String to store input rune name
    public static int numReag = 0; // flag to determine what crafting logic to use in Calculate.java
    public static boolean isGiants = false; // flag for giant type runes
    public static boolean isDragons = false; // flag for dragon type runes
    public static boolean isNecro = false; // flag for necro type runes
    public static String[] listRunesBalance = {" "," "," "}; // array to store user rune choices

    /* Determine what ingredients are required. Set flags as needed
    * */
    public static String[] runeType(String rune) {
        String runeTL = rune.toLowerCase();
        switch (runeTL) {
            case "energy":
            case "swift":
            case "blade":
            case "fatal":
            case "despair":
                numReag = 3;
                isGiants = true;
                listRunesBalance[0] = rune;
                return new String[]{"Green Symbols", "Purple Symbols", "Rune Pieces"};
            case "guard":
            case "focus":
            case "endure":
            case "violent":
            case "shield":
            case "revenge":
                numReag = 3;
                isDragons = true;
                listRunesBalance[1] = rune;
                return new String[]{"Red Symbols", "Green Symbols", "Rune Pieces"};
            case "rage":
            case "vampire":
            case "nemesis":
            case "will":
            case "destroy":
                numReag = 3;
                isNecro = true;
                listRunesBalance[2] = rune;
                return new String[]{"Purple Symbols", "Red Symbols", "Rune Pieces"};
            case "fight":
                numReag = 4;
                return new String[]{"Red crystals", "White crystals", "Rune Pieces", "Magic Crystal"};
            case"determination":
                numReag = 4;
                return new String[]{"Blue crystals", "White crystals", "Rune Pieces", "Magic Crystal"};
            case "enhance":
                numReag = 4;
                return new String[]{"Yellow crystals", "Purple crystals", "Rune Pieces", "Magic Crystal"};
            case "accuracy":
                numReag = 4;
                return new String[]{"White crystals", "Purple crystals", "Rune Pieces", "Magic Crystal"};
            case "tolerance":
                numReag = 4;
                return new String[]{"Purple crystals", "White crystals", "Rune Pieces", "Magic Crystal"};
            case "ancient":
                numReag = 2;
                return new String[]{"Ancient Stone", "Rune Ore"};
            case "balance":
                isBalance = true;
                return new String[]{"balance"};
            default:
                return new String[]{"error"};
        }
    }

    // Ensure valid input. Logic determines what stop to take next
    public static void runeCheck(String rune){
        String[] reagents = runeType(rune);
        if(reagents[0].equals("error")){
            System.out.println("Please choose a valid rune name.");
            Intro.choose();
        }
        else if(reagents[0].equals("balance")){
            chooseRunes();
        }
        else {
            int[] numReagents = reagentList(reagents);

            Calculate.calcRunes(numReagents);
        }
    }

    // Acquires user input to know how many resources the user has.
    public static int[] reagentList(String[] array){
        int[] numReagents = {0, 0, 0, 0};
        for(int i = 0; i < array.length; i++) {
            System.out.println("Please enter the number of " + array[i] + ": ");
            numReagents[i] = getInput();

        }

        return numReagents;
    }

    // The following 2 methods are used to ensure proper integer input.
    public static int getInput(){
        int numCheck = 0;
        for(int i = 0; i < 1;i++) {
            try {
                numCheck = isInt(input.nextLine());
                if ((numCheck < 0) || (numCheck > 9999)) {
                    throw new IllegalArgumentException(Integer.toString(numCheck));
                }
            } catch (IllegalArgumentException exception) {
                System.out.println("Please enter a number between 0 and 9999.");
                i--;
            }
        }
        return numCheck;
    }

    public static int isInt(String input){
        int i = -1;
        try{
            i = Integer.parseInt(input);
        }
        catch(Exception e){
            System.out.println("Please enter a number between 0 and 9999.");
            getInput();
        }
        return i;
    }

    // used for finding the runes the user wants to balance.
    public static void chooseRunes(){
        int chosenNum;
        String[] number = {"first", "second", "third"};

        System.out.println("There are 3 types of Cairos runes, signified by their primary crafting ingredient.");
        System.out.println("These types are \"Giants\", \"Dragons\", and \"Necropolis\"");
        System.out.println("The primary crafting ingredients are \"Green\", \"Red\", and \"Purple\"");
        System.out.println("How many types of runes would you like to balance?");
        chosenNum = getInput();


        for (int i = 0; i < chosenNum; i++) {
            System.out.println("Please enter the " + number[i] + " rune name.");
            for (int j = 0; j < 1; j++) {
                try {
                    r = input.nextLine();
                    rune = runeType(r);
                    if (rune[0].equals("error")) {
                        throw new IllegalArgumentException("error");
                    }
                } catch (IllegalArgumentException exception) {
                    System.out.println("Please choose a valid rune.");
                    j--;
                }
            }
        }
        Balance.optimizeReagents(new boolean[] {isGiants, isDragons, isNecro});

    }
}
