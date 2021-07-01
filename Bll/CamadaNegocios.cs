using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace Bll
{
    public class CamadaNegocios
    {
        public DataSet obtemUsuarios()
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select ID, nome, email, celular, curso, categoria from usuarios");
        }

        public DataSet obtemExemplares()
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select * from exemplares");
        }

        public DataSet consultaUsuarios(string id)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select ID, nome, email, celular, curso, categoria from usuarios where ID = '" + id + "' ");
        }

        public DataSet consultaExemplar(string id)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select * from exemplares where ID = '" + id + "' ");
        }

        public DataSet inserirUsuário(string ID, string nome,string email, string celular, string curso, string categoria)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "INSERT INTO usuarios(ID, nome, email, celular, curso, categoria) values('" + ID + "', '" + nome + "', '"+ email+"', '" + celular + "', '"+ curso +"', '"+ categoria +"')";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }

        public DataSet atualizarUsuários(string ID, string nome, string email, string celular, string curso, string categoria)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "Update usuarios set nome = '" + nome + "', email = '" + email + "', celular = '" + celular + "', curso = '" + curso + "', categoria = '"+ categoria +"' where ID = '" + ID + "'";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }

        public DataSet DeletaUsuario_ID(string ID)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Delete from usuarios where ID = '" + ID + "'");
        }

        public DataSet DeletaExemplar_ID(string ID)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Delete from exemplares where ID = '" + ID + "'");
        }

        public DataSet inserirExemplares(string ID, string Livro, string Autor, int Quantidade, string Categoria)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "INSERT INTO exemplares(ID, Livro, Autor, Quantidade, Categoria) values('" + ID + "', '" + Livro + "', '" + Autor + "', '" + Quantidade + "', '" + Categoria + "')";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }

        public DataSet atualizarExemplares(string ID, string Livro, string Autor, int Quantidade, string Categoria)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "Update exemplares set Livro = '" + Livro + "', Autor = '" + Autor + "', Quantidade = '" + Quantidade + "', Categoria = '" + Categoria + "' where ID = '" + ID + "'";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }

        /*--------------------------------Funcionários------------------------------*/

        public DataSet obtemFuncionarios()
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select * from funcionarios");
        }

        public DataSet inserirFuncionario(string ID, string nome, string telefone, string nascimento, string endereco, string login)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "INSERT INTO funcionarios(ID, nome, telefone, nascimento, endereco, login) values('" + ID + "', '" + nome + "', '" + telefone + "', '" + nascimento + "', '" + endereco + "', '" + login + "')";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }

        public DataSet atualizarFuncionario(string ID, string nome, string telefone, string nascimento, string endereco, string login)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "Update funcionarios set nome = '" + nome + "', telefone = '" + telefone + "', nascimento = '"+ nascimento +"', endereco = '"+ endereco +"', login = '"+ login +"' where ID = '" + ID + "'";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }

        public DataSet deletaFuncionario(string ID)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Delete from funcionarios where ID = '" + ID + "'");
        }

        public DataSet obtemFuncionarios_Consulta(string ID, string nome)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select * from funcionarios where (ID = '"+ ID +"' and nome ='"+ nome +"') ");
        }

        /*-------------------------------Login------------------------------*/
        public DataSet verificaLogin_func(string user, string pwd)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select login,senha from funcionarios where (login = '" + user + "' and senha ='" + pwd + "') ");
        }

        public DataSet verificaLogin_adm(string user, string pwd)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select usuario,senha from login where (usuario = '" + user + "' and senha ='" + pwd + "') ");
        }
        /*-------------------------------Emprestimo------------------------------*/

        public DataSet verificaUsuario(string ID)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select ID from penalidade where ID = '" + ID + "'");
        }
        public DataSet verifica_emp_existente(string cod)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select cod from emprestimos where cod = '" + cod + "'");
        }


        public DataSet obtemUsuario_emp(string ID)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select ID, ID_Exe, nome, livro, data from penalidade where ID = '" + ID + "'");
        }

        public DataSet concluiEmp(string cod, string ID, DateTime inicio, DateTime entrega)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "INSERT INTO emprestimos(cod, id, inicio, entrega) values('" + cod + "', '"+ ID +"', '" + inicio + "', '" + entrega + "')";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }

        public DataSet obtemEmprestimos()
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select cod, id, inicio, entrega from emprestimos");
        }

        public DataSet verificarUsu(string ID)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select ID from usuarios where ID = '" + ID + "'");
        }

        public DataSet verificarExe(string ID)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select ID from exemplares where ID = '" + ID + "'");
        }

        public DataSet obtemHistorico()
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select cod, ID, livro, entrega from historico");
        }

        public DataSet dpsSub_Soma(string ID, string quat)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "Update exemplares set Quantidade = '" + quat + "' where ID = '" + ID + "'";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }

        public DataSet dpsSoma(string ID, string quat)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "Update exemplares set Quantidade = '" + quat + "' where ID = '" + ID + "'";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }
        /*-------------------------------Historico------------------------------*/

        public DataSet obtemEmp_cons(string cod)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select cod, id, inicio, entrega from emprestimos where cod = '" + cod + "'");
        }

        public DataSet obtemHist_cons(string cod)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select cod, ID, livro, entrega from historico where cod = '" + cod + "'");
        }

        public DataSet obtemPen_cons(string ID)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select ID, nome, livro, data from penalidade where ID = '" + ID + "'");
        }

        /*-------------------------------Devolve------------------------------*/

        public DataSet obtemDev_from_emp(string cod,string id)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select cod, id, inicio, entrega from emprestimos where cod = '" + cod + "' and id = '"+ id +"'");
        }

        public DataSet obtemDev_from_Pen(string cod, string id)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select ID,ID_Exe, nome, livro, data from penalidade where ID = '" + cod + "' and ID_Exe = '" + id + "'");
        }

        public DataSet incluiHist(string cod, string ID, string livro, DateTime entrega)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "INSERT INTO historico(cod, ID, livro, entrega) values('" + cod + "', '"+ID+"', '" + livro + "', '" + entrega + "')";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }


        public DataSet DeletarEmp(string cod, string id)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Delete from emprestimos where cod = '" + cod + "' and id = '" + id + "'");
        }

        public DataSet DeletarPen(string cod, string id)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Delete from penalidade where ID = '" + cod + "' and ID_Exe = '" + id + "'");
        }

        public DataSet obtemDev()
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select cod, ID, livro, entrega from historico");
        }

        public DataSet obtemPenalidade()
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select ID, ID_Exe, nome, livro, data from penalidade");
        }

        public DataSet incluiPenalidade(string cod, string ID_Exe, string nome, string livro, DateTime entrega)
        {
            conOleDb acessoDados = new conOleDb();
            string mySql = "INSERT INTO penalidade(ID, ID_Exe, nome, livro, data) values('" + cod + "', '" + ID_Exe +"', '" + nome + "', '" + livro + "', '" + entrega + "')";
            //acessoDados.ExecutaNQ(mySql);
            return acessoDados.retornaDataSet(mySql);
        }

        public DataSet obtemEmprestimos_ID(string id)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select cod, nome, id, livro, inicio, entrega from emprestimos where cod = '" + id + "'");
        }

        public DataSet ConsultaUsu_ID_Nome(string ID, string nome)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select * from usuarios where nome like '%"+ nome + "%' and ID = '"+ID+"'");
        }

        public DataSet ConsultaExe_Nome(string livro)
        {
            conOleDb acessoDados = new conOleDb();
            return acessoDados.retornaDataSet("Select * from exemplares where Livro like '%" + livro + "%'");
        }
    }
}
