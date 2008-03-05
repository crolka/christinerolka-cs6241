using System;
using System.Collections.Generic;
using System.Text;

namespace RPC
{
    public class ExpressionController : IExpressionController
    {
        #region Data members

        private IOperatorController theArithmeticController;
        private IStackCalculator theCalculator;
        private string theExpression;
        private string[] tokens; 

        #endregion


        #region Implementation of IExpressionController property

        public IStackCalculator TheCalculator
        {
            get
            {
                return theCalculator;
            }
        }

        #endregion


        #region Constructor

        /// <summary>
        /// Creates an instance of ExpressionController.
        /// <para>
        /// Ensures: this.TheCalculator == theCalculator
        /// </para>
        /// </summary>
        /// <param name="theArithmeticController">
        /// The controller that will direct the execution of each
        /// operator in an expression to be evaluated.
        /// </param>
        /// <param name="theCalculator">
        /// The calculator that will perform the operations
        /// defined by an evaluated expression.
        /// </param>     
        public ExpressionController(
                        IOperatorController theArithmeticController,
                        IStackCalculator theCalculator)
        {
            this.theArithmeticController = theArithmeticController;
            this.theCalculator = theCalculator;
            this.tokens = null;
        }

        #endregion


        #region Implementation of IExpressionController method

        public void Evaluate(string anExpression)
        {
            this.theExpression = anExpression;
            this.TokenizeExpression();
            this.EvaluateTokens();

        }

        #endregion


        #region Private helper methods

        // Breaks the expression up into an array of strings
        private void TokenizeExpression()
        {
            this.tokens = this.theExpression.Split(null);
        }

        // Determines whether each token is an operator or an operand,
        // If it is an operator, directs theArithmeticController to
        // carry out the operation. If it is an operand, calls 
        // this.StoreOperand().
        private void EvaluateTokens()
        {
            foreach (string token in this.tokens)
            {
                switch (token)
                {
                    case "-":
                        this.theArithmeticController.Execute(this.theCalculator.Subtract);
                        break;
                    case "+":
                        this.theArithmeticController.Execute(this.theCalculator.Add);
                        break;
                    case "X":
                    case "x":
                        this.theArithmeticController.Execute(this.theCalculator.Multiply);
                        break;
                    case "/":
                        this.theArithmeticController.Execute(this.theCalculator.Divide);
                        break;
                    case "^":
                        this.theArithmeticController.Execute(this.theCalculator.RaiseToPower);
                        break;
                    default:
                        StoreOperand(token);
                        break;
                }
            }
        }

        // If the token is a valid operand, directs this.theCalculator
        // to store it. If the token is invalid, the expression being
        // evaluated is syntactically incorrect, so directs 
        // this.theCalculator to clear its memory.
        private void StoreOperand(string token)
        {
            double theNumberEntered = 0.0;

            try
            {
                theNumberEntered = Convert.ToDouble(token);
                this.theCalculator.StoreOperand(theNumberEntered);
            }
            catch (Exception)
            {
                this.theCalculator.ClearMemory();
            }
        } 

        #endregion


    }
}
