using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoEditorTests : UITestFixture
    {
        private EditorPage page;

        protected override void OnSetUp()
        {
            page = Go.To<EditorPage>();
        }

        [Test]
        public void KendoEditor()
        {
            var control = page.Regular;

            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();
            control.Set("Some value");
            control.Should.Equal("Some value");

            control.Set(null);
            control.Should.BeNull();
        }
    }
}
