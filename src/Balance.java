import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Balance {

    // Stores user input and what, if any, runes are excluded from balance.
    public static int[] reagentTotals = {0, 0, 0, 0};
    public static int exclusion = 0;

    public static void optimizeReagents(boolean[] balanceTypes){
        /* Acquire user input and ensures the input is valid. Uses bool array to find the excluded dungeon type.
        * */
        String[] reagentTypes = {"Green Symbols", "Red Symbols", "Purple Symbols", "Rune Pieces"};

        for(int i = 0; i < reagentTypes.length; i++){
            System.out.println("Please enter the number of " + reagentTypes[i] + ": ");
            reagentTotals[i] = Reagent.getInput();
        }

        if (Arrays.equals(balanceTypes, new boolean[]{false, true, true})) {
            exclusion = 0;
        }
        else if(Arrays.equals(balanceTypes, new boolean[]{true, false, true})){
            exclusion = 1;
        }
        else if(Arrays.equals(balanceTypes, new boolean[]{true, true, false})){
            exclusion = 2;
        }
        else{
            exclusion = 3;
        }

        balance(exclusion);

    }


    /*
    note that this program is set up to only maximize over the Cairos crafts.

    Maximizing over additional crafts (raids, ancients) requires their cost vectors to be included. If any of the craft
    materials are shared between the types of crafts (ex. rune pieces between raid crafts and Cairos crafts), the
    cost vectors for both locations must be extended to contain values for all potential materials that could be used with
    any of the materials for that given location. (i.e. for Cairos crafts you not only need to include information regarding
    the green/red/purple material for Cairos crafts, but also a series of indices filled with zeros in the locations
    correlating to the raid crystal usages, vice versa for raid crafts)
     */

    //caiross crafts
    //format: (green, red, purple, rune pieces)
    public static int main_cost = 18;
    public static int alt_cost = 6;
    public static int piece_cost = 12;
    public static int[] giant_cost_vec = new int[]{main_cost, 0, alt_cost, piece_cost};
    public static int[] dragon_cost_vec = new int[]{alt_cost, main_cost, 0, piece_cost};
    public static int[] necro_cost_vec = new int[]{0, alt_cost, main_cost, piece_cost};

    public static boolean GreaterThan(int limit, int[] data){
        /*
        determines if all of vector data is greater than some limit

        returns true if yes, false if no
         */
        for (int datum : data) {
            if (datum < limit)
                return false;
        }
        return true;
    }

    public static int findMaxIndex(int[] data){
        /*
        finds index containing the maximum value of data vector
         */
        int max = 0;
        for(int k = 1; k < data.length; k++){
            if (data[k] > data[max]) {
                max = k;
            }
        }
        return max;
    }

    public static int findErrorCraft(int x, int y, int z, int prevX, int prevY, int prevZ){
        /*
        gross if block recovering the most recently made rune craft
         */
        int errorCraft = -1;
        if (x - prevX > 0){
            errorCraft = 0;
        } else if (y - prevY > 0) {
            errorCraft = 1;
        } else if (z - prevZ > 0) {
            errorCraft = 2;
        }
        return errorCraft;
    }

    public static int[] computeResidual(int x, int y, int z, int[] supply_vec){
        /*
        computes the residual in rune craft materials between inventory and what is currently being used for the proposed
        craft setup. The goal of the program is to maximize the # of rune crafts by minimizing this residual.
         */
        int[] costVec = new int[4];
        int[] cap = new int[4];
        for(int k = 0; k < cap.length; k++){
            costVec[k] = x*giant_cost_vec[k] + y*dragon_cost_vec[k] + z*necro_cost_vec[k];
            cap[k] = supply_vec[k] - costVec[k];
        }
        return cap;
    }

    public static void balance(int exclusion) {
        // these are inputs that need to be fed in: crafting materials available for the given player
        int harmony = reagentTotals[0];        //'green'
        int transcendence = reagentTotals[1]; //'red'
        int chaos = reagentTotals[2];           //'purple'
        int pieces = reagentTotals[3];     //'rune pieces'

        int[] supply_vec = new int[]{harmony, transcendence, chaos, pieces};

        int[][] total_cost = new int[][]{giant_cost_vec, dragon_cost_vec, necro_cost_vec};

        int x = 0; //giants crafts
        int y = 0; //dragons crafts
        int z = 0; //necro crafts
        int prevX = 0;
        int prevY = 0;
        int prevZ = 0;

        /*
        list of runes that are no longer considered for crafting optimization
        if we only maximize over two rune types, we can lock the primary crafting component of the rune we aren't
        interested in.

        remember that we are maximizing craft quantity. if we want to priotize crafting certain runes, then others
        (i.e. giants, then necro, then dragons) then taking the simple maximum of our residual (see switch statement)
        is not sufficient. instead, we would need to iterate x then z then y (in this scenario) for as long as
        craft components hold out.
        */
        List<Integer> fixed_runes = new ArrayList<>();
        fixed_runes.add(exclusion); // sample code to ignore crafting one type of rune (user decides only giants, necro for this case)

        int[] residual;

        while (fixed_runes.size() < total_cost.length) {
            residual = computeResidual(x, y, z, supply_vec);

            if (GreaterThan(0, residual)){
                prevX = x;
                prevY = y;
                prevZ = z;
                //force any locked runes to be uncraftable (either by user choice or by no craft materials remaining)
                for (Integer fixed_rune : fixed_runes) {
                    residual[fixed_rune] = 0;
                }

                switch (findMaxIndex(Arrays.copyOfRange(residual, 0, 3))){
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
            } else {
                //if negative residual, find 'problem' craft and prevent that craft type from being considered further
                fixed_runes.add(findErrorCraft(x, y, z, prevX, prevY, prevZ));
                x = prevX;
                y = prevY;
                z = prevZ;
            }
        }

        int totalCraft = x + y + z;

        int[] runes = {x, y, z};
        int legend = (int) (totalCraft * 0.03);

        // Output the calculated information based on user input.
        DecimalFormat df = new DecimalFormat("#,###");
        String mana = df.format(15000L * totalCraft);

        System.out.println("You can craft a total of " + totalCraft + " runes!");

        for(int i = 0; i < Reagent.listRunesBalance.length; i++){
            if(!Reagent.listRunesBalance[i].equals(" ")){
                System.out.println(Reagent.listRunesBalance[i] + ": " + runes[i]);
            }
        }

        System.out.println("It will cost you " + mana + " mana! Make sure to stock up!");
        System.out.println("You should get " + legend + " legendary 6* runes!" );
    }
}
