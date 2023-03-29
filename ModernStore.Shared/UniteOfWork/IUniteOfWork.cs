namespace ModernStore.Shared.UniteOfWork
{
    public interface IUniteOfWork
    {
        void Commit();

        void Rollback(); 
    }
}
