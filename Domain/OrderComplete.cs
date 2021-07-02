using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class OrderComplete : OrderState
    {
        public override OrderStates State => OrderStates.Complete;
        public OrderComplete(OrderHeader orderHeader):base(orderHeader)
        {

        }
        /// <summary>
        /// Override Complete method 
        /// </summary>

        public override void Complete()
        {
            throw new InvalidOrderStateException("You Can't Change The Order State, because it is Completed!");
        }
        /// <summary>
        /// Override Reject method 
        /// </summary>
        public override void Reject()
        {
            throw new InvalidOrderStateException("You Can't Change The Order State to Rejected, because it is Completed!");
        }
        /// <summary>
        /// Override Submit method 
        /// </summary>
        public override void Submit()
        {
            throw new InvalidOrderStateException("You Can't Change The Order State to Pending, because it is Completed!");
        }
    }
}
