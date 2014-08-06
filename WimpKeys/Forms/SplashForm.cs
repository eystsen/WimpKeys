using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WimpKeys
{
    public interface ISplashForm
    {
        void Hide();
        void Show();
        void Update();
    }

    public partial class SplashForm : Form, ISplashForm
    {
        public SplashForm()
        {
            InitializeComponent();
        }
    }
}
