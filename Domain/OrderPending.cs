using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class OrderPending : OrderState
    {
        public override OrderStates State => OrderStates.Pending;
        public OrderPending(OrderHeader orderHeader):base(orderHeader)
        {

        }
        /// <summary>
        /// override Complete method
        /// </summary>
        public override void Complete()
        {
            _orderHeader.setState(4);
        }
        /// <summary>
        /// override Reject method
        /// </summary>
        public override void Reject()
        {
            _orderHeader.setState(3);
        }
        /// <summary>
        /// override Submit method
        /// </summary>
        public override void Submit()
        {
            throw new InvalidOrderStateException("The Order State is Already Pending!");
        }
    }
}
