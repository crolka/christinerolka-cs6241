using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace RPC
{
    public class StackCalculator : RPC.IStackCalculator
    {
        #region Data members

        private Stack<double> theStack;
        private double topNumberFromStack;
        private double secondNumberFromStack;

        #endregion

        #region Implementation of ICalculator properties

        public double Result
        {
            get
            {
                if (this.Count > 0)
                {
                    return this.theStack.Peek();
                }
                else
                {
                    return double.NaN;
                }
            }
        }

        public int Count
        {
            get
            {
                return this.theStack.Count;
            }
        }

        public bool HasOperands
        {
            get
            {
                return this.theStack.Count >= 2;
            }
        }

        public double FirstOperand 
        {
            get
            {
                Trace.Assert(this.HasOperands, 
                             "Invalid property access: not enough operands");
                double stackTopValue = this.theStack.Pop();
                double firstOperand = this.theStack.Peek();
                this.theStack.Push(stackTopValue);
                return firstOperand;
            }
        }

        public double SecondOperand 
        {
            get
            {
                Trace.Assert(this.HasOperands,
                             "Invalid property access: not enough operands");
                return this.theStack.Peek();
            }
        }

        #endregion


        #region Constructor

        /// <summary>
        /// Creates an instance of StackCalculator.
        /// <para>
        /// Ensures: this.Count == 0
        /// </para>
        /// </summary>
        public StackCalculator()
        {
            this.theStack = new Stack<double>();
        }

        #endregion


        #region Implementations of ICalculator methods
		
        public void StoreOperand(double aNumber)
        {
            this.theStack.Push(aNumber);
        }

        public void ClearMemory()
        {
            this.theStack.Clear();
        }

        public void Add()
        {
            this.PopNumbersOffStack();
            this.theStack.Push(this.secondNumberFromStack +         
                                this.topNumberFromStack);
        }

        public void Subtract()
        {
            this.PopNumbersOffStack();
            this.theStack.Push(this.secondNumberFromStack - 
                                this.topNumberFromStack);
        }

        public void Multiply()
        {
            this.PopNumbersOffStack();
            this.theStack.Push(this.secondNumberFromStack * 
                                this.topNumberFromStack);
        }

        public void Divide()
        {
            this.PopNumbersOffStack();
            this.theStack.Push(this.secondNumberFromStack / 
                                this.topNumberFromStack);
        }

        public void RaiseToPower()
        {
            this.PopNumbersOffStack();
            this.theStack.Push(Math.Pow(this.secondNumberFromStack, 
                                          this.topNumberFromStack));
        }

 
	    #endregion        
        
        #region Private helper method

        private void PopNumbersOffStack()
        {
            Trace.Assert(this.HasOperands,
                         "Invalid arithmetic operator: not enough operands");
            this.topNumberFromStack = this.theStack.Pop();
            this.secondNumberFromStack = this.theStack.Pop();
        }

        #endregion

    }
}
