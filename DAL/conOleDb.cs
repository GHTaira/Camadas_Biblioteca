using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class conOleDb
    {
        OleDbConnection con = new OleDbConnection(Properties.Settings.Default.Biblioteca);

        public void abrirConexao()
        {
            con.Open();
        }

        public void fecharConexao()
        {
            con.Close();
        }

        public DataSet retornaDataSet(string sql)
        {
            try
            {
                abrirConexao();
                OleDbDataAdapter oDa = new OleDbDataAdapter(sql, con);
                DataSet oDs = new DataSet();
                oDa.Fill(oDs);
                fecharConexao();
                return oDs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ExecutaNQ(string sql)
        {
            abrirConexao();
            OleDbCommand command = new OleDbCommand(sql, con);
            command.ExecuteNonQuery();
            fecharConexao();
        }


    }
}
