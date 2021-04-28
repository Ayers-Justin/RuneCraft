/** Justin Ayers. 4/16/2021. A personal note.
 * This is a project that I am creating for a mobile video game called Summoner's War.
 *  In this game, one of the many, many things you can do is collect crafting ingredients.
 *  With the crafting ingredients, you can craft runes, which increase the power of your units.
 *  The original concept was designed with the premise of crafting one specific type of rune, however,
 *  I thought it might be advantageous to allow the user to calculate how many runes they can craft
 *  of other types as well. This was received well within the community of players who play the game.
 *
 *  4/20/2021. One functionality improvement suggestion I received was to allow the user to pick 2 types of runes
 *  that may share some of the same ingredients, and determine the optimal amount of runes to craft of
 *  either type, such that they may craft the most runes possible with the ingredients that they have.
 *  This functionality is a work in progress, and I have redefined the original methods in a way that
 *  uses less code to accomplish the same task. I write this to document my progress on the chance that
 *  it becomes useful to someone later down the road. If someone were to be able to improve on my code
 *  to achieve bigger and better things, I would be open to the opportunity to work with them.
 *
 *  Update 4/24/2021. I found a couple of people willing to assist me with the logic to optimize rune crafts.
 *  I anticipate an end to this project soon.
 *
 *  Update 4/26/2021. I am done implementing the optimization logic. Now to clean up and organize code. */

public class Craft {
    public static void main(String[] args){
<<<<<<< HEAD

        JFrame frame = new JFrame("Summoners War Rune Craft");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(400, 400);

        JPanel panel = new JPanel(); // the panel is not visible in output
        JLabel label = new JLabel("Enter Text");
        JTextField tf = new JTextField(15); // accepts up to 15 characters
        panel.add(label); // Components Added using Flow Layout
        panel.add(tf);

        JTextArea ta = new JTextArea();

        frame.getContentPane().add(BorderLayout.SOUTH, panel);
        frame.getContentPane().add(BorderLayout.CENTER, ta);
        frame.setVisible(true);


=======
>>>>>>> parent of daf20c2 (Migrated files to new project. Reorganized naming structure. Resolved typos.)
        Intro.intro();
    }
}
