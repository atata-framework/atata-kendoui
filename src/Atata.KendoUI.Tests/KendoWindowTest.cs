using System;
using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoWindowTest : AutoTest
    {
        [Test]
        public void KendoWindow()
        {
            var page = Go.To<WindowPage>();
            var control = page.Undo.ClickAndGo();
            control.WindowContent.Text.Should.Equal("bla bla");
            control.Actions[3].Click();
        }

        [Test]
        public void KendoWindowAjax()
        {
            var page = Go.To<WindowAjaxPage>();
            var control = page.Undo.ClickAndGo();
            control.WindowContent.Text.Should.Equal("bla bla");
            control.Actions[3].Click();
        }

        [Test]
        public void KendoWindowIFrame()
        {
            var page = Go.To<WindowIFramePage>();
            var control = page.Undo.ClickAndGo();
            control.WindowContent.Text.Should.Equal("bla bla");
            control.Actions[3].Click();
        }
    }
}
