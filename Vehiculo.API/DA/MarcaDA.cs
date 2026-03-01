using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class MarcaDA : IMarcaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructor
        public MarcaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion


        #region Operaciones

        public async Task<IEnumerable<MarcaResponse>> Obtener()
        {
            string query = @"ObtenerMarcas";
            var resultadoConsulta = await _sqlConnection.QueryAsync<MarcaResponse>(query);
            return resultadoConsulta;
        }

        public async Task<MarcaResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerMarca";
            var resultadoConsulta = await _sqlConnection.QueryAsync<MarcaResponse>(query, 
                new{Id = Id});
            return resultadoConsulta.FirstOrDefault();

        }
        #endregion
        #region Helpers
        private async Task VerificarMarcaExiste(Guid Id)
        {
            MarcaResponse? resultadoConsultaMarca = await Obtener(Id);
            if (resultadoConsultaMarca == null)
                throw new Exception("No se encontro la marca");
        }
        #endregion

    }
}
