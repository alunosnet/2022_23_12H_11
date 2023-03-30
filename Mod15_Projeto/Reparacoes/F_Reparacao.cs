using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod15_Projeto.Reparacoes
{
    public partial class F_Reparacao : Form
    {
        BaseDados bd;
        public F_Reparacao(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
        }

    }
}
