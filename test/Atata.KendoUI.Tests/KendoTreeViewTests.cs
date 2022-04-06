﻿using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoTreeViewTests : UITestFixture
    {
        private TreeViewPage page;

        protected override void OnSetUp()
        {
            page = Go.To<TreeViewPage>();
        }

        [Test]
        public void KendoTreeView()
        {
            var control = page.Regular;

            control.Children.Count.Should.Equal(1);
            control.Descendants.Count.Should.Equal(14);
            control[0].Children.Count.Should.Equal(6);
            control[0][1].Children.Count.Should.Equal(2);
            control[0][1].Descendants.Count.Should.Equal(4);

            control[0][1][1].Children.Should.BeEmpty();

            control[0][0].Text.Should.Equal("images");
            control[0][1].Text.Should.Equal("resources");
            control[0][1][0].Parent.Text.Should.Equal("resources");

            control.Descendants[x => x.Text == "resources"].Click();
            control[0][1].IsSelected.Should.BeTrue();
            control[0][1].IsFocused.Should.BeTrue();
            control[0][1].IsEnabled.Should.BeTrue();
        }

        [Test]
        public void KendoTreeView_Toggle()
        {
            var control = page.Regular;

            TestToggle(control);
        }

        [Test]
        public void KendoTreeView_Toggle_SlowAnimation()
        {
            var control = page.SlowAnimating;

            TestToggle(control);
        }

        private static void TestToggle(KendoTreeView<TreeViewPage> control)
        {
            control[0][0].Collapse();
            control[0][1][0].Collapse();
            control[0][1].Collapse();
            control[0].Toggle();
            control[0][1][0][1].Text.Should.Equal("prices.pdf");
            control[0][1][0][1].Should.Exist();
            control[0][1][0][1].Should.BeHidden();
            control[0][1][0][1].Select();
            control.Descendants[x => x.Text == "prices.pdf"].IsSelected.Should.BeTrue();
            control.Descendants[x => x.Text == "prices.pdf"].IsFocused.Should.BeTrue();
            control.Descendants[x => x.Text == "prices.pdf"].Parent.IsExpanded.Should.BeTrue();
        }

        [Test]
        public void KendoTreeView_DragAndDrop()
        {
            var control = page.Regular;

            control.Descendants[x => x.Text == "prices.pdf"].Text.DragAndDropTo(control.Descendants[x => x.Text == "zip"].Text);

            control.Descendants[x => x.Text == "pdf"].Children.SelectData(x => x.Text).Should.EqualSequence("brochure.pdf");
            control.Descendants[x => x.Text == "zip"].Children.SelectData(x => x.Text).Should.EqualSequence("prices.pdf");

            control.Descendants[x => x.Text == "brochure.pdf"].Text.DragAndDropTo(control.Descendants[x => x.Text == "zip"].Text);

            control.Descendants[x => x.Text == "pdf"].Children.Should.BeEmpty();
            control.Descendants[x => x.Text == "zip"].Children.SelectData(x => x.Text).Should.EqualSequence("prices.pdf", "brochure.pdf");
        }

        [Test]
        public void KendoTreeView_CheckBoxes()
        {
            var control = page.WithCheckboxes;

            control.Descendants[x => x.Text == "March.pdf"].Check();
            control.Descendants[x => x.Text == "March.pdf"].IsChecked.Should.BeTrue();
            control.Descendants[x => x.Text == "March.pdf"].Uncheck();
            control.Descendants[x => x.Text == "March.pdf"].IsChecked.Should.BeFalse();

            control[0].Collapse();

            var folderItem = control[0][0];

            foreach (var item in folderItem.Children)
                item.IsChecked.Should.BeFalse();

            folderItem.Check();
            folderItem.IsChecked.Should.BeTrue();
            folderItem.IsExpanded.Should.BeTrue();

            foreach (var item in folderItem.Children)
                item.IsChecked.Should.BeTrue();
        }

        [Test]
        public void KendoTreeView_CustomTemplate()
        {
            var control = page.WithCustomTemplate;

            control[0].Text.Should.Equal("My Documents");

            control.Descendants[x => x.Text == "index.html"].Should.BeVisible();
            control.Descendants[x => x.Text == "index.html"].Remove.Click();
            control.Descendants[x => x.Text == "index.html"].Should.Not.Exist();
        }
    }
}
