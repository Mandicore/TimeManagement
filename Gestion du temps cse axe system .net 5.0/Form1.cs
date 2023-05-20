using projet_gestion_temps_cse_axe_system;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Gestion_du_temps_cse_axe_system_.net_5._0
{
    public partial class Form1 : Form
    {
        //App settings 
        private Color background = Color.FromArgb(24, 30, 42);
        private Color foreground = Color.FromArgb(166, 154, 121);

        //New personnes
        public System.Windows.Forms.RadioButton radioButton1 = new System.Windows.Forms.RadioButton();
        public System.Windows.Forms.RadioButton radioButton2 = new System.Windows.Forms.RadioButton();

        // Personnes elements
        private Personnes personneSelect;
        public List<Personnes> personnes = GetListPersonnes.GetListPersonneFromJson();
        public TextBox name = new TextBox();
        public TextBox firstName = new TextBox();

        // Panels elements
        private bool panelOpen = false;
        private Panel panel = new Panel();
        private Button burgerButton = new Button();
        int interval = 150;

        // all forms
        private Form years;
        private Form signIn;
        private Form infosPersonnes;
        private Form month;
        private Form days;
        private Form hour;

        // Create new event
        private int yearByUser;
        private string monthByUser;
        private int dayByUser;
        private int hourByUser;
        private ComboBox boxYear;
        private ComboBox boxMonth;
        private ComboBox boxDays;
        private List<string> monthWith30Days = new List<string>
        {
            "Février",
            "Avril",
            "Juin",
            "Septembre",
            "Novembre"
        };
        private List<int> leapYear = new List<int>
        {
            2024,
            2028,
            2032,
            2036,
            2040,
            2044,
            2048
        };


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
                panel.AutoScroll = true;
                if (personnes != null)
                {
                    
                    Label panelTitle = Styles.panelTitle(foreground, Color.Gray, "Utilisateurs", 17, new Point(70, 80), new Size(150, 40));
                    panel.Controls.Add(panelTitle);
                    foreach (Personnes personne in personnes)
                    {

                        string nameOnButton = personne.name + "\n" + personne.firstName;
                        Button buttonPersonne = Styles.CreateButtonMenu(Color.Gray, foreground, nameOnButton, personne.id);
                        buttonPersonne.Location = new Point(20, interval);
                        buttonPersonne.Click += new EventHandler(personnesButton_Click);
                        panel.Controls.Add(buttonPersonne);
                        interval += 90;
                    }

                }
                Button add = Styles.CreateButtonAdd(foreground, background, "Ajouter ...");
                add.Click += new EventHandler(add_Click);
                add.Location = new Point(90, interval + 10);
                interval = 150;
                panel.Controls.Add(add);
                panelOpen = true;


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
        private void personnesButton_Click(object sender, EventArgs e)
        {
            infosPersonnes = Styles.InfosPersonne(background);

            Button buttonPersonne = (Button)sender;
            int tag = int.Parse(buttonPersonne.Tag.ToString());
            personneSelect = Personnes.CheckById(personnes, tag);
            Styles.PersonnePageStyle(personneSelect, infosPersonnes);
            infosPersonnes.Text = personneSelect.name + " " + personneSelect.firstName;

            //Button delete user
            Button delete = Styles.ButtonDelete();
            delete.Click += new EventHandler(DeleteButton_Click);
            infosPersonnes.Controls.Add(delete);

            //Button new Events
            Button newEvent = Styles.CreateButtonAdd(foreground, background, "Nouvelles Heures ...");
            newEvent.Click += new EventHandler(addEvent_Click);
            newEvent.Location = new Point(418, 340);
            infosPersonnes.Controls.Add(newEvent);
            

            //Show Form
            infosPersonnes.Show();
        }
        private void addEvent_Click(object sender, EventArgs e)
        {
            years = Styles.NewLittleForm(background, foreground, "Choisissez une année !");

            //Create ComboBox
            boxYear = Styles.ComboBoxYears();
            years.Controls.Add(boxYear);

            //Create Label
            Label ActionForUser = Styles.panelTitle(foreground, background, "Année : ", 16, new Point(60, 94), new Size(150, 40));
            years.Controls.Add(ActionForUser);

            //Create Button
            Button SendYear = Styles.CreateButtonAdd(foreground, background, "Valider !");
            SendYear.Click += new EventHandler(SendYear_Click);
            SendYear.Location = new Point(130, 170);
            years.Controls.Add(SendYear);


            //print form
            years.Show();
            

            /*
            Form Month = Styles.NewLittleForm(background, foreground, "Choisissez un mois !");
            Month.Show();

            Form Day = Styles.NewLittleForm(background, foreground, "Choisissez un jour !");
            Month.Show();*/
        }
        private void SendYear_Click(object sender, EventArgs e) 
        {
            try
            {
                yearByUser = int.Parse(boxYear.SelectedItem.ToString());

                month = Styles.NewLittleForm(background, foreground, "Choisissez un mois !");

                boxMonth = Styles.ComboBoxMonth();
                month.Controls.Add(boxMonth);

                //Create Label
                Label ActionForUser = Styles.panelTitle(foreground, background, "Mois : ", 16, new Point(60, 94), new Size(150, 40));
                month.Controls.Add(ActionForUser);

                //Create Button
                Button SendYear = Styles.CreateButtonAdd(foreground, background, "Valider !");
                SendYear.Click += new EventHandler(SendMonth_Click);
                SendYear.Location = new Point(130, 170);
                month.Controls.Add(SendYear);

                month.Show();
                years.Hide();
            }
            catch
            {
                MessageBox.Show("Erreur : ");
            }
        }
        private void SendMonth_Click(object sender, EventArgs e)
        {
            monthByUser = boxMonth.SelectedItem.ToString();

            days = Styles.NewLittleForm(background, foreground, "Choisissez un jour !");

            //create Box
            if ((leapYear.Contains(yearByUser)) && (monthByUser == "Février"))
            {
                boxMonth = Styles.ComboBoxDays(30);
            }
            else if (monthWith30Days.Contains(monthByUser))
            {
                boxMonth = Styles.ComboBoxDays(31);
                
            }
            else
            {
                boxMonth = Styles.ComboBoxDays(32);
            }

            days.Controls.Add(boxMonth);


            //Create Label
            Label ActionForUser = Styles.panelTitle(foreground, background, "Jour : ", 16, new Point(60, 94), new Size(150, 40));
            days.Controls.Add(ActionForUser);

            //Create Button
            Button SendYear = Styles.CreateButtonAdd(foreground, background, "Valider !");
            SendYear.Click += new EventHandler(SendDay_Click);
            SendYear.Location = new Point(130, 170);
            days.Controls.Add(SendYear);

            days.Show();
            month.Hide();


        }
        private void SendDay_Click(object sender, EventArgs e)
        {
            try
            {
                dayByUser = int.Parse(boxDays.SelectedItem.ToString());

                hour = Styles.NewLittleForm(background, foreground, "Choisissez un mois !");

                boxMonth = Styles.ComboBoxMonth();
                month.Controls.Add(boxMonth);

                //Create Label
                Label ActionForUser = Styles.panelTitle(foreground, background, "Mois : ", 16, new Point(60, 94), new Size(150, 40));
                month.Controls.Add(ActionForUser);

                //Create Button
                Button SendYear = Styles.CreateButtonAdd(foreground, background, "Valider !");
                SendYear.Click += new EventHandler(SendMonth_Click);
                SendYear.Location = new Point(130, 170);
                month.Controls.Add(SendYear);

                month.Show();
                years.Hide();

            }
            catch
            {
                MessageBox.Show("Erreur : ");
            }
            
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (personneSelect != null)
            {
                personnes.Remove(personneSelect);
                MessageBox.Show("La personne a été supprimée avec succès.");
                personneSelect = null;
                ImportJsonFromFile.Send(personnes);
                panelOpen = false;
                this.Controls.Remove(panel);
                infosPersonnes.Hide();
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            signIn = Styles.NewUserForm(background);

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
                int id = Personnes.SetIdPersonne(personnes);

                if (radioButton1.Checked)
                {
                    Personnes newUser = new Personnes(nameLog.ToUpper(), firstNameLog, true, id);
                    personnes.Add(newUser);
                    ImportJsonFromFile.Send(personnes);
                    MessageBox.Show("Inscrit avec succès");

                    this.Controls.Remove(panel);
                    burgerButton.BackColor = background;
                    burgerButton.FlatAppearance.BorderColor = background;
                    burgerButton.ForeColor = foreground;
                    panelOpen = false;
                    this.Controls.Remove(panel);
                    signIn.Hide();

                }
                else if (radioButton2.Checked)
                {
                    Personnes newUser = new Personnes(nameLog.ToUpper(), firstNameLog, false, id);
                    personnes.Add(newUser);
                    ImportJsonFromFile.Send(personnes);
                    MessageBox.Show("Inscrit avec succès");

                    this.Controls.Remove(panel);
                    burgerButton.BackColor = background;
                    burgerButton.FlatAppearance.BorderColor = background;
                    burgerButton.ForeColor = foreground;
                    panelOpen = false;

                    signIn.Hide();
                }
                else
                {
                    MessageBox.Show("ERREUR : Veuillez remplir tous les champs");
                    name.Text = null;
                    firstName.Text = null;
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