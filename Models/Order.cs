namespace BreadyToomy.Models
{
    public class Order
    {
        private int _id;
        private int _number;
        private string _type;
        private string _state;

        public int Id { get { return _id; } set { _id = value; } }
        public int Number { get { return _number; } set { _number = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string State { get { return _state; } set { _state = value; } }

    }
}
