using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAccordionDemoApp
{
    public class AccordionControlV2 : UserControl
    {
        private FlowLayoutPanel accordionContainer;
        private List<AccordionItemV2> accordionItems = new List<AccordionItemV2>();

        public AccordionControlV2()
        {
            this.Dock = DockStyle.Fill;

            accordionContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            this.Controls.Add(accordionContainer);
        }

        public void AddAccordionItem(string title, string content)
        {
            var item = new AccordionItemV2(title, content);
            //item.HeaderButton.Click += (s, e) => ToggleAccordion(item);
            accordionItems.Add(item);
            accordionContainer.Controls.Add(item.Panel);
        }

        public void RemoveLastAccordionItem()
        {
            if (accordionItems.Count > 0)
            {
                var lastItem = accordionItems[^1];
                accordionContainer.Controls.Remove(lastItem.Panel);
                accordionItems.Remove(lastItem);
            }
        }

        public void RemoveAccordionItem(int index)
        {
            if (accordionItems.Count > 0)
            {
                var selectedItem = accordionItems[index];
                accordionContainer.Controls.Remove(selectedItem.Panel);
                accordionItems.Remove(selectedItem);
            }
        }

        public void RemoveAllAccordionItem()
        {
            accordionContainer.Controls.Clear();
            accordionItems.Clear();
        }

        private void ToggleAccordion(AccordionItemV2 item)
        {
            foreach (var acc in accordionItems)
            {
                if (acc != item)
                    acc.SetExpanded(false);
            }
            item.Toggle();
        }
    }
}
