import java.util.*;

public class Reagent {

    public static void runeType(String rune){
        String runeTL = rune.toLowerCase();
            switch(runeTL){
                case "energy":
                case "swift":
                case "blade":
                case "fatal":
                case "despair":
                    threeReagent("Green symbols", "Purple symbols", "Rune Pieces");
                    break;
                case "guard":
                case "focus":
                case "endure":
                case "violent":
                case "shield":
                case "revenge":
                    threeReagent("Red symbols", "Green symbols", "Rune Pieces");
                    break;
                case "rage":
                case "vampire":
                case "nemesis":
                case "will":
                case "destroy":
                    threeReagent("Purple symbols", "Red symbols", "Rune Pieces");
                    break;
                case "fight":
                    fourReagent("Red crystals", "White crystals", "Rune Pieces", "Magic Crystal");
                    break;
                case "determination":
                    fourReagent("Blue crystals", "White crystals", "Rune Pieces", "Magic Crystal");
                    break;
                case "enhance":
                    fourReagent("Yellow crystals", "Purple crystals", "Rune Pieces", "Magic Crystal");
                    break;
                case "accuracy":
                    fourReagent("White crystals", "Purple crystals", "Rune Pieces", "Magic Crystal");
                    break;
                case "tolerance":
                    fourReagent("Purple crystals", "White crystals", "Rune Pieces", "Magic Crystal");
                    break;
                case "ancient":
                    twoReagent("Ancient Stone", "Rune Ore");
                    break;

                default:
                    System.out.println("Please choose a valid rune type.");
                    Intro.choose();
        }
    }

    public static void twoReagent(String item1, String item2){
        System.out.println("Please enter the number of " + item1 + ": ");
        Scanner input = new Scanner(System.in);
        int primary = Integer.parseInt(input.nextLine());
        System.out.println("Please enter the number of " + item2 + ": ");
        int secondary = Integer.parseInt(input.nextLine());
        input.close();

        Calculate.calcRunes(primary, secondary);
    }

    public static void threeReagent(String item1, String item2, String item3){
        System.out.println("Please enter the number of " + item1 + ": ");
        Scanner input = new Scanner(System.in);
        int primary = Integer.parseInt(input.nextLine());
        System.out.println("Please enter the number of " + item2 + ": ");
        int secondary = Integer.parseInt(input.nextLine());
        System.out.println("Please enter the number of " + item3 + ": ");
        int tertiary = Integer.parseInt(input.nextLine());
        input.close();

        Calculate.calcRunes(primary, secondary, tertiary);
    }

    public static void fourReagent(String item1, String item2, String item3, String item4){
        System.out.println("Please enter the number of " + item1 + ": ");
        Scanner input = new Scanner(System.in);
        int primary = Integer.parseInt(input.nextLine());
        System.out.println("Please enter the number of " + item2 + ": ");
        int secondary = Integer.parseInt(input.nextLine());
        System.out.println("Please enter the number of " + item3 + ": ");
        int tertiary = Integer.parseInt(input.nextLine());
        System.out.println("Please enter the number of " + item4 + ": ");
        int quaternary = Integer.parseInt(input.nextLine());
        input.close();

        Calculate.calcRunes(primary, secondary, tertiary, quaternary);
    }
}
