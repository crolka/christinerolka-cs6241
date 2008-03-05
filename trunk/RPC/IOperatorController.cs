using System;

namespace RPC
{
    public interface IOperatorController
    {
        /// <summary>
        /// The calculator used to perform the arithmetic operation.
        /// </summary>
        IStackCalculator TheCalculator
        {
            get;
        }


        /// <summary>
        /// Performs the arithmetic operation represented 
        /// by the delegate.
        /// <para>
        /// Ensures: this.TheCalculator.Result == 
        ///            the result of anOperator's execution by this.TheCalculator
        /// </para>

        /// </summary>
        /// <param name="anOperator">
        /// Delegate for the method to be performed by this.TheCalculator
        /// </param>
        void Execute(OperatorDelegate anOperator);
    }
}
