namespace RainOfCube
{
    public interface IObjectPool<T> where T : class
    {
        public void Despawn(T target);
    }
}


