using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAccordionDemoApp
{
    public class AccordionItemV2
    {
        public Panel Panel { get; private set; }
        public Panel HeaderPanel { get; private set; }
        public Label TitleLabel { get; private set; }
        public Button ExpandCollapseButton { get; private set; }
        public Button EditButton { get; private set; }
        public Button DeleteButton { get; private set; }
        public Panel ContentPanel { get; private set; }

        private int collapsedHeight = 40;
        private int expandedHeight = 150;
        public bool IsExpanded { get; private set; } = false;

        private Image expandIcon = Properties.Resources.ic_arrow_right;
        private Image collapseIcon = Properties.Resources.ic_arrow_down;

        public AccordionItemV2(string title, string content)
        {
            //Panel = new Panel { Width = 600, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };

            Panel = new Panel
            {
                Width = 350,
                Height = collapsedHeight,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            HeaderPanel = new Panel { Height = 40, Dock = DockStyle.Top, BackColor = Color.LightSteelBlue, Padding = new Padding(5), AutoSize = true };

            TitleLabel = new Label
            {
                Text = title,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            ExpandCollapseButton = new Button
            {
                Image = expandIcon,
                Size = new Size(32, 32),
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                Margin = new Padding(0)
            };
            ExpandCollapseButton.FlatAppearance.BorderSize = 0;

            EditButton = new Button
            {
                Text = "✎",
                Size = new Size(32, 32),
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                Margin = new Padding(0)
            };
            EditButton.FlatAppearance.BorderSize = 0;

            DeleteButton = new Button
            {
                Text = "🗑",
                Size = new Size(32, 32),
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                Margin = new Padding(0)
            };
            DeleteButton.FlatAppearance.BorderSize = 0;

            HeaderPanel.Controls.Add(ExpandCollapseButton);
            HeaderPanel.Controls.Add(DeleteButton);
            HeaderPanel.Controls.Add(EditButton);
            HeaderPanel.Controls.Add(TitleLabel);

            ContentPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.Red,
                Visible = false
            };

            var contentLabel = new Label
            {
                Text = content,
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            ContentPanel.Controls.Add(contentLabel);

            Panel.Controls.Add(ContentPanel);
            Panel.Controls.Add(HeaderPanel);
            
            

            ExpandCollapseButton.Click += (s, e) => Toggle();
            EditButton.Click += (s, e) => MessageBox.Show($"Edit clicked: {title}");
            DeleteButton.Click += (s, e) => MessageBox.Show($"Delete clicked: {title}");
        }

        public void Toggle()
        {
            Debug.WriteLine("Toggle v2 accordion");
            SetExpanded(!IsExpanded);
            //IsExpanded = !IsExpanded;
            //ContentPanel.Visible = IsExpanded;
            //ExpandCollapseButton.Image = IsExpanded ? collapseIcon : expandIcon;
        }

        public void SetExpanded(bool expanded)
        {
            IsExpanded = expanded;
            ContentPanel.Visible = expanded;
            ExpandCollapseButton.Image = expanded ? collapseIcon : expandIcon;
            Panel.Height = expanded ? expandedHeight : collapsedHeight;

            Debug.WriteLine($"HeaderPanel visible? {HeaderPanel.Visible}");
        }
    }
}
