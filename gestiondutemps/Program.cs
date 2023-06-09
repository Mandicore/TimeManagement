using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using Newtonsoft.Json;
using projet_gestion_temps_cse_axe_system;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using Newtonsoft.Json.Linq;

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
            label.Font = new System.Drawing.Font("Arial", 30, FontStyle.Italic);
            label.TextAlign = ContentAlignment.MiddleCenter;

            int LocationX = (15) + (form.ClientSize.Width / 2) - (label.Size.Width / 2);
            int LocationY = (form.ClientSize.Height / 2) - (label.Size.Height / 2);

            label.Location = new Point(LocationX, LocationY);
            label.Anchor = AnchorStyles.None;

            return label;
        }
        public static Label panelTitle(Color Foreground, Color background, string text, int fontSize, Point location, Size size)
        {
            Label label = new Label();
            label.BackColor = background;
            label.ForeColor = Foreground;
            label.Size = size;
            label.Text = text;
            label.Font = new System.Drawing.Font("Arial", fontSize, FontStyle.Bold);
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
        public static Label FormLabel(string text, int locationY)
        {
            Label label = new Label();
            label.Text = text;
            label.Size = new Size(80, 50);
            label.BackColor = Color.FromArgb(24, 30, 42);
            label.ForeColor = Color.FromArgb(166, 154, 121);
            label.Font = new System.Drawing.Font("Arial", 12, FontStyle.Italic);
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
            button.Font = new System.Drawing.Font("Arial", 30, FontStyle.Bold);
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
            button.Font = new System.Drawing.Font("Arial", 18, FontStyle.Bold);
            button.Size = new Size(250, 80);
            button.Location = new Point(20, 100);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Black;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 208, 200, 178);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 116, 108, 97);
            return button;
        }
        public static System.Windows.Forms.Button CreateButtonAdd(Color backColor, Color foreColor, string text, Size size)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = text;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            button.Size = size;
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
            button.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
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
            button.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
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
            textBox.Font = new System.Drawing.Font(textBox.Font.FontFamily, 15, textBox.Font.Style);

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
        public static Label LabelHour(string text, string font, int fontSize, Point location, Size size, Color foreground, Color background)
        {
            Label label = new Label();
            label.Text = text;
            label.Size = size;
            label.BackColor = background;
            label.ForeColor = foreground;
            label.Font = new System.Drawing.Font(font, fontSize, FontStyle.Italic);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = location;
            label.Anchor = AnchorStyles.None;
            return label;

        }
        public static void ItemsAddUser(Form signIn, System.Windows.Forms.TextBox name, System.Windows.Forms.TextBox firstName, System.Windows.Forms.RadioButton radioButton1, System.Windows.Forms.RadioButton radioButton2, System.Windows.Forms.GroupBox groupBox = null)
        {
            System.Drawing.Image imageOriginale = System.Drawing.Image.FromFile("img/add.png");

            int nouvelleLargeur = 100;
            int nouvelleHauteur = 100;

            System.Drawing.Image imageReduite = imageOriginale.GetThumbnailImage(nouvelleLargeur, nouvelleHauteur, null, IntPtr.Zero);

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
        public static Form NewLoadingForm(Color Background, Color Foreground, string text)
        {
            Form form = new Form();
            form.BackColor = Background;
            form.ForeColor = Foreground;
            form.Size = new Size(350, 200);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ControlBox = false;
            form.Text = text;

            return form;
        }
        public static void PersonnePageStyle(Personnes personne, Form form)
        {
            System.Drawing.Image imageReduite = null;
            if (personne.genre == true)
            {
                System.Drawing.Image imageOriginale = System.Drawing.Image.FromFile("img/ppmen.png");

                int nouvelleLargeur = 100;
                int nouvelleHauteur = 100;

                imageReduite = imageOriginale.GetThumbnailImage(nouvelleLargeur, nouvelleHauteur, null, IntPtr.Zero);
            }
            else
            {
                System.Drawing.Image imageOriginale = System.Drawing.Image.FromFile("img/ppwomen.png");

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

        }
        public static System.Windows.Forms.ComboBox ComboBoxMonth()
        {
            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
            comboBox.Location = new System.Drawing.Point(190, 100);
            comboBox.Size = new System.Drawing.Size(160, 40);
            comboBox.BackColor = Color.FromArgb(24, 30, 42);
            comboBox.ForeColor = Color.FromArgb(166, 154, 121);
            comboBox.Font = new System.Drawing.Font("Arial", 15, FontStyle.Bold);

            string[] monthNames = new string[]
            {
                "Janvier", "F�vrier", "Mars", "Avril", "Mai", "Juin",
                "Juillet", "Ao�t", "Septembre", "Octobre", "Novembre", "D�cembre"
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
            comboBox.Font = new System.Drawing.Font("Arial", 15, FontStyle.Bold);

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
        public static System.Windows.Forms.ComboBox ComboBoxDays(int nbDays, Size size, Point location, int fontsize)
        {
            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
            comboBox.Location = location;
            comboBox.Size = size;
            comboBox.BackColor = Color.FromArgb(24, 30, 42);
            comboBox.ForeColor = Color.FromArgb(166, 154, 121);
            List<int> yearList = new List<int>();
            comboBox.Font = new System.Drawing.Font("Arial", fontsize, FontStyle.Bold);

            var Days = new List<int>();

            for (int i = 1; i < nbDays; i++)
            {
                Days.Add(i);
            }

            comboBox.DataSource = Days;
            return comboBox;
        }
        public static System.Windows.Forms.ComboBox ComboBoxChoiseYear(Size size, Point location, int fontsize, List<int> yearsUsed)
        {
            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
            comboBox.Location = location;
            comboBox.Size = size;
            comboBox.BackColor = Color.FromArgb(24, 30, 42);
            comboBox.ForeColor = Color.FromArgb(166, 154, 121);
            List<int> yearList = new List<int>();
            comboBox.Font = new System.Drawing.Font("Arial", fontsize, FontStyle.Bold);

            var Years = new List<int>();

            foreach (int year in yearsUsed)
            {
                Years.Add(year);
            }

            comboBox.DataSource = Years;
            return comboBox;
        }






        public static Label LabelForPersonnePage(int fontSize, string contain, int locationX, int locationY)
        {
            Label label = new Label();
            label.BackColor = Color.FromArgb(24, 30, 42);
            label.ForeColor = Color.FromArgb(166, 154, 121);
            label.Size = new Size(200, 40);
            label.Text = contain;
            label.Font = new System.Drawing.Font("Arial", fontSize, FontStyle.Bold);
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
        public Dictionary<DateTime, int> eventsDictionary;

        public Personnes(string name, string firstName, bool genre, int id, List<DateTime> dates = null)
        {
            this.name = name;
            this.firstName = firstName;
            this.genre = genre;
            this.id = id;
            eventsDictionary = new Dictionary<DateTime, int>();
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
    class TimeManagement
    {
        public static int hourOnThisMonth(Personnes personne)
        {
            DateTime dateActuelle = DateTime.Now;
            int hourinMonth = personne.eventsDictionary
                .Where(kv => kv.Key.Year == dateActuelle.Year && kv.Key.Month == dateActuelle.Month)
                .Sum(kv => kv.Value);

            return hourinMonth;
        }
        public static int hourOnThisYear(Personnes personne)
        {
            DateTime dateActuelle = DateTime.Now;
            int hourinMonth = personne.eventsDictionary
                .Where(kv => kv.Key.Year == dateActuelle.Year)
                .Sum(kv => kv.Value);

            return hourinMonth;
        }
        public static int hourByMonth(Dictionary<DateTime, int> dictionary, int month)
        {
            int sum = dictionary
                .Where(kv => kv.Key.Month == month)
                .Sum(kv => kv.Value);

            return sum;
        }
        public static List<int> GetDistinctYears(Dictionary<DateTime, int> dictionary)
        {
            List<int> distinctYears = new List<int>();

            foreach (DateTime date in dictionary.Keys)
            {
                int year = date.Year;

                if (!distinctYears.Contains(year))
                {
                    distinctYears.Add(year);
                }
            }

            return distinctYears;
        }
        public static Dictionary<DateTime, int> FilterDictionaryByYear(Dictionary<DateTime, int> dictionary, int year)
        {
            Dictionary<DateTime, int> filteredDictionary = new Dictionary<DateTime, int>();

            foreach (var kvp in dictionary)
            {
                if (kvp.Key.Year == year)
                {
                    filteredDictionary.Add(kvp.Key, kvp.Value);
                }
            }

            return filteredDictionary;
        }
        public static Dictionary<DateTime, int> FilterDictionaryMonth(Dictionary<DateTime, int> dictionary, int month)
        {
            Dictionary<DateTime, int> filteredDictionary = new Dictionary<DateTime, int>();

            foreach (var kvp in dictionary)
            {
                if (kvp.Key.Month == month)
                {
                    filteredDictionary.Add(kvp.Key, kvp.Value);
                }
            }

            return filteredDictionary;
        }
    }
    class PDF
    {
        public static void CreatePDF(int year, Dictionary<DateTime, int> dictionary, int allTotal, string name)
        {
            string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string pdfFilePath = Path.Combine(downloadFolderPath, "R�capitulatif " + name + " " + year + ".pdf");

            var january = TimeManagement.FilterDictionaryMonth(dictionary, 1);
            var totaljanuary = TimeManagement.hourByMonth(dictionary, 1);

            var february = TimeManagement.FilterDictionaryMonth(dictionary, 2);
            var totalfebruary = TimeManagement.hourByMonth(dictionary, 2);

            var march = TimeManagement.FilterDictionaryMonth(dictionary, 3);
            var totalmarch = TimeManagement.hourByMonth(dictionary, 3);

            var april = TimeManagement.FilterDictionaryMonth(dictionary, 4);
            var totalapril = TimeManagement.hourByMonth(dictionary, 4);

            var may = TimeManagement.FilterDictionaryMonth(dictionary, 5);
            var totalmay = TimeManagement.hourByMonth(dictionary, 5);

            var june = TimeManagement.FilterDictionaryMonth(dictionary, 6);
            var totaljune = TimeManagement.hourByMonth(dictionary, 6);

            var jully = TimeManagement.FilterDictionaryMonth(dictionary, 7);
            var totaljully = TimeManagement.hourByMonth(dictionary, 7);

            var august = TimeManagement.FilterDictionaryMonth(dictionary, 8);
            var totalaugust = TimeManagement.hourByMonth(dictionary, 8);

            var september = TimeManagement.FilterDictionaryMonth(dictionary, 9);
            var totalseptember = TimeManagement.hourByMonth(dictionary, 9);

            var october = TimeManagement.FilterDictionaryMonth(dictionary, 10);
            var totaloctober = TimeManagement.hourByMonth(dictionary, 10);

            var november = TimeManagement.FilterDictionaryMonth(dictionary, 11);
            var totalnovember = TimeManagement.hourByMonth(dictionary, 11);

            var december = TimeManagement.FilterDictionaryMonth(dictionary, 12);
            var totaldecember = TimeManagement.hourByMonth(dictionary, 12);

            Document document = new Document();

            //Def Fonts
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 22, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font secondTitleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font informationsFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
            iTextSharp.text.Font explainFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
            iTextSharp.text.Font endFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);


            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
            document.Open();

            Paragraph start = new Paragraph("PDF g�n�r� automatique par l'application TimeManagement cr�� par FIGUEIRAS Jossua en 2023", endFont);
            start.Alignment = Element.ALIGN_RIGHT;
            start.SpacingBefore = 0f;
            start.SpacingAfter = 5f;
            document.Add(start);

            Paragraph title = new Paragraph("R�capitulatif de l'ann�e " + year, titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 40f;
            document.Add(title);

            Paragraph printName = new Paragraph(name, secondTitleFont);
            printName.Alignment = Element.ALIGN_LEFT;
            printName.SpacingAfter = 40f;
            document.Add(printName);

            if (january.Count != 0)
            {
                Paragraph janvier = new Paragraph("Janvier : Total " + totaljanuary + " heures", secondTitleFont);
                janvier.SpacingAfter = 10f;
                document.Add(janvier);

                foreach (KeyValuePair<DateTime, int> kvp in january)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (february.Count != 0)
            {
                Paragraph fevrier = new Paragraph("F�vrier : Total " + totalfebruary + " heures", secondTitleFont);
                fevrier.SpacingAfter = 10f;
                document.Add(fevrier);

                foreach (KeyValuePair<DateTime, int> kvp in february)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (march.Count != 0)
            {
                Paragraph mars = new Paragraph("mars : Total " + totalmarch + " heures", secondTitleFont);
                mars.SpacingAfter = 15f;
                document.Add(mars);

                foreach (KeyValuePair<DateTime, int> kvp in march)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (april.Count != 0)
            {
                Paragraph avril = new Paragraph("avril : Total " + totalapril + " heures", secondTitleFont);
                avril.SpacingAfter = 15f;
                document.Add(avril);

                foreach (KeyValuePair<DateTime, int> kvp in april)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (may.Count != 0)
            {
                Paragraph mai = new Paragraph("mai  Total : " + totalmay + " heures", secondTitleFont);
                mai.SpacingAfter = 15f;
                document.Add(mai);

                foreach (KeyValuePair<DateTime, int> kvp in may)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (june.Count != 0)
            {
                Paragraph juin = new Paragraph("juin : Total " + totaljune + " heures", secondTitleFont);
                juin.SpacingAfter = 15f;
                document.Add(juin);

                foreach (KeyValuePair<DateTime, int> kvp in june)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (jully.Count != 0)
            {
                Paragraph juillet = new Paragraph("juillet : Total " + totaljully + " heures", secondTitleFont);
                juillet.SpacingAfter = 15f;
                document.Add(juillet);

                foreach (KeyValuePair<DateTime, int> kvp in jully)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (august.Count != 0)
            {
                Paragraph aout = new Paragraph("ao�t : Total " + totalaugust + " heures", secondTitleFont);
                aout.SpacingAfter = 15f;
                document.Add(aout);

                foreach (KeyValuePair<DateTime, int> kvp in august)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (september.Count != 0)
            {
                Paragraph septembre = new Paragraph("Septembre : Total " + totalseptember + " heures", secondTitleFont);
                septembre.SpacingAfter = 15f;
                document.Add(septembre);

                foreach (KeyValuePair<DateTime, int> kvp in september)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (october.Count != 0)
            {
                Paragraph octobre = new Paragraph("Octobre : Total " + totaloctober + " heures", secondTitleFont);
                octobre.SpacingAfter = 15f;
                document.Add(octobre);

                foreach (KeyValuePair<DateTime, int> kvp in october)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (november.Count != 0)
            {
                Paragraph novembre = new Paragraph("Novembre : Total " + totalnovember + " heures", secondTitleFont);
                novembre.SpacingAfter = 15f;
                document.Add(novembre);

                foreach (KeyValuePair<DateTime, int> kvp in november)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }
            if (december.Count != 0)
            {
                Paragraph decembre = new Paragraph("D�cembre : Total " + totaldecember + " heures", secondTitleFont);
                decembre.SpacingAfter = 15f;
                document.Add(decembre);

                foreach (KeyValuePair<DateTime, int> kvp in december)
                {
                    Paragraph infos = new Paragraph("D�but : " + kvp.Key.ToString("dddd d MMMM yyyy HH:mm") + " Fin : " + kvp.Key.AddHours(kvp.Value).ToString("dddd d MMMM yyyy HH:mm") + "\nTotal heure : " + kvp.Value, informationsFont);
                    infos.SpacingAfter = 5f;
                    document.Add(infos);
                }
            }

            Paragraph total = new Paragraph("Total sur l'ann�e " + year + " : " + allTotal + " " + "heures", secondTitleFont);
            total.SpacingAfter = 15f;
            document.Add(total);

            Paragraph end = new Paragraph("PDF g�n�r� automatique par l'application TimeManagement cr�� par FIGUEIRAS Jossua en 2023", endFont);
            end.Alignment = Element.ALIGN_RIGHT;
            end.SpacingBefore = 0f;
            end.SpacingAfter = 5f;
            document.Add(end);

            document.Close();

            ProcessStartInfo startInfo = new ProcessStartInfo(pdfFilePath)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(startInfo);

        }
    }
}