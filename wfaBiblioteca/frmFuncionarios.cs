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
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
        }


        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            dtpNasc.Format = DateTimePickerFormat.Custom;
            dtpNasc.CustomFormat = "dd/MM/yyyy";

            CamadaNegocios func = new CamadaNegocios();


            /*mostrar tabela*/
            DataSet exibir = new DataSet();
            exibir = func.obtemFuncionarios();
            dgvFunc.DataSource = exibir.Tables[0];
            dgvConsulta.DataSource = exibir.Tables[0];


        }

        private void rbtCadastro_CheckedChanged(object sender, EventArgs e)
        {
            btnAcao.Text = "Cadastrar";
            txtNome.Enabled = true;
            txtTel.Enabled = true;
            txtEnd.Enabled = true;
            txtLogin.Enabled = true;
            dtpNasc.Enabled = true;
        }

        private void rbtAtualizar_CheckedChanged(object sender, EventArgs e)
        {
            btnAcao.Text = "Atualizar";
            txtNome.Enabled = true;
            txtTel.Enabled = true;
            txtEnd.Enabled = true;
            txtLogin.Enabled = true;
            dtpNasc.Enabled = true;
        }

        private void rbtDeleta_CheckedChanged(object sender, EventArgs e)
        {
            btnAcao.Text = "Deletar";

            txtNome.Enabled = false;
            txtTel.Enabled = false;
            txtEnd.Enabled = false;
            txtLogin.Enabled = false;
            dtpNasc.Enabled = false;
        }

        private void btnAcao_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                EP.SetError(txtID, "Por favor inserir o código do funcionário");
            else if (txtNome.Text == "" && (rbtCadastro.Checked || rbtAtualizar.Checked))
                EP.SetError(txtNome, "Por favor inserir o nome do funcionário");
            else if (txtTel.Text == "" && (rbtCadastro.Checked || rbtAtualizar.Checked))
                EP.SetError(txtTel, "Por favor inserir o telefone do funcionário");
            else if(txtEnd.Text == "" && (rbtCadastro.Checked || rbtAtualizar.Checked))
                EP.SetError(txtEnd, "Por favor inserir o endereço do funcionário");
            else if(txtLogin.Text == "" && (rbtCadastro.Checked || rbtAtualizar.Checked))
                EP.SetError(txtLogin, "Por favor inserir o login do funcionário");
            else
            {
                try
                {
                    if (rbtCadastro.Checked)
                    {
                        try
                        {
                            CamadaNegocios func = new CamadaNegocios();


                            DataSet cadastra = new DataSet();
                            cadastra = func.inserirFuncionario(txtID.Text, txtNome.Text, txtTel.Text, dtpNasc.Text, txtEnd.Text, txtLogin.Text);

                            DataSet exibir = new DataSet();
                            exibir = func.obtemFuncionarios();
                            dgvFunc.DataSource = exibir.Tables[0];
                            dgvConsulta.DataSource = exibir.Tables[0];

                            txtID.Text = "";
                            txtNome.Text = "";
                            txtTel.Text = "";
                            txtEnd.Text = "";
                            txtLogin.Text = "";

                            txtID.Focus();

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Não é possível cadastrar.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else if (rbtAtualizar.Checked)
                    {
                        try
                        {
                            CamadaNegocios func = new CamadaNegocios();

                            DataSet atualiza = new DataSet();
                            atualiza = func.atualizarFuncionario(txtID.Text, txtNome.Text, txtTel.Text, dtpNasc.Text, txtEnd.Text, txtLogin.Text);

                            DataSet exibir = new DataSet();
                            exibir = func.obtemFuncionarios();
                            dgvFunc.DataSource = exibir.Tables[0];
                            dgvConsulta.DataSource = exibir.Tables[0];

                            txtID.Text = "";
                            txtNome.Text = "";
                            txtTel.Text = "";
                            txtEnd.Text = "";
                            txtLogin.Text = "";

                            txtID.Focus();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Não é possível encontrar.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if(rbtDeleta.Checked)
                    {
                        try
                        {
                            CamadaNegocios func = new CamadaNegocios();

                            DataSet deleta = new DataSet();
                            deleta = func.deletaFuncionario(txtID.Text);

                            DataSet exibir = new DataSet();
                            exibir = func.obtemFuncionarios();
                            dgvFunc.DataSource = exibir.Tables[0];
                            dgvConsulta.DataSource = exibir.Tables[0];

                            txtID.Text = "";
                            txtID.Focus();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Funcionário não existente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }




                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }







        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja deslogar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            
            if (txtID_Consulta.Text == "")
            {
                CamadaNegocios func = new CamadaNegocios();
                DataSet exibir = new DataSet();
                exibir = func.obtemFuncionarios();
                dgvFunc.DataSource = exibir.Tables[0];
                MessageBox.Show("Por favor inserir o código do funcionário","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            else if (txtNome_Consulta.Text == "")
            {
                CamadaNegocios func = new CamadaNegocios();
                DataSet exibir = new DataSet();
                exibir = func.obtemFuncionarios();
                dgvFunc.DataSource = exibir.Tables[0];
                MessageBox.Show("Por favor inserir o Nome do funcionário", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
            else
            {
                try
                {
                    CamadaNegocios func = new CamadaNegocios();
                    DataSet pesquisa = new DataSet();
                   pesquisa = func.obtemFuncionarios_Consulta(txtID_Consulta.Text,txtNome_Consulta.Text);


                    dgvConsulta.DataSource = pesquisa.Tables[0];

                    txtID_Consulta.Text = "";
                    txtNome_Consulta.Text = "";


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }














    }
}
