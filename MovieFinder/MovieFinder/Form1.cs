using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moviesDataSet.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.moviesDataSet.Movies);

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            displayTextBox.Items.Clear();
            string userInput = inputTextBox.Text.ToLower();
            if (titleRadioButton.Checked)
            {
                displayTextBox.Items.Add("The titles that have " + "''" + inputTextBox.Text + "''" + " in them are:");
                displayTextBox.Items.Add("\n");

                this.moviesTableAdapter.Fill(this.moviesDataSet.Movies);
                var title = from m in this.moviesDataSet.Movies
                                 where m.Title.IndexOf(userInput, StringComparison.OrdinalIgnoreCase) >= 0
                                 select m;
                foreach (var m in title)
                {
                    displayTextBox.Items.Add(m.Title);

                }
                
            }
            else if (directorRadioButton.Checked)
            {
                this.moviesTableAdapter.Fill
                    (this.moviesDataSet.Movies);
                var director = from d in this.moviesDataSet.Movies
                                 where d.Director.IndexOf(userInput, StringComparison.OrdinalIgnoreCase) >= 0
                                 select d;

                displayTextBox.Items.Add("The directors name is: " + inputTextBox.Text);
                displayTextBox.Items.Add("\n");
                displayTextBox.Items.Add(inputTextBox.Text + " directed such classics as: ");
                foreach (var d in director)
                {
                    displayTextBox.Items.Add(d.Title);
                }
            }
        }
    }
}
