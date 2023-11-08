namespace artvibe_oracle.Infraestructura.Utilidades
{
    public class ResponseService : IResponseService
    {
        public List<string> Errores { get; set; }

        public dynamic Resultado { get; set; }

        public bool Estado { get; set; }

        public int TotalItems { get; set; }

        public ResponseService()
        {
            Estado = false;
            Errores = new List<string>();
        }

        public void EstablecerRespuesta(bool estado, dynamic resultado = null, int totalItems = 0)
        {
            Estado = estado;
            Resultado = resultado;
            //Errores = errores ?? Errores;
            TotalItems = totalItems;
        }

        public void EstablecerRespuestaLista(bool estado, dynamic resultado = null)
        {
            Estado = estado;
            Resultado = resultado;
            //Errores = errores ?? Errores;
            try
            {
                TotalItems = resultado != null ? resultado.Count : 0;
            }
            catch (Exception)
            {
                TotalItems = 0;
            }

        }
    }
}
