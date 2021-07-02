using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class OrderNew : OrderState
    {
        public override OrderStates State => OrderStates.New;
        public OrderNew(OrderHeader orderHeader):base(orderHeader)
        {

        }
        /// <summary>
        /// override Submit method
        /// </summary>
        public override void Submit()
        {
            if (_orderHeader.OrderItems.Count == 0)
            {
                throw new InvalidOrderStateException("First you have to add at least one item to the order before it can be submitted");
            }
            _orderHeader.setState(2);
        }
        /// <summary>
        /// override Reject method
        /// </summary>
        public override void Reject()
        {
            throw new InvalidOrderStateException("First the order must be sumitted (pending) before it can be rejected.");
        }
        /// <summary>
        /// override Complete method
        /// </summary>
        public override void Complete()
        {
            throw new InvalidOrderStateException("First the order must be sumitted (pending) before it can be completed.");
        }
    }
}
