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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();

            dtpIni.Enabled = false;
            dtpFim.Enabled = false;

            dtpIni.Value = DateTime.Now;
            dtpFim.Value = dtpFim.Value.AddDays(7);
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CamadaNegocios usuarios = new CamadaNegocios();

            DataSet oDa = new DataSet();
            oDa = usuarios.obtemUsuarios();

            DataSet oDa2 = new DataSet();
            oDa2 = usuarios.obtemExemplares();

            DataSet oDa3 = new DataSet();
            oDa3 = usuarios.obtemEmprestimos();

            DataSet oDa4 = new DataSet();
            oDa4 = usuarios.obtemDev();

            dgvConsulta.DataSource = oDa.Tables[0];
            dgvConsulta.Columns[0].HeaderText = "ID";
            dgvConsulta.Columns[1].HeaderText = "Nome";
            dgvConsulta.Columns[2].HeaderText = "Email";
            dgvConsulta.Columns[3].HeaderText = "Celular";
            dgvConsulta.Columns[4].HeaderText = "Curso";
            dgvConsulta.Columns[5].HeaderText = "Categoria";

            dgvCadastro.DataSource = oDa.Tables[0];
            dgvCadastro.Columns[0].HeaderText = "ID";
            dgvCadastro.Columns[1].HeaderText = "Nome";
            dgvCadastro.Columns[2].HeaderText = "Email";
            dgvCadastro.Columns[3].HeaderText = "Celular";
            dgvCadastro.Columns[4].HeaderText = "Curso";
            dgvCadastro.Columns[5].HeaderText = "Categoria";

            dgvDeleta.DataSource = oDa.Tables[0];
            dgvDeleta.Columns[0].HeaderText = "ID";
            dgvDeleta.Columns[1].HeaderText = "Nome";
            dgvDeleta.Columns[2].HeaderText = "Email";
            dgvDeleta.Columns[3].HeaderText = "Celular";
            dgvDeleta.Columns[4].HeaderText = "Curso";
            dgvDeleta.Columns[5].HeaderText = "Categoria";

            dgvExemplares.DataSource = oDa2.Tables[0];
            

            dgvHist.DataSource = oDa3.Tables[0];
            dgvHist.Columns[0].HeaderText = "ID do Usuário";
            dgvHist.Columns[1].HeaderText = "ID do livro";
            dgvHist.Columns[2].HeaderText = "Início";
            dgvHist.Columns[3].HeaderText = "Prazo";

            dgvEmp.DataSource = oDa3.Tables[0];
            dgvEmp.Columns[0].HeaderText = "ID Usuário";
            dgvEmp.Columns[1].HeaderText = "ID Livro";
            dgvEmp.Columns[2].HeaderText = "Inicio";
            dgvEmp.Columns[3].HeaderText = "Entrega";

            dgvDev.DataSource = oDa4.Tables[0];
            dgvDev.Columns[0].HeaderText = "ID";
            dgvDev.Columns[1].HeaderText = "Nome";
            dgvDev.Columns[2].HeaderText = "Livro";
            dgvDev.Columns[3].HeaderText = "Entrega";

        }

        public static bool IsEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*==========================================consulta===================================*/

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            CamadaNegocios usuarios = new CamadaNegocios();

            if (txtID_consulta.Text != "" && rbtUsuario_consulta.Checked && txtNome_Comsulta.Text!="")
            {
                try
                {
                    DataSet usuario = new DataSet();
                    usuario = usuarios.ConsultaUsu_ID_Nome(txtID_consulta.Text, txtNome_Comsulta.Text);
                    dgvConsulta.DataSource = usuario.Tables[0];
                    if (usuario.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Usuário não existe.");
                        DataSet oDa = new DataSet();
                        oDa = usuarios.obtemUsuarios();
                        dgvConsulta.DataSource = oDa.Tables[0];
                        EP.Clear();
                    }
                    txtID_consulta.Text = "";
                    txtNome_Comsulta.Text = "";
                    txtID_consulta.Focus();
                    EP.Clear();
                }
                catch
                {
                    MessageBox.Show("Usuário não existe","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }else if(rbtExemplar_consulta.Checked)
            {
                try
                {
                    txtID_consulta.Enabled = false;
                    DataSet exemplares = new DataSet();
                    exemplares = usuarios.ConsultaExe_Nome(txtNome_Comsulta.Text);
                    dgvConsulta.DataSource = exemplares.Tables[0];
                    if (exemplares.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Exemplar não existe.");
                        DataSet oDa2 = new DataSet();
                        oDa2 = usuarios.obtemExemplares();
                        dgvConsulta.DataSource = oDa2.Tables[0];
                        EP.Clear();
                    }
                    txtID_consulta.Text = "";
                    txtNome_Comsulta.Text = "";
                    txtID_consulta.Focus();
                    EP.Clear();
                }
                catch
                {
                    MessageBox.Show("Usuário não existe", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                EP.SetError(txtID_consulta, "Por favor preencher corretamente.");
                EP.SetError(txtNome_Comsulta, "Por favor preencher corretamente.");
                txtID_consulta.Focus();
                
            }

        }

        /*===============usuarios===============*/

        private void rbtCadastrar_usu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCadastrar_usu.Checked)
                btnAcao_usu.Text = "Cadastrar";
        }

        private void rbtAtualizar_usu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAtualizar_usu.Checked)
                btnAcao_usu.Text = "Atualizar";
        }

        private void btnAcao_usu_Click(object sender, EventArgs e)
        {
            if (txtID_cad.Text == "" ||
                txtNome_cad.Text == "" ||
                txtEmail_cad.Text == "" ||
                txtCelular_cad.Text == "" ||
                txtCurso_cad.Text == "")
            {
                if (txtID_cad.Text == "")
                {
                    EP.SetError(txtID_cad, "Por favor preencher corretamente.");
                    txtID_cad.Focus();
                }
                else if (txtNome_cad.Text == "")
                {
                    EP.SetError(txtNome_cad, "Por favor preencher corretamente.");
                    txtNome_cad.Focus();
                }
                else if (txtEmail_cad.Text == "")
                {
                    EP.SetError(txtEmail_cad, "Por favor preencher corretamente.");
                    txtEmail_cad.Focus();
                }
                else if (txtCurso_cad.Text == "")
                {
                    EP.SetError(txtCurso_cad, "Por favor preencher corretamente.");
                    txtCurso_cad.Focus();
                }
                else
                {
                    EP.SetError(txtCelular_cad, "Por favor preencher corretamente.");
                    txtCelular_cad.Focus();
                }
            }
            else
            {
                if (rbtCadastrar_usu.Checked)
                {
                    try
                    {
                        if (IsEmail(txtEmail_cad.Text) == false)
                        {
                            MessageBox.Show("Email esta no formato incorreto.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEmail_cad.Focus();
                        }
                        else
                        {
                            CamadaNegocios usuarios = new CamadaNegocios();

                            DataSet oDA = new DataSet();
                            oDA = usuarios.inserirUsuário(txtID_cad.Text, txtNome_cad.Text, txtEmail_cad.Text, txtCelular_cad.Text, txtCurso_cad.Text, txtCategoria_usu.SelectedItem.ToString());

                            DataSet oDS = new DataSet();
                            oDS = usuarios.obtemUsuarios();
                            dgvCadastro.DataSource = oDS.Tables[0];
                            dgvDeleta.DataSource = oDS.Tables[0];

                            if (rbtUsuario_consulta.Checked)
                                dgvConsulta.DataSource = oDS.Tables[0];

                            txtID_cad.Text = "";
                            txtNome_cad.Text = "";
                            txtEmail_cad.Text = "";
                            txtCelular_cad.Text = "";
                            txtCurso_cad.Text = "";
                            txtID_cad.Focus();
                            EP.Clear();

                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao realizar cadastro.");
                    }
                }
                else if (rbtAtualizar_usu.Checked)
                {
                    try
                    {
                        if (IsEmail(txtEmail_cad.Text) == false)
                        {
                            MessageBox.Show("Email esta no formato incorreto.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEmail_cad.Focus();
                        }
                        else
                        {
                            CamadaNegocios usuarios = new CamadaNegocios();

                            DataSet oDA = new DataSet();
                            oDA = usuarios.atualizarUsuários(txtID_cad.Text, txtNome_cad.Text, txtEmail_cad.Text, txtCelular_cad.Text, txtCurso_cad.Text, txtCategoria_usu.SelectedItem.ToString());

                            DataSet oDS = new DataSet();
                            oDS = usuarios.obtemUsuarios();
                            dgvCadastro.DataSource = oDS.Tables[0];
                            dgvDeleta.DataSource = oDS.Tables[0];

                            if (rbtUsuario_consulta.Checked)
                                dgvConsulta.DataSource = oDS.Tables[0];

                            txtID_cad.Text = "";
                            txtNome_cad.Text = "";
                            txtEmail_cad.Text = "";
                            txtCelular_cad.Text = "";
                            txtCurso_cad.Text = "";
                            txtID_cad.Focus();
                            EP.Clear();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao cadastrar.");
                    }
                }
            }
        }

        /*==========exemplares==============*/
        private void rbtCadastrar_exe_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCadastrar_exe.Checked)
            {
                btnacao_exe.Text = "Cadastrar";
            }
        }

        private void rbtAtualizar_exe_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAtualizar_exe.Checked)
            {
                btnacao_exe.Text = "Atualizar";
            }
        }

        private void btnacao_exe_Click(object sender, EventArgs e)
        {
            if (txtID_Exe.Text == "" ||
               txtLivro_Exe.Text == "" ||
               txtAutor_Exe.Text == "" ||
               txtQuant_exe.Text == "" ||
               txtCategoria_exe.Text == "")
            {
                if (txtID_Exe.Text == "")
                {
                    EP.SetError(txtID_Exe, "Por favor preencher corretamente.");
                    txtID_Exe.Focus();
                }
                else if (txtLivro_Exe.Text == "")
                {
                    EP.SetError(txtLivro_Exe, "Por favor preencher corretamente.");
                    txtLivro_Exe.Focus();
                }
                else if (txtAutor_Exe.Text == "")
                {
                    EP.SetError(txtAutor_Exe, "Por favor preencher corretamente.");
                    txtAutor_Exe.Focus();
                }
                else if (txtQuant_exe.Text == "")
                {
                    EP.SetError(txtQuant_exe, "Por favor preencher corretamente.");
                    txtQuant_exe.Focus();
                }
                else
                {
                    EP.SetError(txtCategoria_exe, "Por favor preencher corretamente.");
                    txtCategoria_exe.Focus();
                }

            }
            else
            {
                if (rbtCadastrar_exe.Checked)
                {
                    try
                    {
                        CamadaNegocios exemplares = new CamadaNegocios();

                        int Quantidade = int.Parse(txtQuant_exe.Text);

                        DataSet oDA = new DataSet();
                        oDA = exemplares.inserirExemplares(txtID_Exe.Text, txtLivro_Exe.Text, txtAutor_Exe.Text, Quantidade, txtCategoria_exe.SelectedItem.ToString());

                        DataSet oDS = new DataSet();
                        oDS = exemplares.obtemExemplares();
                        dgvExemplares.DataSource = oDS.Tables[0];

                        if (rbtExemplar_consulta.Checked)
                            dgvConsulta.DataSource = oDS.Tables[0];

                        txtID_Exe.Text = "";
                        txtLivro_Exe.Text = "";
                        txtAutor_Exe.Text = "";
                        txtQuant_exe.Text = "";
                        txtCategoria_exe.Text = "";
                        txtID_Exe.Focus();
                        EP.Clear();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao cadastrar.");
                    }
                }
                else if (rbtAtualizar_exe.Checked)
                {
                    try
                    {
                        CamadaNegocios exemplares = new CamadaNegocios();

                        int Quantidade = int.Parse(txtQuant_exe.Text);

                        DataSet oDA = new DataSet();
                        oDA = exemplares.atualizarExemplares(txtID_Exe.Text, txtLivro_Exe.Text, txtAutor_Exe.Text, Quantidade, txtCategoria_exe.SelectedItem.ToString());

                        DataSet oDS = new DataSet();
                        oDS = exemplares.obtemExemplares();
                        dgvExemplares.DataSource = oDS.Tables[0];

                        if (rbtExemplar_consulta.Checked)
                            dgvConsulta.DataSource = oDS.Tables[0];

                        txtID_Exe.Text = "";
                        txtLivro_Exe.Text = "";
                        txtAutor_Exe.Text = "";
                        txtQuant_exe.Text = "";
                        txtCategoria_exe.Text = "";
                        txtID_Exe.Focus();
                        EP.Clear();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao cadastrar.");
                    }
                }
            }
        }

        private void txtQuant_exe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
            if (txtQuant_exe.Text.Length > 3)
            {
                e.Handled = true;
            }
        }

        private void txtID_Exe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
            if (txtID_Exe.Text.Length > 10)
            {
                e.Handled = true;
            }
        }

        private void btnDeleta_Click(object sender, EventArgs e)
        {
            CamadaNegocios acao = new CamadaNegocios();

            if (txtDeleta.Text == "")
            {
                EP.SetError(txtDeleta, "Por favor informar código.");
            }

            if (rbtUsuario.Checked && txtDeleta.Text != "")
            {
                DialogResult result = MessageBox.Show("Você deseja apagar esse registro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {

                    DataSet oDa = new DataSet();
                    oDa = acao.DeletaUsuario_ID(txtDeleta.Text);

                    MessageBox.Show("Registro apagado.");
                    txtDeleta.Text = "";
                }
                else
                {
                    MessageBox.Show("Cancelado.");
                }
                DataSet oDa2 = new DataSet();
                oDa2 = acao.obtemUsuarios();

                dgvCadastro.DataSource = oDa2.Tables[0];

                dgvDeleta.DataSource = oDa2.Tables[0];
            }
            else if (rbtExemplar.Checked && txtDeleta.Text != "")
            {

                DialogResult result = MessageBox.Show("Você Deseja apagar esse registro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    DataSet oDa = new DataSet();
                    oDa = acao.DeletaExemplar_ID(txtDeleta.Text);


                    MessageBox.Show("Registro apagado.");
                    txtDeleta.Text = "";
                }
                else
                {
                    MessageBox.Show("Cancelado.");
                }

                DataSet oDa3 = new DataSet();
                oDa3 = acao.obtemExemplares();

                dgvDeleta.DataSource = oDa3.Tables[0];

                dgvExemplares.DataSource = oDa3.Tables[0];

            }
        }

        private void rbtExemplar_CheckedChanged(object sender, EventArgs e)
        {
            CamadaNegocios usuarios = new CamadaNegocios();

            DataSet oDa2 = new DataSet();
            oDa2 = usuarios.obtemExemplares();
            dgvDeleta.DataSource = oDa2.Tables[0];
        }

        private void rbtUsuario_CheckedChanged(object sender, EventArgs e)
        {
            CamadaNegocios usuarios = new CamadaNegocios();

            DataSet oDa = new DataSet();
            oDa = usuarios.obtemUsuarios();
            dgvDeleta.DataSource = oDa.Tables[0];
        }

        private void rbtUsuario_consulta_CheckedChanged(object sender, EventArgs e)
        {
            CamadaNegocios usuarios = new CamadaNegocios();

            DataSet oDa = new DataSet();
            oDa = usuarios.obtemUsuarios();
            dgvConsulta.DataSource = oDa.Tables[0];
            lblID.Enabled = true;
            txtID_consulta.Enabled = true;

            lblUsuExe_Consulta.Text = "Nome:";
        }

        private void rbtExemplar_consulta_CheckedChanged(object sender, EventArgs e)
        {
            CamadaNegocios usuarios = new CamadaNegocios();

            DataSet oDa2 = new DataSet();
            oDa2 = usuarios.obtemExemplares();
            dgvConsulta.DataSource = oDa2.Tables[0];
            lblID.Enabled = false;
            txtID_consulta.Enabled = false;

            lblUsuExe_Consulta.Text = "Exemplar:";

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja deslogar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /*--------------Emprestimo--------------*/

        private void btnEmpresta_Click(object sender, EventArgs e)
        {
            CamadaNegocios empresta = new CamadaNegocios();

            if (txtID_emp.Text == "")
                EP.SetError(txtID_emp, "Por favor preencher campo.");
            else if(txtID_exe_emp.Text =="")
                EP.SetError(txtID_exe_emp, "Por favor preencher campo.");
            else
            {
                try
                {
                    /*--verifica usu--*/
                    DataSet verifica_usu = new DataSet();
                    verifica_usu = empresta.verificarUsu(txtID_emp.Text);

                    /*--verifica exe--*/
                    DataSet verifica_exe = new DataSet();
                    verifica_exe = empresta.verificarExe(txtID_exe_emp.Text);

                    /*--verifica se pessoa possui emprestimo--*/
                    DataSet verifica = new DataSet();
                    verifica = empresta.verifica_emp_existente(txtID_emp.Text);

                    /*--verifica penalidade--*/
                    DataSet penalidade = new DataSet();
                    penalidade = empresta.verificaUsuario(txtID_emp.Text);

                    /*--penalizado-*/
                    if (penalidade.Tables[0].Rows.Count == 1)
                    {
                        DataSet oDS = new DataSet();
                        oDS = empresta.obtemUsuario_emp(txtID_emp.Text);
                        dgvEmp.DataSource = oDS.Tables[0];
                        dgvEmp.Columns[0].HeaderText = "ID Usuario";
                        dgvEmp.Columns[1].HeaderText = "ID Exemplar";
                        dgvEmp.Columns[2].HeaderText = "Nome";
                        dgvEmp.Columns[3].HeaderText = "Livro";
                        dgvEmp.Columns[4].HeaderText = "Penalidade";

                        string nome = dgvEmp.Rows[0].Cells[2].Value.ToString();

                        DateTime pena = DateTime.Parse(dgvEmp.Rows[0].Cells[4].Value.ToString());


                        MessageBox.Show("O empréstimo não pode ser realizado. O dia que " + nome + " poderá realizar empréstimo é dia " + pena.ToShortDateString());

                        txtID_emp.Text = "";
                        txtID_exe_emp.Text = "";

                    }

                    /*-se não estiver penalizado, verifica se ja existe-*/
                    else if (verifica.Tables[0].Rows.Count == 1)
                    {
                        DataSet tabela_emp = new DataSet();
                        tabela_emp = empresta.obtemEmprestimos();
                        dgvEmp.Columns.Clear();
                        dgvEmp.DataSource = tabela_emp.Tables[0];

                        string livro = dgvEmp.Rows[0].Cells[1].Value.ToString();
                        dgvEmp.Columns[0].HeaderText = "ID Usuário";
                        dgvEmp.Columns[1].HeaderText = "ID Livro";
                        dgvEmp.Columns[2].HeaderText = "Inicio";
                        dgvEmp.Columns[3].HeaderText = "Entrega";
                        MessageBox.Show("Não é possível realizar empréstimo, pois este usuário já realizou o empréstimo");
                        

                        txtID_emp.Text = "";
                        txtID_exe_emp.Text = "";
                    }
                    else if (verifica_usu.Tables[0].Rows.Count == 0)
                    {
                        DataSet tabela_usu = new DataSet();
                        tabela_usu = empresta.obtemUsuarios();

                        dgvEmp.Columns.Clear();
                        dgvEmp.DataSource = tabela_usu.Tables[0];
                        MessageBox.Show("Usuário não existe.");

                        txtID_emp.Text = "";
                        txtID_exe_emp.Text = "";
                    }
                    else if (verifica_exe.Tables[0].Rows.Count == 0)
                    {
                        DataSet tabela_exe = new DataSet();
                        tabela_exe = empresta.obtemExemplares();

                        dgvEmp.Columns.Clear();
                        dgvEmp.DataSource = tabela_exe.Tables[0];
                        MessageBox.Show("Exemplar não existe.");

                        txtID_emp.Text = "";
                        txtID_exe_emp.Text = "";
                    }
                    else
                    {
                        DateTime ini = Convert.ToDateTime(dtpIni.Text);
                        DateTime fim = Convert.ToDateTime(dtpFim.Text);

                        dgvEmp.Columns.Clear();
                        /*=====seleciona todas informaçoes=======*/
                        DataSet oDS2 = new DataSet();
                        oDS2 = empresta.obtemEmprestimos();
                        dgvEmp.DataSource = oDS2.Tables[0];

                        /*====seleciona tabelas exemplares pelo ID de exe====*/
                        DataSet exe = new DataSet();
                        exe = empresta.consultaExemplar(txtID_exe_emp.Text);
                        dgvEmp.DataSource = exe.Tables[0];

                        int quant = int.Parse(dgvEmp.Rows[0].Cells[3].Value.ToString());
                        int um = 1;

                        if (quant.ToString() == "0")
                        {
                            MessageBox.Show("Não é possível realizar o empréstimo, não há este exemplar disponível no momento");
                        }
                        else
                        {
                            int restante = quant - um;

                            /*---insere informação no banco de dados--*/
                            DataSet oDS = new DataSet();
                            oDS = empresta.concluiEmp(txtID_emp.Text, txtID_exe_emp.Text, ini, fim);

                            DataSet oDS3 = new DataSet();
                            oDS3 = empresta.dpsSub_Soma(txtID_exe_emp.Text, restante.ToString());
                            dgvEmp.Columns.Clear();

                            DataSet oDS4 = new DataSet();
                            oDS4 = empresta.obtemEmprestimos();

                            dgvEmp.DataSource = oDS4.Tables[0];
                            dgvEmp.Columns[0].HeaderText = "ID Usuário";
                            dgvEmp.Columns[1].HeaderText = "ID Livro";
                            dgvEmp.Columns[2].HeaderText = "Inicio";
                            dgvEmp.Columns[3].HeaderText = "Entrega";


                            DateTime prazo = DateTime.Parse(dgvEmp.Rows[0].Cells[3].Value.ToString());


                            MessageBox.Show("Empréstimo concluído. O prazo máximo para devolução é " + fim.ToShortDateString() + ".");

                            DataSet atu = new DataSet();
                            atu = empresta.obtemExemplares();

                            dgvExemplares.DataSource = atu.Tables[0];

                            DataSet hist = new DataSet();
                            hist = empresta.obtemEmprestimos();

                            dgvHist.DataSource = hist.Tables[0];

                            txtID_emp.Text = "";
                            txtID_exe_emp.Text = "";
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void rbtCons_emp_CheckedChanged(object sender, EventArgs e)
        {
            CamadaNegocios empresta = new CamadaNegocios();
            DataSet emp = new DataSet();
            emp = empresta.obtemEmprestimos();

            dgvHist.DataSource = emp.Tables[0];
            dgvHist.Columns[0].HeaderText = "ID do Aluno";
            dgvHist.Columns[1].HeaderText = "ID do livro";
            dgvHist.Columns[2].HeaderText = "Início";
            dgvHist.Columns[3].HeaderText = "Prazo";
        }

        private void rbtHist_emp_CheckedChanged(object sender, EventArgs e)
        {

            CamadaNegocios empresta = new CamadaNegocios();
            DataSet hist = new DataSet();
            hist = empresta.obtemHistorico();

            dgvHist.DataSource = hist.Tables[0];
            dgvHist.Columns[0].HeaderText = "ID do Usuário";
            dgvHist.Columns[1].HeaderText = "ID do livro";
            dgvHist.Columns[2].HeaderText = "Livro";
            dgvHist.Columns[3].HeaderText = "Dia da devolução";
        }

        private void rbtPenalidade_CheckedChanged(object sender, EventArgs e)
        {
            CamadaNegocios penalidade = new CamadaNegocios();
            DataSet pen = new DataSet();
            pen = penalidade.obtemPenalidade();

            dgvHist.DataSource = pen.Tables[0];
            dgvHist.Columns[0].HeaderText = "ID do Usuário";
            dgvHist.Columns[1].HeaderText = "ID do Livro";
            dgvHist.Columns[2].HeaderText = "Nome";
            dgvHist.Columns[3].HeaderText = "Livro";
            dgvHist.Columns[4].HeaderText = "Penalidade";
        }

        private void btnPesq_Hist_Click(object sender, EventArgs e)
        {
            CamadaNegocios historico = new CamadaNegocios();
            try 
            {
                DataSet proc = new DataSet();
                DataSet penalidade = new DataSet();

                if (txtID_emp_hist.Text == "")
                {
                    EP.SetError(txtID_emp_hist, "Por favor inserir código");
                    txtID_emp_hist.Focus();
                }
                else if (rbtCons_emp.Checked && txtID_emp_hist.Text != "")
                {

                    proc = historico.obtemEmp_cons(txtID_emp_hist.Text);

                    dgvHist.DataSource = proc.Tables[0];
                    dgvHist.Columns[0].HeaderText = "ID do Usuário";
                    dgvHist.Columns[1].HeaderText = "ID do livro";
                    dgvHist.Columns[2].HeaderText = "Empréstimo";
                    dgvHist.Columns[3].HeaderText = "Prazo";

                    txtID_emp_hist.Text = "";
                    txtID_emp_hist.Focus();

                    EP.Clear();
                }
                else if (rbtHist_emp.Checked)
                {
                    if (txtID_emp_hist.Text != "")
                    {
                        DataSet hist = new DataSet();
                        hist = historico.obtemHist_cons(txtID_emp_hist.Text);

                        dgvHist.DataSource = hist.Tables[0];
                        dgvHist.Columns[0].HeaderText = "ID Usuário";
                        dgvHist.Columns[1].HeaderText = "Nome";
                        dgvHist.Columns[2].HeaderText = "ID do livro";
                        dgvHist.Columns[3].HeaderText = "Dia da devolução";

                        txtID_emp_hist.Text = "";
                        txtID_emp_hist.Focus();
                        EP.Clear();
                    }
                }
                else if (rbtPenalidade.Checked)
                {
                    if (txtID_emp_hist.Text != "")
                    {
                        penalidade = historico.obtemPen_cons(txtID_emp_hist.Text);

                        dgvHist.DataSource = penalidade.Tables[0];
                        dgvHist.Columns[0].HeaderText = "ID Usuário";
                        dgvHist.Columns[1].HeaderText = "Nome";
                        dgvHist.Columns[2].HeaderText = "Exemplar";
                        dgvHist.Columns[3].HeaderText = "Penalidade";

                        txtID_emp_hist.Text = "";
                        txtID_emp_hist.Focus();

                        EP.Clear();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /*----------Devolução-----------*/
        private void btnDevolve_Click(object sender, EventArgs e)
        {
            try
            {
                CamadaNegocios devolucao = new CamadaNegocios();

                if (txtID_Usu_Dev.Text == "")
                    EP.SetError(txtID_Usu_Dev, "Por favor inserir ID");
                else if(txtID_Exe_Dev.Text=="")
                    EP.SetError(txtID_Exe_Dev, "Por favor inserir ID");
                else
                {
                    DataSet verifica = new DataSet();
                    /* --- Select cod, id, inicio, entrega from emprestimos---*/
                    verifica = devolucao.obtemDev_from_emp(txtID_Usu_Dev.Text, txtID_Exe_Dev.Text);
                    dgvteste.DataSource = verifica.Tables[0];


                    DateTime verifica_entrega = DateTime.Parse(dgvteste.Rows[0].Cells[3].Value.ToString());
                    
                    /*------------------------------hoje-----------entrega---*/
                    int result = DateTime.Compare(dtpIni.Value, verifica_entrega);

                    dgvteste.Columns.Clear();

                    TimeSpan dif_datas = dtpIni.Value.Subtract(verifica_entrega);
                    int totaldias = dif_datas.Days;

                    /*----Não há emprestimos----*/
                    if (verifica.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Não há nenhum empréstimo relacionado a este usuário.");
                        txtID_Usu_Dev.Text = "";
                        txtID_Exe_Dev.Text = "";
                        EP.Clear();
                    }
                    /*----Há emprestimos----*/
                    else
                    {
                        /*-----hoje > do q entrega-----*/
                        if (result > 0)
                        {
                            DataSet devolv = new DataSet();
                            /* --- Select cod, id, inicio, entrega from emprestimos--*/
                            devolv = devolucao.obtemDev_from_emp(txtID_Usu_Dev.Text, txtID_Exe_Dev.Text);

                            dgvDev.DataSource = devolv.Tables[0];

                            string cod = dgvDev.Rows[0].Cells[0].Value.ToString();
                            string ID = dgvDev.Rows[0].Cells[1].Value.ToString();
                            DateTime entrega_emp = DateTime.Parse(dgvDev.Rows[0].Cells[3].Value.ToString());

                            dgvDev.Columns.Clear();

                            /*====seleciona tabelas exemplares pelo ID de exe====*/
                            DataSet exemp = new DataSet();
                            /*----              ID livro Autor Quant Categoria
                             *                   0  1      2     3      4-*/
                            exemp = devolucao.consultaExemplar(txtID_Exe_Dev.Text);
                            dgvteste.DataSource = exemp.Tables[0];

                            string Livro = dgvteste.Rows[0].Cells[1].Value.ToString();
                            int Quant = int.Parse(dgvteste.Rows[0].Cells[3].Value.ToString());
                            int Um = 1;

                            int Restante = Quant + Um;

                            DataSet oDs3 = new DataSet();
                            /*Update exemplares set Quantidade*/
                            oDs3 = devolucao.dpsSoma(txtID_Exe_Dev.Text, Restante.ToString());


                            DataSet inclui_hist = new DataSet();
                            inclui_hist = devolucao.incluiHist(cod, ID, Livro, entrega_emp);

                            DataSet deleta_Emp = new DataSet();
                            deleta_Emp = devolucao.DeletarEmp(txtID_Usu_Dev.Text, txtID_Exe_Dev.Text);

                            /*----Atuaiza Historico e emprestimos*/
                            DataSet oDA3 = new DataSet();
                            oDA3 = devolucao.obtemEmprestimos();

                            dgvHist.DataSource = oDA3.Tables[0];
                            dgvEmp.DataSource = oDA3.Tables[0];

                            /*---Select cod, ID, livro, entrega from historico*/
                            DataSet tabela_hist = new DataSet();
                            tabela_hist = devolucao.obtemDev();
                            dgvDev.DataSource = tabela_hist.Tables[0];

                            EP.Clear();
                            txtID_Usu_Dev.Text = "";
                            txtID_Exe_Dev.Text = "";

                            dgvDev.Columns[0].HeaderText = "ID do Usuário";
                            dgvDev.Columns[1].HeaderText = "ID do Exemplar";
                            dgvDev.Columns[2].HeaderText = "Livro";
                            dgvDev.Columns[3].HeaderText = "Entrega";

                            MessageBox.Show("Devolução realizada, porém depois da data limite. A penalidade será de " + totaldias + " dias.");

                            /*update exemplar*/
                            dgvteste.Columns.Clear();
                            DataSet atualizar = new DataSet();
                            atualizar = devolucao.obtemExemplares();
                            dgvExemplares.DataSource = atualizar.Tables[0];

                            dgvteste.DataSource = atualizar.Tables[0];

                        }
                        /*-----hoje = ou menor do q entrega-----*/
                        else
                        {
                            dgvteste.Columns.Clear();
                            DataSet dev = new DataSet();
                            /* --- Select cod, id, inicio, entrega from emprestimos--- 
                                            0   1      2      3*/
                            dev = devolucao.obtemDev_from_emp(txtID_Usu_Dev.Text, txtID_Exe_Dev.Text);

                            dgvDev.DataSource = dev.Tables[0];

                            string mat = dgvDev.Rows[0].Cells[0].Value.ToString();
                            string id = dgvDev.Rows[0].Cells[1].Value.ToString();
                            DateTime entrega = DateTime.Parse(dgvDev.Rows[0].Cells[3].Value.ToString());

                            dgvDev.Columns.Clear();

                            /*====seleciona tabelas exemplares pelo ID de exe====*/
                            DataSet exe = new DataSet();
                            /*----              ID livro Autor Quant Categoria
                             *                   0  1      2     3      4-*/
                            exe = devolucao.consultaExemplar(txtID_Exe_Dev.Text);
                            dgvteste.DataSource = exe.Tables[0];

                            string livro = dgvteste.Rows[0].Cells[1].Value.ToString();
                            int quant = int.Parse(dgvteste.Rows[0].Cells[3].Value.ToString());
                            int um = 1;

                            int restante = quant + um;


                            DataSet oDS3 = new DataSet();
                            /*Update exemplares set Quantidade*/
                            oDS3 = devolucao.dpsSoma(txtID_Exe_Dev.Text, restante.ToString());


                            DataSet inclui = new DataSet();
                            inclui = devolucao.incluiHist(mat, id, livro, entrega);

                            DataSet deletaEmp = new DataSet();
                            deletaEmp = devolucao.DeletarEmp(txtID_Usu_Dev.Text, txtID_Exe_Dev.Text);

                            /*----Atuaiza Historico e emprestimos*/
                            DataSet oDa3 = new DataSet();
                            oDa3 = devolucao.obtemEmprestimos();

                            dgvHist.DataSource = oDa3.Tables[0];
                            dgvEmp.DataSource = oDa3.Tables[0];

                            /*---Select cod, ID, livro, entrega from historico*/
                            dgvDev.Columns.Clear();

                            DataSet tabela = new DataSet();
                            tabela = devolucao.obtemDev();
                            dgvDev.DataSource = tabela.Tables[0];

                            EP.Clear();

                            txtID_Usu_Dev.Text = "";
                            txtID_Exe_Dev.Text = "";

                            /*
                            dgvDev.Columns[0].HeaderText = "ID do Usuário";
                            dgvDev.Columns[1].HeaderText = "ID do Exemplar";
                            dgvDev.Columns[2].HeaderText = "Livro";
                            dgvDev.Columns[3].HeaderText = "Entrega";
                            */

                            MessageBox.Show("Devolução realizada.");

                            /*update exemplar*/
                            dgvteste.Columns.Clear();
                            DataSet atu = new DataSet();
                            atu = devolucao.obtemExemplares();
                            dgvExemplares.DataSource = atu.Tables[0];

                            dgvteste.DataSource = atu.Tables[0];
                        }
                            
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void btnTesteConsulta_Click(object sender, EventArgs e)
        {
            if (rbtUsuario_consulta.Checked)
            {
                CamadaNegocios consulta = new CamadaNegocios();

                DataSet cons = new DataSet();
                
                dgvConsulta.DataSource = cons.Tables[0];
            }
        }

        private void txtCelular_cad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
            if (txtCelular_cad.Text.Length > 11)
            {
                e.Handled = true;
            }
        }

        private void btnLogout2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja deslogar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
