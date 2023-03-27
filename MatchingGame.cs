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
    public partial class MatchingGame : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        private bool helppopeliPelaa = false;
        private bool normaalipeliPelaa = false;
        private bool vaikeapeliPelaa = false;
        
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        public MatchingGame()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in helppopeli.Controls)
            {
                Label iconLabel = control as Label;
                if(iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void MatchingGame_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if(clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                {
                    return;
                }

                if(firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if(firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            foreach(Control control in helppopeli.Controls)
            {
                Label iconLabel = control as Label;

                if(iconLabel  != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("You won!", "Congratulations");
            Close();
        }

        private void aloitanappi_Click(object sender, EventArgs e)
        {
            helpponappi.Visible = true;
            normaalinappi.Visible = true;
            vaikeanappi.Visible = true;
            aloitanappi.Visible = false;
            tilastotnappi.Visible = false;
            takaisinnappi.Visible = true;
        }

        private void helpponappi_Click(object sender, EventArgs e)
        {
            helpponappi.Visible = false;
            normaalinappi.Visible = false;
            vaikeanappi.Visible = false;
            helppopeli.Visible = true;
            helppopeliPelaa = true;
            takaisinnappi.Visible = false;
        }

        private void normaalinappi_Click(object sender, EventArgs e)
        {
            helpponappi.Visible = false;
            normaalinappi.Visible = false;
            vaikeanappi.Visible = false;
            normaaliPeli.Visible = true;
            normaalipeliPelaa = true;
            takaisinnappi.Visible = false;
        }

        private void vaikeanappi_Click(object sender, EventArgs e)
        {
            helpponappi.Visible = false;
            normaalinappi.Visible = false;
            vaikeanappi.Visible = false;
            vaikeaPeli.Visible = true;
            vaikeapeliPelaa = true;
            takaisinnappi.Visible = false;
        }

        private void helpponappi_MouseHover(object sender, EventArgs e)
        {
            helppopeli.Visible = true;
        }

        private void helpponappi_MouseLeave(object sender, EventArgs e)
        {
            if(helppopeliPelaa == false)
                {
                helppopeli.Visible = false;
            }
        }

        private void tilastotnappi_Click(object sender, EventArgs e)
        {
            aloitanappi.Visible = false;
            tilastotnappi.Visible = false;
            takaisinnappi.Visible = true;
        }

        private void normaalinappi_MouseHover(object sender, EventArgs e)
        {
            normaaliPeli.Visible = true;
        }

        private void normaalinappi_MouseLeave(object sender, EventArgs e)
        {
            if (normaalipeliPelaa == false)
            {
                normaaliPeli.Visible = false;
            }
        }

        private void vaikeanappi_MouseHover(object sender, EventArgs e)
        {
            vaikeaPeli.Visible = true;
        }

        private void vaikeanappi_MouseLeave(object sender, EventArgs e)
        {
            if (vaikeapeliPelaa == false)
            {
                vaikeaPeli.Visible = false;
            }
        }

        private void takaisinnappi_Click(object sender, EventArgs e)
        {
            takaisinnappi.Visible = false;
            aloitanappi.Visible = true;
            tilastotnappi.Visible = true;
            if (helpponappi.Visible == true)
            {
                takaisinnappi.Visible = false;
                aloitanappi.Visible = true;
                helpponappi.Visible = false;
                normaalinappi.Visible = false;
                vaikeanappi.Visible = false;
            }
        }
    }
}
