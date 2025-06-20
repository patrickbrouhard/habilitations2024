using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace habilitations2024.view
{
    public partial class FrmHabilitations : Form
    {
        public FrmHabilitations()
        {
            InitializeComponent();
        }

        private void FrmHabilitations_Load(object sender, EventArgs e)
        {
            string stringConnect = "server=localhost;user=habilitations;database=habilitations;port=3306;password=motdepasseuser;";
        }
    }
}
