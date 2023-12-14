using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_Users__ : Form
    {
        public Form_Users__(Color color)
        {
            InitializeComponent();
            this.Select();
            BackColor = color;
        }
    }
}
