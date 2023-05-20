using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Newtonsoft.Json;
using projet_gestion_temps_cse_axe_system;

namespace Gestion_du_temps_cse_axe_system_.net_5._0
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public static class Styles
    {
        public static Panel CreatePanel()
        {
            Panel menuPanel = new Panel();
            menuPanel.BackColor = Color.Gray;
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Width = 300;
            return menuPanel;
        }
        public static Label HomeText(Color backColor, Color color, int sizeX, int sizeY, Form form)
        {
            Label label = new Label();
            label.Text = GetDate();
            label.Size = new Size(sizeX - 30, sizeY);
            label.BackColor = backColor;
            label.ForeColor = color;
            label.Font = new Font("Arial", 30, FontStyle.Italic);
            label.TextAlign = ContentAlignment.MiddleCenter;

            int LocationX = (15) + (form.ClientSize.Width / 2) - (label.Size.Width / 2);
            int LocationY = (form.ClientSize.Height / 2) - (label.Size.Height / 2);

            label.Location = new Point(LocationX, LocationY);
            label.Anchor = AnchorStyles.None;

            return label;
        }
        public static Label panelTitle(Color Foreground, Color background,string text, int fontSize, Point location, Size size)
        {
            Label label = new Label();
            label.BackColor = background;
            label.ForeColor = Foreground;
            label.Size = size;
            label.Text = text;
            label.Font = new Font("Arial", fontSize, FontStyle.Bold);
            label.Location = location;
            label.TextAlign = ContentAlignment.MiddleCenter;
            return label;

        }
        public static Form InfosPersonne(Color background)
        {
            Form form = new Form();

            form.Size = new System.Drawing.Size(1000, 700);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = background;
            form.MaximumSize = new System.Drawing.Size(1000, 700);
            form.MinimumSize = new System.Drawing.Size(1000, 700);
                
            return form;

        }
        public static Label FormLabel (string text, int locationY)
        {
            Label label = new Label();
            label.Text = text;
            label.Size = new Size(80, 50);
            label.BackColor = Color.FromArgb(24, 30, 42);
            label.ForeColor = Color.FromArgb(166, 154, 121);
            label.Font = new Font("Arial", 12, FontStyle.Italic);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = new Point(60, locationY);
            label.Anchor = AnchorStyles.None;

            return label;
        }
        public static System.Windows.Forms.Button CreateButton(Color backColor, Color foreColor)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = "\u2630";
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new Font("Arial", 30, FontStyle.Bold);
            button.Size = new Size(55, 55);
            button.Location = new Point(15, 15);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = backColor; ;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 208, 200, 178);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 116, 108, 97);
            return button;
        }
        public static System.Windows.Forms.Button CreateButtonMenu(Color backColor, Color foreColor, string text, int id)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = text;
            button.Tag = id;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new Font("Arial", 18, FontStyle.Bold);
            button.Size = new Size(250, 80);
            button.Location = new Point(20, 100);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Black;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 208, 200, 178);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 116, 108, 97);
            return button;
        }
        public static System.Windows.Forms.Button CreateButtonAdd(Color backColor, Color foreColor, string text)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = text;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new Font("Arial", 10, FontStyle.Bold);
            button.Size = new Size(120, 50);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Black;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 208, 200, 178);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 116, 108, 97);
            return button;
        }
        public static System.Windows.Forms.Button ButtonDelete()
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = "Supprimer";
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.Location = new Point(15, 15);
            button.BackColor = Color.Red;
            button.ForeColor = Color.Black;
            button.Font = new Font("Arial", 12, FontStyle.Bold);
            button.Size = new Size(100, 40);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Black;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 208, 200, 178);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 116, 108, 97);

            return button;
        }
        public static System.Windows.Forms.Button CreateButtonNewUser(Color backColor, Color foreColor, int LocationX, int LocationY, string text)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = text;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new Font("Arial", 10, FontStyle.Bold);
            button.Size = new Size(100, 30);
            button.Location = new Point(LocationX, LocationY);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Black;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 208, 200, 178);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 116, 108, 97);
            return button;
        }
        public static string GetDate()
        {
            DateTime now = DateTime.Now;
            string dayOfWeek = now.ToString("dddd", new CultureInfo("fr-FR"));
            string dayOfMonth = now.ToString("dd");
            string month = now.ToString("MMMM", new CultureInfo("fr-FR"));
            return $"{dayOfWeek} {dayOfMonth} {month}";

        }
        public static System.Windows.Forms.TextBox TextField(int locationX, int locationY)
        {
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Location = new System.Drawing.Point(locationX, locationY);
            textBox.Size = new System.Drawing.Size(350, 100);
            textBox.Font = new Font(textBox.Font.FontFamily, 15, textBox.Font.Style);

            return textBox;
        }
        public static Form NewUserForm(Color background)
        {
            Form signIn = new Form();
            signIn.Size = new System.Drawing.Size(500, 500);
            signIn.StartPosition = FormStartPosition.CenterScreen;
            signIn.BackColor = background;
            signIn.MaximumSize = new System.Drawing.Size(500, 500);
            signIn.MinimumSize = new System.Drawing.Size(500, 500);

            return signIn;

        }
        public static void ItemsAddUser(Form signIn, System.Windows.Forms.TextBox name, System.Windows.Forms.TextBox firstName, System.Windows.Forms.RadioButton radioButton1, System.Windows.Forms.RadioButton radioButton2, System.Windows.Forms.GroupBox groupBox = null)
        {
            Image imageOriginale = Image.FromFile("img/add.png");

            int nouvelleLargeur = 100;
            int nouvelleHauteur = 100;

            Image imageReduite = imageOriginale.GetThumbnailImage(nouvelleLargeur, nouvelleHauteur, null, IntPtr.Zero);

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(185, 30);
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = imageReduite;
            signIn.Controls.Add(pictureBox1);
        }
        public static Form NewLittleForm(Color Background, Color Foreground, string text)
        {
            Form form = new Form();
            form.BackColor = Background;
            form.ForeColor = Foreground;
            form.Size = new Size(400, 300);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = text;

            return form;
        }
        public static void PersonnePageStyle(Personnes personne, Form form)
        {
            Image imageReduite = null;
            if (personne.genre == true)
            {
                Image imageOriginale = Image.FromFile("img/ppmen.png");

                int nouvelleLargeur = 100;
                int nouvelleHauteur = 100;

                imageReduite = imageOriginale.GetThumbnailImage(nouvelleLargeur, nouvelleHauteur, null, IntPtr.Zero);
            }
            else
            {
                Image imageOriginale = Image.FromFile("img/ppwomen.png");

                int nouvelleLargeur = 100;
                int nouvelleHauteur = 100;

                imageReduite = imageOriginale.GetThumbnailImage(nouvelleLargeur, nouvelleHauteur, null, IntPtr.Zero);
            }

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(423, 50);
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = imageReduite;
            form.Controls.Add(pictureBox1);

            //Print Names
            Label labelName = LabelForPersonnePage(22, personne.name, 375, 180);
            Label labelFirstName = LabelForPersonnePage(20, personne.firstName, 375, 220);
            form.Controls.Add(labelFirstName);
            form.Controls.Add(labelName);


            //ComboBox ...
            /*
            System.Windows.Forms.ComboBox Years = ComboBoxYears();
            form.Controls.Add(Years);

            System.Windows.Forms.ComboBox Month = ComboBoxMonth();
            form.Controls.Add(Month);

            System.Windows.Forms.ComboBox Days = ComboBoxDays();
            form.Controls.Add(Days);*/

        }
        public static System.Windows.Forms.ComboBox ComboBoxMonth()
        {
            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
            comboBox.Location = new System.Drawing.Point(190, 100);
            comboBox.Size = new System.Drawing.Size(160, 40);
            comboBox.BackColor = Color.FromArgb(24, 30, 42);
            comboBox.ForeColor = Color.FromArgb(166, 154, 121);
            comboBox.Font = new Font("Arial", 15, FontStyle.Bold);

            string[] monthNames = new string[]
            {
                "Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin",
                "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"
            };




            comboBox.DataSource = monthNames;

            return comboBox;


        }
        public static System.Windows.Forms.ComboBox ComboBoxYears()
        {
            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
            comboBox.Location = new System.Drawing.Point(200, 100);
            comboBox.Size = new System.Drawing.Size(100, 40);
            comboBox.BackColor = Color.FromArgb(24, 30, 42);
            comboBox.ForeColor = Color.FromArgb(166, 154, 121);
            List<int> yearList = new List<int>();
            comboBox.Font = new Font("Arial", 15, FontStyle.Bold);

            int startYear = 2023;
            int endYear = 2049;

            for (int year = startYear; year <= endYear; year++)
            {
                yearList.Add(year);
            }

            comboBox.DataSource = yearList;
            comboBox.SelectedValue = DateTime.Now.Year;
            return comboBox;
        }
        public static System.Windows.Forms.ComboBox ComboBoxDays()
        {
            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
            comboBox.Location = new System.Drawing.Point(500, 330);
            comboBox.Size = new System.Drawing.Size(100, 40);
            comboBox.BackColor = Color.FromArgb(24, 30, 42);
            comboBox.ForeColor = Color.FromArgb(166, 154, 121);
            List<int> yearList = new List<int>();
            comboBox.Font = new Font("Arial", 17, FontStyle.Bold);

            var Days = new List<int>();

            for (int i = 1; i < 31; i++)
            {
                Days.Add(i);
            }

            comboBox.DataSource = Days;
            return comboBox;
        }






        public static Label LabelForPersonnePage(int fontSize, string contain, int locationX, int locationY)
        {
            Label label = new Label();
            label.BackColor = Color.FromArgb(24, 30, 42);
            label.ForeColor = Color.FromArgb(166, 154, 121);
            label.Size = new Size(200, 40);
            label.Text = contain;
            label.Font = new Font("Arial", fontSize, FontStyle.Bold);
            label.Location = new Point(locationX, locationY);
            label.TextAlign = ContentAlignment.MiddleCenter;
            return label;
        }
    }
    public static class ScreenSetings
    {
        public static int GetWidthScreen(Form form)
        {
            return form.ClientSize.Width;
        }
        public static int GetHeightScreen(Form form)
        {
            return form.ClientSize.Height;
        }

    }
    public class Personnes
    {
        public string name;
        public string firstName;
        public bool genre;
        public int id;
        public Dictionary<DateTime, DateTime> eventsDictionary;

        public Personnes(string name, string firstName, bool genre, int id, List<DateTime> dates = null)
        {
            this.name = name;
            this.firstName = firstName;
            this.genre = genre;
            this.id = id;
            this.eventsDictionary = eventsDictionary;
        }
        public string AfficherNames()
        {
            return name.ToUpper() + " " + firstName.Substring(0, 1).ToUpper() + firstName.Substring(1);
        }
        public static int SetIdPersonne(List<Personnes> allOther)
        {
            int idTemp = 1;
            if (allOther.Count != 0)
            {
                while (true)
                {
                    foreach (Personnes person in allOther)
                    {
                        if (idTemp == person.id)
                        {
                            idTemp = idTemp + 1;
                        }
                        else
                        {
                            return idTemp;
                        }
                    }
                }
            }
            else
            {
                return idTemp;
            }
        }
        public static Personnes CheckById(List<Personnes> personnes, int buttonTag)
        {
            foreach (Personnes person in personnes)
            {
                if (person.id == buttonTag)
                {
                    return person;
                }
            }
            Personnes Erreur = new Personnes("ERREUR", "ERREUR", true, 0);
            return Erreur;
        }
    }
       
    class GetListPersonnes
    {
        public static List<Personnes> GetListPersonneFromJson()
        {
            
            string json = ImportJsonFromFile.GetJsonFromFile();
            if (!String.IsNullOrEmpty(json))
            {
                List<Personnes> Personnes = JsonConvert.DeserializeObject<List<Personnes>>(json);
                return Personnes;
            }
            else
            {
                List<Personnes> Personnes = new List<Personnes>();
                return Personnes;
            }
            

        }
    }
    public class Calendar
    {

        public static void CreateDefaultCalendar(MonthCalendar calendar)
        {
            calendar.MinDate = new DateTime(2023, 1, 1);
            calendar.MaxDate = new DateTime(2100, 12, 31);
            calendar.Dock = DockStyle.Fill;
        }
    }
    public class DateAndTime
    {
        public DateTime DateTimeValue { get; set; }

        public override string ToString()
        {
            return DateTimeValue.ToString("yyyy-MM-dd HH:mm");
        }
    }
}