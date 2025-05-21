
namespace IPSys
{
    internal class InputTable<T> : Control
    {
        public DockStyle Dock { get; set; }
        public object Columns { get; set; }
        public Func<object, string> DisplayTextFormatter { get; set; }
        public object DataSource { get; set; }
    }
}