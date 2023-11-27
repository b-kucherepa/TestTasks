namespace TestTasks.SearchTests
{
    public class DummyData
    {
        private int _id;
        private int _position;

        public int Id { get => _id; }
        public int Position { get => _position;  }

        public DummyData(int id, int position)
        {
            _id = id;
            _position = position;
        }
    }
}
