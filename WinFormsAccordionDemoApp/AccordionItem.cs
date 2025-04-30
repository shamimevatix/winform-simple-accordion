using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAccordionDemoApp
{
    public class AccordionItem
    {
        public Panel Panel { get; private set; }
        public Panel HeaderPanel { get; private set; }
        public Label TitleLabel { get; private set; }
        public Button HeaderButton { get; private set; }
        public PictureBox HeaderIcon { get; private set; }
        public Button ExpandCollapseButton { get; private set; }
        public Button EditButton { get; private set; }
        public Button DeleteButton { get; private set; }
        private Panel ContentPanel;
        private Label ContentLabel;
        private bool isExpanded = false;
        private int collapsedHeight = 40;
        private int expandedHeight = 150;

        private Color headerDefaultColor = Color.FromArgb(50, 50, 70);
        private Color headerHoverColor = Color.FromArgb(70, 70, 90);
        private Color contentBackgroundColor = Color.FromArgb(230, 230, 250);

        // Replace the following line:
        // private Image expandIcon = Properties.Resources.ExpandIcon;

        // With this line:
        private Image expandIcon = Properties.Resources.ic_arrow_right;
        // Replace the following line:  
        // private Image collapseIcon = Properties.Resources.CollapseIcon;  

        // With this line:  
        private Image collapseIcon = Properties.Resources.ic_arrow_down;

        public AccordionItem(string title, string content)
        {
            Panel = new Panel
            {
                Width = 350,
                Height = collapsedHeight,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            HeaderButton = new Button
            {
                Text = "                " + title,
                Dock = DockStyle.Top,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = headerDefaultColor,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Image = expandIcon
            };
            HeaderButton.FlatAppearance.BorderSize = 0;
            HeaderButton.ImageAlign = ContentAlignment.MiddleLeft;

            // Hover effect
            HeaderButton.MouseEnter += (s, e) => HeaderButton.BackColor = headerHoverColor;
            HeaderButton.MouseLeave += (s, e) => HeaderButton.BackColor = headerDefaultColor;

            Panel.Controls.Add(HeaderButton);

            ContentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false,
                BackColor = contentBackgroundColor
            };

            ContentLabel = new Label
            {
                Text = content,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9),
                Padding = new Padding(10)
            };
            ContentPanel.Controls.Add(ContentLabel);

            Panel.Controls.Add(ContentPanel);
        }

        //public AccordionItem(string title, string content)
        //{
        //    Panel = new Panel { Width = 600, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };

        //    HeaderPanel = new Panel { Height = 40, Dock = DockStyle.Top, BackColor = Color.LightSteelBlue };
        //    HeaderPanel.Padding = new Padding(5, 5, 5, 5);
        //    HeaderPanel.AutoSize = true;

        //    TitleLabel = new Label
        //    {
        //        Text = title,
        //        AutoSize = true,
        //        TextAlign = ContentAlignment.MiddleLeft,
        //        Dock = DockStyle.Fill,
        //        Font = new Font("Segoe UI", 10, FontStyle.Bold)
        //    };

        //    ExpandCollapseButton = new Button
        //    {
        //        Image = expandIcon,
        //        Size = new Size(32, 32),
        //        FlatStyle = FlatStyle.Flat,
        //        Dock = DockStyle.Right,
        //        Margin = new Padding(0)
        //    };
        //    ExpandCollapseButton.FlatAppearance.BorderSize = 0;

        //    EditButton = new Button
        //    {
        //        Text = "✎", // or use image
        //        Size = new Size(32, 32),
        //        FlatStyle = FlatStyle.Flat,
        //        Dock = DockStyle.Right,
        //        Margin = new Padding(0)
        //    };
        //    EditButton.FlatAppearance.BorderSize = 0;

        //    DeleteButton = new Button
        //    {
        //        Text = "🗑", // or use image
        //        Size = new Size(32, 32),
        //        FlatStyle = FlatStyle.Flat,
        //        Dock = DockStyle.Right,
        //        Margin = new Padding(0)
        //    };
        //    DeleteButton.FlatAppearance.BorderSize = 0;

        //    // Add buttons right-to-left
        //    HeaderPanel.Controls.Add(ExpandCollapseButton);
        //    HeaderPanel.Controls.Add(DeleteButton);
        //    HeaderPanel.Controls.Add(EditButton);
        //    HeaderPanel.Controls.Add(TitleLabel); // fills remaining space

        //    ContentPanel = new Panel
        //    {
        //        Dock = DockStyle.Top,
        //        Height = 100,
        //        BackColor = Color.White,
        //        Visible = false
        //    };

        //    var contentLabel = new Label
        //    {
        //        Text = content,
        //        Dock = DockStyle.Fill,
        //        Padding = new Padding(10)
        //    };
        //    ContentPanel.Controls.Add(contentLabel);

        //    Panel.Controls.Add(ContentPanel);
        //    Panel.Controls.Add(HeaderPanel);

        //    // Events
        //    ExpandCollapseButton.Click += (s, e) => Toggle();
        //    // You can add:
        //    // EditButton.Click += ...
        //    // DeleteButton.Click += ...
        //}

        public void Toggle()
        {
            SetExpanded(!isExpanded);
        }

        public void SetExpanded(bool expanded)
        {
            isExpanded = expanded;
            ContentPanel.Visible = expanded;
            HeaderButton.Image = expanded ? collapseIcon : expandIcon;
            Panel.Height = expanded ? expandedHeight : collapsedHeight;
        }

        //public void SetExpanded(bool expand)
        //{
        //    isExpanded = expand;
        //    ContentPanel.Visible = expand;
        //    Panel.Height = expand ? expandedHeight : collapsedHeight;
        //    UpdateHeaderIcon();
        //}

        private void UpdateHeaderIcon()
        {
            if (isExpanded)
                HeaderButton.Text = "                " + HeaderButton.Text.Substring(2); // Down arrow
            else
                HeaderButton.Text = "                " + HeaderButton.Text.Substring(2); // Right arrow
        }
    }
}
