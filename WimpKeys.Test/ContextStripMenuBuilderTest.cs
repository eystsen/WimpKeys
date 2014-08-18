using System.Windows.Forms;
using NUnit.Framework;

namespace WimpKeys
{
    [TestFixture]
    public class ContextStripMenuBuilderTest
    {

        [Test]
        public void Create_ContextMenuItems_ShouldBeAtLeastOne()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStripBuilder().Create(new ContextMenuStrip());

            CollectionAssert.IsNotEmpty(contextMenuStrip.Items);
        }


        [Test]
        public void Create_DefaultTitle_ShouldSetTitle()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStripBuilder().Create(new ContextMenuStrip());

            Assert.IsNotNullOrEmpty(contextMenuStrip.Items[0].Text);
        }

    }
}