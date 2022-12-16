namespace JetStream_Service.Utility
{
    public interface IDeepCloneable<T>
    {
        T CreateClone();
    }
}
