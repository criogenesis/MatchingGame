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
