using Endereco.Repositorio.Contrato;
using MySql.Data.MySqlClient;
using System.Data;

namespace Endereco.Repositorio
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly string? _conexaoMySQL;

        private IEnumerable<Models.Endereco> GetObterTodosEnderecos()
        {
            throw new NotImplementedException();
        }

        public EnderecoRepositorio(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public IEnumerable<Models.Endereco> ObterTodosEnderecos()
        {
            List<Models.Endereco> endList = new List<Models.Endereco>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM endereco", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    endList.Add(new Models.Endereco
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
            }
            return endList;
        }

        public Models.Endereco ObterEndereco(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Models.Endereco endereco)
        {
            try
            {
                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO endereco(CEP, Estado, Cidade, Bairro, Logradouro, Complemento, Numero) " +
                        "VALUES (@CEP, @Estado, @Cidade, @Bairro, @Logradouro, @Complemento, @Numero)", conexao);

                    cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = endereco.CEP;
                    cmd.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = endereco.Estado;
                    cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = endereco.Cidade;
                    cmd.Parameters.Add("@Bairro", MySqlDbType.VarChar).Value = endereco.Bairro;
                    cmd.Parameters.Add("@Logradouro", MySqlDbType.VarChar).Value = endereco.Logradouro;
                    cmd.Parameters.Add("@Complemento", MySqlDbType.VarChar).Value = endereco.Complemento;
                    cmd.Parameters.Add("@Numero", MySqlDbType.VarChar).Value = endereco.Numero;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro no banco em cadastro endereco: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação em cadastro endereco: " + ex.Message);
            }
        }

        public void Atualizar(Models.Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        string? IEnderecoRepositorio.ObterTodosEnderecos()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Models.Endereco> IEnderecoRepositorio.GetObterTodosEnderecos()
        {
            return GetObterTodosEnderecos();
        }
    }
}