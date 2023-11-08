namespace artvibe_oracle.Infraestructura.Base
{
    public interface IExceptionHandler
    {
        string GetMessage(Exception ex);
    }
}
