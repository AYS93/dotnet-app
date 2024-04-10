namespace SharedRepository
{
    public interface IRepository<T>
    {
        void Insert(T data);
        void Update(int id, T data);
        void Delete(int id);
    }
}
