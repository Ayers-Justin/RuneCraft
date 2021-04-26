import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Balance {

    public static int[] reagentTotals = {0, 0, 0, 0};
    public static int exclusion = 0;

    public static void optimizeReagents(boolean[] balanceTypes){

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

    public static int main_cost = 18;
    public static int alt_cost = 6;
    public static int piece_cost = 12;
    public static int[] giant_cost_vec = new int[]{main_cost, 0, alt_cost, piece_cost};
    public static int[] dragon_cost_vec = new int[]{alt_cost, main_cost, 0, piece_cost};
    public static int[] necro_cost_vec = new int[]{0, alt_cost, main_cost, piece_cost};

    public static boolean GreaterThan(int limit, int[] data){

        for (int datum : data) {
            if (datum < limit)
                return false;
        }
        return true;
    }

    public static int findMaxIndex(int[] data){

        int max = 0;
        for(int k = 1; k < data.length; k++){
            if (data[k] > data[max]) {
                max = k;
            }
        }
        return max;
    }

    public static int findErrorCraft(int x, int y, int z, int prevX, int prevY, int prevZ){

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

        int[] costVec = new int[4];
        int[] cap = new int[4];
        for(int k = 0; k < cap.length; k++){
            costVec[k] = x*giant_cost_vec[k] + y*dragon_cost_vec[k] + z*necro_cost_vec[k];
            cap[k] = supply_vec[k] - costVec[k];
        }
        return cap;
    }

    public static void balance(int exclusion) {

        int harmony = reagentTotals[0];
        int transcendence = reagentTotals[1];
        int chaos = reagentTotals[2];
        int pieces = reagentTotals[3];

        int[] supply_vec = new int[]{harmony, transcendence, chaos, pieces};

        int[][] total_cost = new int[][]{giant_cost_vec, dragon_cost_vec, necro_cost_vec};

        int x = 0;
        int y = 0;
        int z = 0;
        int prevX = 0;
        int prevY = 0;
        int prevZ = 0;


        List<Integer> fixed_runes = new ArrayList<>();
        fixed_runes.add(exclusion);

        int[] residual;

        while (fixed_runes.size() < total_cost.length) {
            residual = computeResidual(x, y, z, supply_vec);

            if (GreaterThan(0, residual)){
                prevX = x;
                prevY = y;
                prevZ = z;

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

                fixed_runes.add(findErrorCraft(x, y, z, prevX, prevY, prevZ));
                x = prevX;
                y = prevY;
                z = prevZ;
            }
        }


        int totalCraft = x + y + z;

        int[] runes = {x, y, z};
        int legend = (int) (totalCraft * 0.03);

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
