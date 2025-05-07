using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace WinFormsAccordionDemoApp
{
    public partial class Form2 : Form
    {
        private Panel mainPanel;
        private FlowLayoutPanel flowAccordionPanel;

        private AccordionControl accordion;
        private AccordionControlV2 accordionV2;
        private int accordionItemCount = 0;

        public Form2()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            flowLayoutPanel1.Controls.Add(CreateAccordionSection(
                "Section 1",
                100,
                new Control[] { new Label { Text = "Content for Section 1", Height = 20 } }
            ));

            flowLayoutPanel1.Controls.Add(CreateAccordionSection(
                "Section 2",
                150,
                new Control[]
                {
                new Label { Text = "Content for Section 2", Height = 20 },
                new TextBox { Text = "Input here", Height = 20 }
                }
            ));

            //AdjustFormHeight();
        }

        private Panel CreateAccordionSection(string headerText, int contentHeight, Control[] contentControls)
        {
            Panel sectionPanel = new Panel
            {
                Width = flowLayoutPanel1.ClientSize.Width - 10,
                AutoSize = true,
                Margin = new Padding(5)
            };

            Button headerButton = new Button
            {
                Text = headerText,
                Dock = DockStyle.Top,
                Height = 30,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGray,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Panel contentPanel = new Panel
            {
                Height = contentHeight,
                Dock = DockStyle.Top,
                Visible = false
            };

            foreach (Control ctrl in contentControls)
            {
                contentPanel.Controls.Add(ctrl);
                ctrl.Dock = DockStyle.Top;
            }

            sectionPanel.Controls.Add(contentPanel);
            sectionPanel.Controls.Add(headerButton);

            headerButton.Click += (s, e) =>
            {
                contentPanel.Visible = !contentPanel.Visible;
                AdjustFormHeight();
            };

            accordionItemCount++;

            return sectionPanel;
        }

        private void AdjustFormHeight()
        {
            int totalHeight = 0;

            foreach (Control section in flowLayoutPanel1.Controls)
            {
                totalHeight += section.Margin.Vertical;
                totalHeight += section.Controls.OfType<Button>().First().Height;
                if (section.Controls.OfType<Panel>().First().Visible)
                {
                    totalHeight += section.Controls.OfType<Panel>().First().Height;
                }
            }

            totalHeight += flowLayoutPanel1.Padding.Vertical + 40;
            int maxHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Height = 500;
            Debug.WriteLine($"Form Height..: {this.Height}");
            Debug.WriteLine($"Form maxHeight: {maxHeight}");
            this.CenterToScreen();
        }

        private void AddIPButton_Click(object sender, EventArgs e)
        {
            AddPanel($"Hello paj {DateTime.UtcNow}");
        }

        private void AddPanel(string labelText)
        {
            Color normalColor = Color.WhiteSmoke;
            Color hoverColor = Color.LightSteelBlue;

            Panel panel = new Panel
            {
                Width = 300,
                Height = 40,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = normalColor,
                Tag = labelText
            };

            Label label = new Label
            {
                Text = labelText,
                AutoSize = true,
                Location = new Point(10, 10)
            };

            PictureBox button = new PictureBox
            {
                Image = Properties.Resources.ic_protect,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(24, 24),
                Location = new Point(panel.Width - 34, 8),
                Cursor = Cursors.Hand,
                Visible = false
            };

            // Timer to delay hiding
            System.Windows.Forms.Timer hoverTimer = new System.Windows.Forms.Timer { Interval = 300 };
            hoverTimer.Tick += (s, e) =>
            {
                if (!panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)))
                {
                    button.Visible = false;
                    panel.BackColor = normalColor;
                    hoverTimer.Stop();
                }
            };

            // Show on any enter
            EventHandler onEnter = (s, e) =>
            {
                button.Visible = true;
                panel.BackColor = hoverColor;
                hoverTimer.Stop();
            };

            // Delay hide on leave
            EventHandler onLeave = (s, e) =>
            {
                hoverTimer.Start();
            };

            panel.MouseEnter += onEnter;
            panel.MouseLeave += onLeave;
            label.MouseEnter += onEnter;
            label.MouseLeave += onLeave;
            button.MouseEnter += onEnter;
            button.MouseLeave += onLeave;

            // Button click event
            button.Click += (s, e) =>
            {
                MessageBox.Show($"Clicked: {labelText}");
            };

            panel.Controls.Add(label);
            panel.Controls.Add(button);
            flowLayoutPanel1.Controls.Add(panel);
        }

        private void AddPanel2(string labelText)
        {
            // Check if already added
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Panel p && p.Tag?.ToString() == labelText)
                    return; // Already exists
            }

            Panel panel = new Panel();
            panel.Width = 300;
            panel.Height = 40;
            panel.Margin = new Padding(5);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Tag = labelText; // Use tag for identification

            Label label = new Label();
            label.Text = labelText;
            label.AutoSize = true;
            label.Location = new Point(10, 10);

            PictureBox button = new PictureBox();
            button.Image = Properties.Resources.ic_protect; // Your image resource
            button.SizeMode = PictureBoxSizeMode.Zoom;
            button.Size = new Size(24, 24);
            button.Location = new Point(panel.Width - 34, 8);
            button.Visible = false;
            button.Cursor = Cursors.Hand;

            // Hover logic
            panel.MouseEnter += (s, e) => button.Visible = true;
            panel.MouseLeave += (s, e) => button.Visible = false;
            label.MouseEnter += (s, e) => button.Visible = true;
            label.MouseLeave += (s, e) => button.Visible = false;
            button.MouseEnter += (s, e) => button.Visible = true;
            button.MouseLeave += (s, e) => button.Visible = false;

            // Action on click
            button.Click += (s, e) =>
            {
                MessageBox.Show($"Action for: {labelText}");
                // Or: DoSomething(labelText);
            };

            // Optional: Right-click to remove
            panel.ContextMenuStrip = new ContextMenuStrip();
            panel.ContextMenuStrip.Items.Add("Remove", null, (s, e) => RemovePanel(labelText));

            panel.Controls.Add(label);
            panel.Controls.Add(button);
            flowLayoutPanel1.Controls.Add(panel);

            accordionItemCount++;
            AdjustFlowPanelAndFormHeight();
        }

        private void RemovePanel(string labelText)
        {
            Control toRemove = null;

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Panel p && p.Tag?.ToString() == labelText)
                {
                    toRemove = p;
                    break;
                }
            }

            if (toRemove != null)
                flowLayoutPanel1.Controls.Remove(toRemove);

            accordionItemCount--;
            AdjustFlowPanelAndFormHeight();
        }

        private void AdjustFlowPanelAndFormHeight() { 
            if(accordionItemCount > 6)
            {
                this.Height = 500 + ((accordionItemCount - 6) * 50);
            }
            else
            {
                this.Height = 500;
            }
        }
    }
}
