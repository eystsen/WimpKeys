using System.Windows.Forms;
using FakeItEasy;

namespace WimpKeys
{
    public class ContextMenuStripBuilder
    {
        private ContextMenuStrip _contextmenu;

        public ContextMenuStrip Create(ContextMenuStrip contextmenu)
        {
            _contextmenu = contextmenu;
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += (sender, args) =>
            {
                Application.Exit();
            };
            _contextmenu.Items.Add(item);

            return _contextmenu;
        }
    }
}