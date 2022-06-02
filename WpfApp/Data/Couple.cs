namespace WpfApp.Data
{
    public class Couple<T, K>
    {
        public T Key { get; set; }
        public K Value { get; set; }

        public Couple(T key, K value)
        {
            Key = key;
            Value = value;
        }
    }
}
