using projet_gestion_temps_cse_axe_system;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public System.Windows.Forms.RadioButton radioButton1 = new System.Windows.Forms.RadioButton();
        public System.Windows.Forms.RadioButton radioButton2 = new System.Windows.Forms.RadioButton();

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
                    int interval = 100;
                    foreach (Personnes personne in personnes)
                    {

                        string nameOnButton = personne.name + "\n" + personne.firstName;
                        Button buttonPersonne = Styles.CreateButtonMenu(Color.Gray, foreground, nameOnButton);
                        buttonPersonne.Location = new Point(20, interval);
                        panel.Controls.Add(buttonPersonne);
                        interval += 90;
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

            Label nameTitle = Styles.FormLabel("Nom :", 120);
            signIn.Controls.Add(nameTitle);

            name = Styles.TextField(70, 170);
            signIn.Controls.Add(name);

            Label firstNameLabel = Styles.FormLabel("Prénom :", 200);
            signIn.Controls.Add(firstNameLabel);

            firstName = Styles.TextField(70, 250);
            signIn.Controls.Add(firstName);

            radioButton1 = new System.Windows.Forms.RadioButton();
            radioButton1.Text = "Homme";
            radioButton1.ForeColor = Color.FromArgb(166, 154, 121);
            radioButton1.Location = new System.Drawing.Point(120, 300);
            signIn.Controls.Add(radioButton1);

            radioButton2 = new System.Windows.Forms.RadioButton();
            radioButton2.Text = "Femme";
            radioButton2.ForeColor = Color.FromArgb(166, 154, 121);
            radioButton2.Location = new System.Drawing.Point(300, 300);
            signIn.Controls.Add(radioButton2);

            Styles.ItemsAddUser(signIn, name, firstName, radioButton1, radioButton2);

            Button newUser = Styles.CreateButtonNewUser(Color.FromArgb(166, 154, 121), background, 180, 400, "Ajouter ...");
            newUser.Click += new EventHandler(NewPersonne_Click);
            signIn.Controls.Add(newUser);
            signIn.Show();
        }

        private void NewPersonne_Click(object sender, EventArgs e)
        {
            if ((!String.IsNullOrEmpty(name.Text)) && (!String.IsNullOrEmpty(firstName.Text)))
            {
                string nameLog = name.Text;
                string firstNameLog = firstName.Text;

                if (radioButton1.Checked)
                {
                    // Le bouton radio 1 est sélectionné
                    Personnes newUser = new Personnes(nameLog, firstNameLog, true);
                    personnes.Add(newUser);
                    ImportJsonFromFile.Send(personnes);
                    MessageBox.Show("Inscrit avec succès");
                }
                else if (radioButton2.Checked)
                {
                    // Le bouton radio 2 est sélectionné
                    Personnes newUser = new Personnes(nameLog, firstNameLog, false);
                    personnes.Add(newUser);
                    ImportJsonFromFile.Send(personnes);
                    MessageBox.Show("Inscrit avec succès");
                }

            }
            else
            {
                MessageBox.Show("ERREUR : Veuillez remplir tous les champs");
                name.Text = null;
                firstName.Text = null;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}