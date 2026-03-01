using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class ModeloDA : IModeloDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructor
        public ModeloDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<IEnumerable<ModeloResponse>> Obtener()
        {
            string query = @"ObtenerModelos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ModeloResponse>(query);
            return resultadoConsulta;
        }

        public async Task<ModeloResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerModelo";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ModeloResponse>(query,
                new { Id = Id });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<IEnumerable<ModeloResponse>> ObtenerPorMarca(Guid IdMarca)
        {
            string query = @"ObtenerModelosPorMarca";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ModeloResponse>(query,
                new { IdMarca = IdMarca });
            return resultadoConsulta;
        }
        #endregion

        #region Helpers
        private async Task VerificarModeloExiste(Guid Id)
        {
            ModeloResponse? resultadoConsultaModelo = await Obtener(Id);
            if (resultadoConsultaModelo == null)
                throw new Exception("No se encontro el modelo");
        }
        #endregion
    }
}