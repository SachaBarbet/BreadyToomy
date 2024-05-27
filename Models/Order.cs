using BreadyToomy.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BreadyToomy.Models
{
    public class Order
    {
        private int _id;
        private int _number;
        private OrderTypes _type;
        private OrderStates _state;

        public int Id { get { return _id; } set { _id = value; } }
        public int Number { get { return _number; } set { _number = value; } }
        public OrderTypes Type { get { return _type; } set { _type = value; } }
        public OrderStates State { get { return _state; } set { _state = value; } }

    }
}
