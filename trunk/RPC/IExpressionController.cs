using System;
namespace RPC
{
    public interface IExpressionController
    {
        /// <summary>
        /// Gets the calculator used to evaluate the expression.
        /// </summary>
        IStackCalculator TheCalculator
        {
            get;
        }


        /// <summary>
        /// Performs the calculation defined by the given expression.
        /// <para>
        /// Ensures: this.TheCalculator.Result == 
        ///                 the result of anExpresson's calculation
        /// </para>
        /// </summary>
        /// <param name="anExpression">
        /// The Reverse Polish notation expression to be evaluated.
        /// </param>
        void Evaluate(string anExpression);
    }
}
