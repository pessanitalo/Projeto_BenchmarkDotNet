using BenchmarkDotNet.Attributes;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace projeto_BenchmarkDotNet
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        DataContext context = new DataContext();

        [Benchmark]
        public void buscaDapper()
        {
            using (IDbConnection db = new SqlConnection("Server=localhost,1433;Database=teste-praticodb;User Id=sa;Password=Numsey#2021;TrustServerCertificate=True"))
            {
                var query = @"SELECT Id, Cidades, Sigla from Cidades WHERE Cidades = @Cidades";
                var parametros = new { Cidades = "Santo Andre" };

                //var listaAsync = await conection.QueryAsync<Cidade>(query);
                db.Query<Cidade>(query, parametros).ToList();

            }
        }

        [Benchmark]
        public async Task buscaEntity()
        {
            await context.Cidades.Where(p => p.Cidades == "Santo Andre").ToListAsync();
        }

        [Benchmark]
        public void buscaNormal()
        {
            context.Cidades.Where(p => p.Cidades == "Santo Andre").ToList();
        }

        [Benchmark]
        public void buscaLinq()
        {
            var endereco = from e in context.Cidades where e.Cidades == "Santo Andre" select e;
        }
    }
}