using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ProyectoFinal.Models;

namespace ProyectoFinal.DAL
{
    public class DuenoDAL
    {
        private readonly AppDbConnection _db;

        public DuenoDAL(AppDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Dueno>> Listar()
        {
            using var connection = _db.CreateConnection();
            return await connection.QueryAsync<Dueno>(
                "sp_Dueno_Listar",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task Insertar(Dueno dueno)
        {
            using var connection = _db.CreateConnection();
            await connection.ExecuteAsync(
                "sp_Dueno_Insertar",
                new
                {
                    dueno.Nombre,
                    dueno.Telefono,
                    dueno.Correo
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
