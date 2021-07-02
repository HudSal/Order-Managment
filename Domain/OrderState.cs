using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum OrderStates { New = 1, Pending = 2, Rejected = 3, Complete = 4 }
    public abstract class OrderState
    {
        protected OrderHeader _orderHeader;

        public abstract OrderStates State { get; }

        public OrderState(OrderHeader orderHeader)
        {
            _orderHeader = orderHeader;
        }
        /// <summary>
        /// abstract Compelte method
        /// </summary>
        public abstract void Complete();
        /// <summary>
        /// abstract Reject method
        /// </summary>
        public abstract void Reject();
        /// <summary>
        /// abstract Submit method
        /// </summary>
        public abstract void Submit();
    }
}
