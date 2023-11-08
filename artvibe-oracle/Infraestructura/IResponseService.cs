namespace artvibe_oracle.Infraestructura
{
    public interface IResponseService
    {
        List<string> Errores { get; set; }

        dynamic Resultado { get; set; }

        bool Estado { get; set; }

        int TotalItems { get; set; }

        void EstablecerRespuestaLista(bool estado, dynamic resultado = null);

        void EstablecerRespuesta(bool estado, dynamic resultado = null, int totalItems = 0);
    }
}
