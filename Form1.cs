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
                Label iconLabel = control as Label;
                if(iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    // iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
