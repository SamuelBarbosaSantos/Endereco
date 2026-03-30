using Endereco.Repositorio.Contrato;
using MySql.Data.MySqlClient;
using System.Data;

namespace Endereco.Repositorio
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        public void Atualizar(Models.Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Models.Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Models.Endereco ObterEndereco(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Endereco> ObterTodosEnderecos => throw new NotImplementedException();

        public IEnumerable<EnderecoRepositorio> ObterTodosEnderecos()
        {
            List<Endereco> endList = new List<Endereco>();
            using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd= new MySqlCommand("SELECT * FROM endereco", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    endList.Add(
                        new Endereco
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        CEP = Convert.ToString(dr["CEP"]),
                        Estado = Convert.ToString(dr["Estado"]),
                        Cidade = Convert.ToString(dr["Cidade"]),
                        Bairro = Convert.ToString(dr["Bairro"]),
                        Logradouro = Convert.ToString(dr["Logradouro"]),
                        Complemento = Convert.ToString(dr["Complemento"]),
                        Numero = Convert.ToString(dr["Numero"])
                    });
                }
                return endList;
            }
        }
    }
}
