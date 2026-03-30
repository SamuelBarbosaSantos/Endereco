namespace Endereco.Repositorio.Contrato
{
    public interface IEnderecoRepositorio
    {
        //CRUD
        void Cadastrar(Models.Endereco endereco);
        void Atualizar(Models.Endereco endereco);

        void Excluir(int id);
        Models.Endereco ObterEndereco(int id);

        IEnumerable<Models.Endereco> ObterTodosEnderecos { get; }
    }
}
