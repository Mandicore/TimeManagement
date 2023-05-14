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
            textBox.Size = new System.Drawing.Size(200, 20);

            return textBox;
        }
        public static Form NewUserForm(Color background)
        {
            Form SignIn = new Form();
            SignIn.Size = new System.Drawing.Size(500, 500);
            SignIn.StartPosition = FormStartPosition.CenterScreen;
            SignIn.BackColor = background;
            SignIn.MaximumSize = new System.Drawing.Size(500, 500);
            SignIn.MinimumSize = new System.Drawing.Size(500, 500);
            return SignIn;

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

