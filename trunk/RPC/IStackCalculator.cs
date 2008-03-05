using System;
namespace RPC
{
    /// <summary>
    /// Defines the interface for a Reverse Polish notation calculator 
    /// for double values whose memory model is a LIFO stack.
    /// </summary>
    public interface IStackCalculator
    {
        /// <summary>
        /// Gets the current result of the calculation.
        /// </summary>
        double Result { get; }

        /// <summary>
        /// Gets the number of double values in the Calculator's memory.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Indicates whether the Calculator has at least two operands
        /// for an arithmetic operator to use.
        /// <para>
        /// Ensures: returns true if this.Count &gt;= 2
        /// </para>
        /// </summary>
        bool HasOperands { get; }

        /// <summary>
        /// Gets from the calculator's memory the value that will be
        /// used as the first operand for the next arithmetic operation.
        /// <para>
        /// Requires: this.HasOperands == true
        /// </para>
        /// </summary>
        double FirstOperand { get; }

        /// <summary>
        /// Gets from the calculator's memory the value that will be
        /// used as the first operand for the next arithmetic operation.
        /// <para>
        /// Requires: this.HasOperands == true
        /// </summary>
        double SecondOperand { get; }


        /// <summary>
        /// Saves a value into the Calculator's memory.
        /// <para>
        /// Ensures: 
        /// (this.Count == this.Count' + 1) &&
        /// (this.HasOperands' => this.SecondOperand == aNumber &&
        ///                       this.FirstOperand == this.SecondOperand')
        /// </para>
        /// </summary>
        /// <param name="aNumber">
        /// The double to be saved.
        /// </param>
        void StoreOperand(double aNumber);

        /// <summary>
        /// Empties the Calculator's memory.
        /// <para>
        /// Ensures: this.Count == 0
        /// </para>
        /// </summary>
        void ClearMemory();

        /// <summary>
        /// Adds this.FirstOperand and this.SecondOperand.
        /// <para>
        /// Requires: this.HasOperands == true
        /// </para>
        /// <para>
        /// Ensures: this.Result == this.FirstOperand + this.SecondOperand
        /// </para>
        /// </summary>
        void Add();

        /// <summary>
        /// Divides this.FirstOperand by this.SecondOperand.
        /// <para>
        /// Requires: this.HasOperands == true
        /// </para>
        /// <para>
        /// Ensures: this.Result == this.FirstOperand / this.SecondOperand
        /// </para>
        /// </summary>
        void Divide();

        /// <summary>
        /// Multiplies this.FirstOperand by this.SecondOperand.
        /// <para>
        /// Requires: this.HasOperands == true
        /// </para>
        /// <para>
        /// Ensures: this.Result == this.FirstOperand * this.SecondOperand
        /// </para>
        /// </summary>
        void Multiply();

        /// <summary>
        /// Raises this.FirstOperand to the this.SecondOperand power.
        /// <para>
        /// Requires: this.HasOperands == true
        /// </para>
        /// <para>
        /// Ensures: this.Result == Math.Pow(this.this.FirstOperand,  
        ///                                    this.SecondOperand
        /// </para>
        /// </summary>
        void RaiseToPower();

        /// <summary>
        /// Subtracts this.SecondOperandfrom this.FirstOperand.
        /// <para>
        /// Requires: this.HasOperands == true
        /// </para>
        /// <para>
        /// Ensures: this.Result == this.FirstOperand - this.SecondOperand
        /// </para>
        /// </summary>
        void Subtract();
    }
}
