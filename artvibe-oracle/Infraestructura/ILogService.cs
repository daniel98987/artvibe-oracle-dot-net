namespace artvibe_oracle.Infraestructura
{
    public interface ILogService
    {
        void Error(Exception ex);

        void Debug(Exception ex);

        void Fatal(Exception ex);

        void Info(Exception ex);

        void Warn(Exception ex);
    }
}
