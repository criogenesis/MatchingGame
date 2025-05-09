using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        // NOTE TO SELF LEFT OFF HERE IN THE TUTORIAL, DELETE WHEN YOU RETURN HERE:
        // https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-windows-forms-match-game-icons?view=vs-2022&tabs=csharp
        // vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        // Assign a random icon to each label



        // This Random object will be used to create random icons for each of my squares.
        Random random = new Random();

        // This list will hold the icons that will be used in the game.
        // It will be randomized via the Random object.
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        /// <summary>
        /// Assign icons to each square randomly
        /// </summary>
        private void AssignIconsToSquare()
        {
            // The TableLayoutPanel has 16 labels,
            // and the icon list has 16 icons,
            // so an icon is pulled at random from the list
            // and added to each label
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                // converts the control variable to a label named iconLabel.
                // I've learned that this is utilizing a safe type casting system, this way it can set iconLabel as null if it
                // finds a control that can't be cast as a label. Then the following if statement ignores iconLabel.
                // This is done to prevent an error being thrown as there's a high chance other controls in the winform wouldnt be able
                // to be type casted as a label.
                Label iconLabel = control as Label;
                if(iconLabel != null)
                {
                    // Creates a random number
                    // the .Next function is picking the size of the array for what range of numbers to choose from
                    // and the size of the array is shown through icons.Count
                    int randomNumber = random.Next(icons.Count);

                    // Self-explanatory but, takes the letter at the now specified indice from the random number
                    // and sets it equal to the text of the iconLabel, which is the image of the square in this case.
                    iconLabel.Text = icons[randomNumber];


                    iconLabel.ForeColor = iconLabel.BackColor;

                    // removes this option from the list as it has been already used in the grid
                    // **Note the list is manually created and consists of a duplicate of every icon used**
                    icons.RemoveAt(randomNumber);
                }
            }
        }


        // This is the constructor for the Form1 class.
        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquare();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Every label's Click event is handled by this event handler
        /// </summary>
        /// <param name="sender">The label that was clicked</param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {

            Label clickedLabel = sender as Label;

            if(clickedLabel != null)
            {
                
                if(clickedLabel.ForeColor == Color.Black)
                {
                    return;
                }
                clickedLabel.ForeColor = Color.Black;
            }

        }
    }
}
