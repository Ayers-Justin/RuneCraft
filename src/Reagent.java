import java.util.*;

public class Reagent {
    public static Scanner input = new Scanner(System.in);
    public static boolean isBalance = false;
    public static String[] rune = {""};
    public static String r = "";
    public static int numReag = 0;
    public static boolean isGiants = false;
    public static boolean isDragons = false;
    public static boolean isNecro = false;
    public static String[] listRunesBalance = {" "," "," "};

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

            for (String reagent : reagents) {
                System.out.println(reagent + " ");
            }

            for (int numReagent : numReagents) {
                System.out.println(numReagent + " ");
            }

            System.out.println("Balance: " + isBalance);

            Calculate.calcRunes(numReagents);

        }
    }

    /**public static void reagentList(String item1, String item2){
        System.out.println("Please enter the number of " + item1 + ": ");
        int primary = getInput();
        System.out.println("Please enter the number of " + item2 + ": ");
        int secondary = getInput();

        if(!isBalance) {
            Calculate.calcRunes(primary, secondary);
        }
    }

    public static void reagentList(String item1, String item2, String item3){
        System.out.println("Please enter the number of " + item1 + ": ");
        int primary = getInput();
        System.out.println("Please enter the number of " + item2 + ": ");
        int secondary = getInput();
        System.out.println("Please enter the number of " + item3 + ": ");
        int tertiary = getInput();

        if(!isBalance) {
            Calculate.calcRunes(primary, secondary, tertiary);
        }
    }

    public static void reagentList(String item1, String item2, String item3, String item4){
        System.out.println("Please enter the number of " + item1 + ": ");
        int primary = getInput();
        System.out.println("Please enter the number of " + item2 + ": ");
        int secondary = getInput();
        System.out.println("Please enter the number of " + item3 + ": ");
        int tertiary = getInput();
        System.out.println("Please enter the number of " + item4 + ": ");
        int quaternary = getInput();

        if(!isBalance) {
            Calculate.calcRunes(primary, secondary, tertiary, quaternary);
        }
    }*/

    public static int[] reagentList(String[] array){
        int[] numReagents = {0, 0, 0, 0};
        for(int i = 0; i < array.length; i++) {
            System.out.println("Please enter the number of " + array[i] + ": ");
            numReagents[i] = getInput();

        }

        return numReagents;
    }

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




        /*System.out.println("Giants: " + isGiants);
        System.out.println("Dragons: " + isDragons);
        System.out.println("Necropolis: " + isNecro);

        System.out.println("Please enter the first rune.");
        for(int i = 0; i < 1; i++) {
            try {
                r1 = input.nextLine();
                rune1 = runeType(r1);
                if(rune1[0].equals("error")){
                    throw new IllegalArgumentException("error");
                }
            } catch (IllegalArgumentException exception) {
                System.out.println("Please choose a valid rune.");
                i--;
            }
        }
        System.out.println("Please enter the second rune.");
        for(int i = 0; i < 1; i++) {
            try {
                r2 = input.nextLine();
                rune2 = runeType(r2);
                if(rune2[0].equals("error")){
                    throw new IllegalArgumentException("error");
                }
            } catch (IllegalArgumentException exception) {
                System.out.println("Please choose a valid rune.");
                i--;
            }
        }

        reagentList(rune1);
        reagentList(rune2);
        System.out.println(r1 + ": ");
        for(int i = 0; i < rune1.length; i++){
            System.out.println(rune1[i] + " ");
        }

        System.out.println(r2 + ": ");
        for(int i = 0; i < rune2.length; i++){
            System.out.println(rune2[i] + " ");
        }

        System.out.println("common reagent: " + shareReagent());*/
    }

    /*public static String shareReagent(){
        for(int i = 0; rune2.length < 4; i++){
            for(int j = 0; j < rune1.length; j++){
                if(rune1[i].equals(rune2[j])){
                    return rune1[i];
                }
            }
        }
        return "none";
    }*/
}
