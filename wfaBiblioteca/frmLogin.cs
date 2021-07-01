using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bll;

namespace wfaBiblioteca
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            if(txtLogin.Text=="" || txtSenha.Text == "")
            {
                timer1.Enabled = true;
                lblMensagem.Visible = true;
            }
            else
            {
                appdataTableAdapters.funcionariosTableAdapter user = new appdataTableAdapters.funcionariosTableAdapter();
                appdata.funcionariosDataTable dt = user.GetDataByLoginSenha(txtLogin.Text, txtSenha.Text);
                if (dt.Rows.Count > 0)
                {
                    txtLogin.Text = "";
                    txtSenha.Text = "";
                    lblMensagem.Visible = false;
                    Form objUsuarios = new frmUsuarios();
                    objUsuarios.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Login inválido, verifique o nome de funcionário e a senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMensagem.ForeColor = lblMensagem.ForeColor == Color.Red ? Color.White : Color.Red;
            timer1.Interval = 2000;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja fechar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
