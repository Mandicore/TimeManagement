using projet_gestion_temps_cse_axe_system;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_du_temps_cse_axe_system_.net_5._0
{
    public partial class Form1 : Form
    {
        private Color background = Color.FromArgb(24, 30, 42);
        private Color foreground = Color.FromArgb(166, 154, 121);

        private bool panelOpen = false;
        private Panel panel = new Panel();
        private Button burgerButton = new Button();

        public TextBox name = new TextBox();
        public TextBox firstName = new TextBox();

        public List<Personnes> personnes = GetListPersonnes.GetListPersonneFromJson();
        public Form1()
        {
            InitializeComponent();

            int Width = ScreenSetings.GetWidthScreen(this);
            int Height = ScreenSetings.GetHeightScreen(this);


            //form style
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = background;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.MinimumSize = Screen.PrimaryScreen.WorkingArea.Size;

            //Home Text (date)
            Label HomeText = Styles.HomeText(background, foreground, Width, 100, this);
            this.Controls.Add(HomeText);

            // Menu burger
            burgerButton = Styles.CreateButton(background, foreground);
            burgerButton.Click += new EventHandler(burgerButton_Click);
            this.Controls.Add(burgerButton);
        }
        private void burgerButton_Click(object sender, EventArgs e)
        {
            if (!panelOpen)
            {
                panel = Styles.CreatePanel();
                this.Controls.Add(panel);
                burgerButton.BackColor = Color.Gray;
                burgerButton.FlatAppearance.BorderColor = Color.Gray;
                burgerButton.ForeColor = Color.Black;

                if (personnes != null)
                {
                    foreach (Personnes personne in personnes)
                    {
                        Button buttonPersonne = Styles.CreateButtonMenu(Color.Gray, foreground, personne.name);
                        panel.Controls.Add(buttonPersonne);
                    }

                    Button add = Styles.CreateButtonAdd(foreground, background, "Ajouter ...");
                    add.Click += new EventHandler(add_Click);
                    panel.Controls.Add(add);
                    panelOpen = true;
                }


            }
            else
            {
                this.Controls.Remove(panel);
                burgerButton.BackColor = background;
                burgerButton.FlatAppearance.BorderColor = background;
                burgerButton.ForeColor = foreground;
                panelOpen = false;

            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            Form signIn = Styles.NewUserForm(background);
            Styles.ItemsAddUser(signIn, name, firstName);

            Label nameTitle = Styles.FormLabel("Nom :", 120);
            signIn.Controls.Add(nameTitle);

            name = Styles.TextField(70, 170);
            signIn.Controls.Add(name);

            Label firstNameLabel = Styles.FormLabel("Prénom :", 200);
            signIn.Controls.Add(firstNameLabel);

            firstName = Styles.TextField(70, 250);
            signIn.Controls.Add(firstName);

            Button newUser = Styles.CreateButtonNewUser(Color.FromArgb(166, 154, 121), background, 180, 400, "Ajouter ...");
            newUser.Click += new EventHandler(NewPersonne_Click);
            signIn.Controls.Add(newUser);
            signIn.Show();

        }

        private void NewPersonne_Click(object sender, EventArgs e)
        {
            if ((!String.IsNullOrEmpty(name.Text))&&(!String.IsNullOrEmpty(firstName.Text)))
            {
                string nameLog = name.Text;
                string firstNameLog = firstName.Text;

                Personnes newUser = new Personnes(nameLog, firstNameLog, true);
                personnes.Add(newUser);
                ImportJsonFromFile.Send(personnes);

            }
            else
            {
                MessageBox.Show("hors du if !");
            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}