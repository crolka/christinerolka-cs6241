using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace RPC
{
    public class ArrayCalculator: IStackCalculator
    {
        #region Constant

        public const int stackSize = 10;

        #endregion

        #region Data members

        private double[] theStackArray;
        private int count;

        #endregion

        #region Implementation of IStackCalculator Properties

        public double Result
        {
            get
            {
                if (this.Count > 0)
                {
                    return this.theStackArray[this.Count - 1];
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
                return this.count;
            }            
        }

        public bool HasOperands
        {
            get
            {                
                return this.Count >= 2;
            }
        }

        public double FirstOperand
        {
            get
            {
                Trace.Assert(this.HasOperands,
                             "Invalid property access: not enough operands");
                return this.theStackArray[this.Count - 2];
            }
        }

        public double SecondOperand
        {
            get
            {
                Trace.Assert(this.HasOperands,
                             "Invalid property access: not enough operands");
                return this.theStackArray[this.Count - 1];
            }
        }

        #endregion



        #region Constructor

        public ArrayCalculator()
        {
            this.theStackArray = new double[ArrayCalculator.stackSize];
            this.count = 0;
            this.ClearMemory();
        }
        
        #endregion



        #region Implementation of IStackCalculator methods

        public void StoreOperand(double aNumber)
        {
            this.theStackArray[this.Count] = aNumber;
            this.count++;
        }

        public void ClearMemory()
        {
            this.count = 0;
        }

        public void Add()
        {
            Trace.Assert(this.HasOperands,
                         "Invalid add operator: not enough operands");
            this.theStackArray[this.Count - 2] =
                                    this.theStackArray[this.Count - 2] + 
                                    this.theStackArray[this.Count - 1];
            this.count--;
        }

        public void Divide()
        {
            Trace.Assert(this.HasOperands,
                         "Invalid divide operator: not enough operands");
            this.theStackArray[this.Count - 2] =
                                    this.theStackArray[this.Count - 2] /
                                    this.theStackArray[this.Count - 1];
            this.count--;
        }

        public void Multiply()
        {
            Trace.Assert(this.HasOperands,
                         "Invalid multiply operator: not enough operands");
            this.theStackArray[this.Count - 2] =
                                    this.theStackArray[this.Count - 2] *
                                    this.theStackArray[this.Count - 1];
            this.count--;
        }

        public void RaiseToPower()
        {
            Trace.Assert(this.HasOperands,
                         "Invalid power operator: not enough operands");
            this.theStackArray[this.Count - 2] = Math.Pow(
                                    this.theStackArray[this.Count - 2],
                                    this.theStackArray[this.Count - 1]);
            this.count--;
        }

        public void Subtract()
        {
            Trace.Assert(this.HasOperands,
                         "Invalid subtract operator: not enough operands");
            this.theStackArray[this.Count - 2] =
                                    this.theStackArray[this.Count - 2] -
                                    this.theStackArray[this.Count - 1];
            this.count--;
        }

        #endregion
    }
}
