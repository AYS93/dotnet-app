namespace SharedRepository
{
    public interface IRepositories<T>
    {
        void Insert(T data);
        void Update(int id, T data);
        void Delete(int id);
    }
}
