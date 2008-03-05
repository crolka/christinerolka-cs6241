using System;
using System.Collections.Generic;
using System.Text;

namespace RPC
{
    public class OperatorController: IOperatorController
    {
        private IStackCalculator theCalculator;

        
        public IStackCalculator TheCalculator
        {
            get 
            { 
                return theCalculator; 
            }
        }

        /// <summary>
        /// Creates an instance of OperatorController.
        /// <para>
        /// Ensures: this.TheCalculator == theCalculator
        /// </para>
        /// </summary>
        /// <param name="theCalculator">
        /// The calculator that will perform the operation.
        /// </param>
        public OperatorController(IStackCalculator theCalculator)
        {
            this.theCalculator = theCalculator;
        }


        public void Execute(OperatorDelegate theOperator)
        {
            
            if (this.theCalculator.HasOperands)
            {
                theOperator();
            }
            else
            {
                this.theCalculator.ClearMemory();
            }

        }
    }
}
