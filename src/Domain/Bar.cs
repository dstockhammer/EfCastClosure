namespace EfCastClosure.Domain
{
    public class Bar
    {
        private readonly int _value;

        public Bar(int value)
        {
            _value = value;
        }

        public string Value => _value.ToString();

        public override string ToString() => Value;

        public static implicit operator string(Bar bar) => bar.Value;

        public Bar Clone() => new Bar(_value);
    }
}