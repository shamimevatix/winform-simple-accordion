

namespace WinFormsAccordionDemoApp
{
    public partial class Form1 : Form
    {
        private AccordionControl accordion;
        public Form1()
        {
            InitializeComponent();

            accordion = new AccordionControl();
            panel1.Controls.Add(accordion);

            for (int i = 0; i < 100; i++)
            {
                string accordionTitle = "Title {0}";
                string accordionContent = "Content {0}";
                accordion.AddAccordionItem(string.Format(accordionTitle, i), string.Format(accordionContent, i));
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
