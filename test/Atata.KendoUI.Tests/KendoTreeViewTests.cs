namespace Atata.KendoUI.Tests;

public class KendoTreeViewTests : UITestSuite
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<TreeViewPage>(library).Regular;

        control.Children.Count.Should.Be(1);
        control.Descendants.Count.Should.Be(14);
        control[0].Children.Count.Should.Be(6);
        control[0][1].Children.Count.Should.Be(2);
        control[0][1].Descendants.Count.Should.Be(4);

        control[0][1][1].Children.Should.BeEmpty();

        control[0][0].Text.Should.Be("images");
        control[0][1].Text.Should.Be("resources");
        control[0][1][0].Parent.Text.Should.Be("resources");

        control.Descendants[x => x.Text == "resources"].Click();
        control[0][1].IsSelected.Should.BeTrue();
        control[0][1].IsFocused.Should.BeTrue();
        control[0][1].IsEnabled.Should.BeTrue();
    }

    [TestCaseSources.JQuery]
    public void Toggle(string library)
    {
        var control = GoToTestPage<TreeViewPage>(library).Regular;

        TestToggle(control);
    }

    [TestCaseSources.JQuery]
    public void Toggle_SlowAnimation(string library)
    {
        var control = GoToTestPage<TreeViewPage>(library).SlowAnimating;

        TestToggle(control);
    }

    private static void TestToggle(KendoTreeView<TreeViewPage> control)
    {
        control[0][0].Collapse();
        control[0][1][0].Collapse();
        control[0][1].Collapse();
        control[0].Toggle();
        control[0][1][0][1].Text.Should.Be("prices.pdf");
        control[0][1][0][1].Should.BePresent();
        control[0][1][0][1].Should.BeHidden();
        control[0][1][0][1].Select();
        control.Descendants[x => x.Text == "prices.pdf"].IsSelected.Should.BeTrue();
        control.Descendants[x => x.Text == "prices.pdf"].IsFocused.Should.BeTrue();
        control.Descendants[x => x.Text == "prices.pdf"].Parent.IsExpanded.Should.BeTrue();
    }

    [TestCaseSources.JQuery]
    public void DragAndDrop(string library)
    {
        var control = GoToTestPage<TreeViewPage>(library).Regular;

        control.Descendants[x => x.Text == "prices.pdf"].Text.DragAndDropTo(control.Descendants[x => x.Text == "zip"].Text);

        control.Descendants[x => x.Text == "pdf"].Children.SelectData(x => x.Text).Should.EqualSequence("brochure.pdf");
        control.Descendants[x => x.Text == "zip"].Children.SelectData(x => x.Text).Should.EqualSequence("prices.pdf");

        control.Descendants[x => x.Text == "brochure.pdf"].Text.DragAndDropTo(control.Descendants[x => x.Text == "zip"].Text);

        control.Descendants[x => x.Text == "pdf"].Children.Should.BeEmpty();
        control.Descendants[x => x.Text == "zip"].Children.SelectData(x => x.Text).Should.EqualSequence("prices.pdf", "brochure.pdf");
    }

    [TestCaseSources.JQuery]
    public void Interact_WithCheckBoxes(string library)
    {
        var control = GoToTestPage<TreeViewPage>(library).WithCheckboxes;

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

    [TestCaseSources.JQuery]
    public void CustomTemplate(string library)
    {
        var control = GoToTestPage<TreeViewPage>(library).WithCustomTemplate;

        control[0].Text.Should.Be("My Documents");

        control.Descendants[x => x.Text == "index.html"].Should.BeVisible();
        control.Descendants[x => x.Text == "index.html"].Remove.Click();
        control.Descendants[x => x.Text == "index.html"].Should.Not.BePresent();
    }
}
