using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using Dapper;

namespace estacionamento.Repositorios
{
    public class RepositorioDapper<T> : IRepositorio<T>
    {
        private readonly IDbConnection _conexao;
        private readonly string _nomeTabela;

        public RepositorioDapper(IDbConnection conexao)
        {
            _conexao = conexao;
            _nomeTabela = ObterNomeTabela();
        }

        private string ObterNomeTabela(){
            var tipo = typeof(T);
            var atributoTabela = tipo.GetCustomAttribute<TableAttribute>();
            if(atributoTabela != null){
                return atributoTabela.Name;
            }
            return tipo.Name;
        }
        public void Atualizar(T entidade)
        {
            var campos = ObterCamposUpdate(entidade);
            var sql = $"Update {_nomeTabela} Set {campos} where Id = @Id";
            _conexao.Execute(sql,entidade);
        }

        public string ObterCamposUpdate(T entidade){
            var tipo = typeof(T);
            var propriedades = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var atualizaCampos = propriedades.Select(p => $"{p.Name} = @{p.Name}");
            return string.Join(", ", atualizaCampos);
        }

        public void Excluir(int id)
        {
            var sql = $"Delete from {_nomeTabela} where Id = @Id";
            _conexao.Execute(sql, new{ Id = id });
        }

        public void Inserir(T entidade)
        {
            var campos = ObterCamposInsert(entidade);
            var valores = ObterValoresInsert(entidade);
            var sql = $"Insert into {_nomeTabela} ({campos}) Values ({valores})";
            _conexao.Execute(sql,entidade);
        }

        public string ObterCamposInsert(T entidade){
            var tipo = typeof(T);
            var propriedades = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var nomesCampos = propriedades.Select(p => p.Name);
            return string.Join(", ", nomesCampos);
        }

        public string ObterValoresInsert(T entidade){
            var tipo = typeof(T);
            var propriedades = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var valoresCampos = propriedades.Select(p => $"@{p.Name}");
            return string.Join(", ", valoresCampos);
        }

        public T ObterPorId(int id)
        {
            var sql = $"Select * from {_nomeTabela} where Id = @Id";
            return _conexao.QueryFirstOrDefault<T>(sql, new { Id = id });
        }

        public IEnumerable<T> ObterTodos()
        {
            var sql = $"Select * from {_nomeTabela}";
            return _conexao.Query<T>(sql);
        }
    }
}