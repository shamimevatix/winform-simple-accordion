

using System.Diagnostics;

namespace WinFormsAccordionDemoApp
{
    public partial class Form1 : Form
    {
        private AccordionControl accordion;
        private AccordionControlV2 accordionV2;
        public Form1()
        {
            InitializeComponent();

            accordion = new AccordionControl();
            panel1.Controls.Add(accordion);

            for (int i = 0; i < 10; i++)
            {
                string accordionTitle = "Title {0}";
                string accordionContent = "Content {0}";
                accordion.AddAccordionItem(string.Format(accordionTitle, i), string.Format(accordionContent, i));
            }

            accordionV2 = new AccordionControlV2();
            panel3.Controls.Add(accordionV2);
            for (int i = 11; i < 21; i++)
            {
                string accordionTitle = "VTitle {0}";
                string accordionContent = "VContent {0}";
                accordionV2.AddAccordionItem(string.Format(accordionTitle, i), string.Format(accordionContent, i));
                Debug.WriteLine("Adding accordion V2 item {0}", i);
            }


            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
