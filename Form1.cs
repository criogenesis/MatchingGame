using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TEST FOR SIGNING PURPOSES
namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Label firstClickedLabel = null;
        Label secondClickedLabel = null;
        bool TimerFlag = false;

        // NOTE TO SELF LEFT OFF HERE IN THE TUTORIAL, DELETE WHEN YOU RETURN HERE:
        // https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-windows-forms-match-game-icons?view=vs-2022&tabs=csharp



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
        /// Starts a 2 second timer that triggers the OnTimedEvent function when the time is done.
        /// </summary>
        private void TimerFunction()
        {
            TimerFlag = true;
            Console.WriteLine("TimerFunction Start");
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false; // Only fire once
            timer.Enabled = true;
        }

        /// <summary>
        /// Function responsible for reseting the matched options back to the original blue color since neither will match
        /// When this function is called after the timer function is called.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Match NOT found!");
            Console.WriteLine(TimerFlag);

            // Hides both labels then sets them back to null for the next potential pairs.
            firstClickedLabel.ForeColor = firstClickedLabel.BackColor;
            secondClickedLabel.ForeColor = secondClickedLabel.BackColor;
            firstClickedLabel = null;
            secondClickedLabel = null;
            TimerFlag = false;
        }

        /// <summary>
        /// Every label's Click event is handled by this event handler
        /// </summary>
        /// <param name="sender">The label that was clicked</param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {

            Label clickedLabel = sender as Label;

            // We want to return out of the function if a timer is currently running to prevent null pointer exceptions if
            // the player clicks another block while the timer is going.
            if(TimerFlag == true)
            {
                Console.WriteLine("WE RETURNIN FRFR");
                return;
            }

            // Checks if the first clicked label has been assigned to the initial clickedLabel variable
            // if it hasn't, assign it and show the icon.
            // otherwise, assign the second label.
            if (firstClickedLabel == null)
            {
                firstClickedLabel = clickedLabel;
                firstClickedLabel.ForeColor = Color.Black;
            }
            else
            {
                secondClickedLabel = clickedLabel;
                secondClickedLabel.ForeColor = Color.Black;
            }

            // Since both have been chosen we decide to see if there's a match
            if (firstClickedLabel != null && secondClickedLabel != null)
            {
                // If a match has been found, we keep those specific icons shown until the end of the game
                if (firstClickedLabel.Text == secondClickedLabel.Text)
                {
                    Console.WriteLine("Match found!");
                    firstClickedLabel = null;
                    secondClickedLabel = null;
                }

                // If it's not a match and we begin the 2 second timer to show the player which ones were wrong
                // so that they can remember them.
                else
                {
                    TimerFunction();
                }
            }

        }
    }
}
