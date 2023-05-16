using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using projet_gestion_temps_cse_axe_system;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

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
        public static System.Windows.Forms.Button CreateButtonMenu(Color backColor, Color foreColor, string text)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = text;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new Font("Arial", 30, FontStyle.Bold);
            button.Size = new Size(100, 75);
            button.Location = new Point(15, 15);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = backColor; ;
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
            button.Size = new Size(100, 30);
            button.Location = new Point(150, 650);
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

            Label nameTitle = FormLabel("Nom :", 120);
            signIn.Controls.Add(nameTitle);

            System.Windows.Forms.TextBox name = TextField(70, 170);
            signIn.Controls.Add(name);

            Label firstNameLabel = FormLabel("Prénom :", 200);
            signIn.Controls.Add(firstNameLabel);

            System.Windows.Forms.TextBox firstName = TextField(70, 250);
            signIn.Controls.Add(firstName);
                

            System.Windows.Forms.RadioButton radioButton1 = new System.Windows.Forms.RadioButton();
            radioButton1.Text = "Homme";
            radioButton1.ForeColor = Color.FromArgb(166, 154, 121);
            radioButton1.Location = new System.Drawing.Point(20, 20);
            signIn.Controls.Add(radioButton1);

            System.Windows.Forms.RadioButton radioButton2 = new System.Windows.Forms.RadioButton();
            radioButton2.Text = "Femme";
            radioButton2.ForeColor = Color.FromArgb(166, 154, 121);
            radioButton2.Location = new System.Drawing.Point(180, 20);
            signIn.Controls.Add(radioButton2);


            var groupBox = new System.Windows.Forms.GroupBox();
            groupBox.Location = new System.Drawing.Point(70, 300);
            groupBox.Text = "Genre";
            groupBox.ForeColor = Color.FromArgb(166, 154, 121);
            groupBox.Size = new Size(350, 60);
            groupBox.Controls.Add(radioButton1);
            groupBox.Controls.Add(radioButton2);
            signIn.Controls.Add(groupBox);

            /*
            System.Windows.Forms.Button newUser = CreateButtonNewUser(Color.FromArgb(166, 154, 121), background, 180, 400, "Ajouter ...");
            SignIn.Click += new EventHandler(NewPersonne_Click);
            SignIn.Controls.Add(newUser);
            */

            return signIn;

        }
        public static void ItemsAddUser(Form signIn, System.Windows.Forms.TextBox name, System.Windows.Forms.TextBox firstName)
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

            Label nameTitle = FormLabel("Nom :", 120);
            signIn.Controls.Add(nameTitle);

            name = TextField(70, 170);
            signIn.Controls.Add(name);

            Label firstNameLabel = FormLabel("Prénom :", 200);
            signIn.Controls.Add(firstNameLabel);

            firstName = TextField(70, 250);
            signIn.Controls.Add(firstName);


            System.Windows.Forms.RadioButton radioButton1 = new System.Windows.Forms.RadioButton();
            radioButton1.Text = "Homme";
            radioButton1.ForeColor = Color.FromArgb(166, 154, 121);
            radioButton1.Location = new System.Drawing.Point(20, 20);
            signIn.Controls.Add(radioButton1);

            System.Windows.Forms.RadioButton radioButton2 = new System.Windows.Forms.RadioButton();
            radioButton2.Text = "Femme";
            radioButton2.ForeColor = Color.FromArgb(166, 154, 121);
            radioButton2.Location = new System.Drawing.Point(180, 20);
            signIn.Controls.Add(radioButton2);


            var groupBox = new System.Windows.Forms.GroupBox();
            groupBox.Location = new System.Drawing.Point(70, 300);
            groupBox.Text = "Genre";
            groupBox.ForeColor = Color.FromArgb(166, 154, 121);
            groupBox.Size = new Size(350, 60);
            groupBox.Controls.Add(radioButton1);
            groupBox.Controls.Add(radioButton2);
            signIn.Controls.Add(groupBox);
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

        public Personnes(string name, string firstName, bool genre)
        {
            this.name = name;
            this.firstName = firstName;
            this.genre = genre;
        }
        public string AfficherNames()
        {
            return name.ToUpper() + " " + firstName.Substring(0, 1).ToUpper() + firstName.Substring(1);
        }
    }
    class GetListPersonnes
    {
        public static List<Personnes> GetListPersonneFromJson()
        {
            string json = ImportJsonFromFile.GetJsonFromFile();

            List<Personnes> Personnes = JsonConvert.DeserializeObject<List<Personnes>>(json);
            return Personnes;
        }
    }
}

