using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class OrderRejected : OrderState
    {
        public override OrderStates State => OrderStates.Rejected;
        public OrderRejected(OrderHeader orderHeader):base(orderHeader)
        {

        }
        /// <summary>
        /// override Complete method
        /// </summary>
        public override void Complete()
        {
            throw new InvalidOrderStateException("Not allow to change the order state from Rejected to Complete. ");
        }
        /// <summary>
        /// override Reject method
        /// </summary>
        public override void Reject()
        {
            throw new InvalidOrderStateException("The Order is Already Rejected!");
        }
        /// <summary>
        /// override Submit method
        /// </summary>
        public override void Submit()
        {
            throw new InvalidOrderStateException("Not allow to change the order state from Rejected to Pending. ");
        }
    }
}
