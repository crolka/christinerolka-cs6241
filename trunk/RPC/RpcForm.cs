using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RPC
{    
    public partial class RpcForm : Form
    {
        #region Data members

        private string numberBeingEntered;
        private bool enteringExpressionToEvaluate;

        private IStackCalculator theCalculator;

        private IOperatorController theArithmeticController;
        private IExpressionController theExpressionController;


        #endregion

        #region Constructor

        public RpcForm(IStackCalculator theCalculator,
                       IOperatorController theArithmeticController,
                       IExpressionController theExpressionController)
        {
            InitializeComponent();

            this.numberBeingEntered = "";
            this.enteringExpressionToEvaluate = false;

            this.theCalculator = theCalculator;

            this.theArithmeticController = theArithmeticController;
            this.theExpressionController = theExpressionController;
        }

        #endregion


        #region Handlers for GUI-only events

        private void zeroButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('0');
        }

        
        private void decimalButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('.');
            this.decimalButton.Enabled = false;
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('1');
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('2');
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('3');
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('4');
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('5');
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('6');
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('7');
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('8');
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            this.UpdateNumberEnteredAndTextBox('9');
        }

        private void clearEntryButton_Click(object sender, EventArgs e)
        {
            this.numberBeingEntered = "";
            this.displayTextBox.Clear();
            this.decimalButton.Enabled = true;
        }

        private void spaceButton_Click(object sender, EventArgs e)
        {
            if (this.numberBeingEntered.Length > 0)
            {
                this.UpdateNumberEnteredAndTextBox(' ');

                // Number after the space may have a decimal, so enable the button
                this.decimalButton.Enabled = true;

                // If entered a space, must be entering an expression, not single operations
                //this.enteringExpressionToEvaluate = true;
                //this.expressionButton.Enabled = true;
                //this.enterButton.Enabled = false; 
            }
        }


        private void backspaceButton_Click(object sender, EventArgs e)
        {
            this.numberBeingEntered =
                    this.displayTextBox.Text.Remove(this.displayTextBox.Text.Length - 1);
            this.displayTextBox.Text = this.numberBeingEntered;
            if (!this.numberBeingEntered.Contains("."))
            {
                this.decimalButton.Enabled = true;
            }
        }

        
        #endregion


        #region Handlers for calculator events

        private void enterButton_Click(object sender, EventArgs e)
        {
            double theNumberEntered = 0.0;

            try
            {
                theNumberEntered = Convert.ToDouble(this.displayTextBox.Text);
                this.theCalculator.StoreOperand(theNumberEntered);
                this.numberBeingEntered = "";
            }
            catch (InvalidCastException)
            {
                this.numberBeingEntered = "";
                this.displayTextBox.Text = "Invalid number!";
            }
            finally
            {
                this.decimalButton.Enabled = true;
            }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.HandleOperatorButton(this.theCalculator.Add, '+');
        }


        private void subtractButton_Click(object sender, EventArgs e)
        {
            this.HandleOperatorButton(this.theCalculator.Subtract, '-');            
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            this.HandleOperatorButton(this.theCalculator.Multiply, 'X');
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            this.HandleOperatorButton(this.theCalculator.Divide, '/');
        }

        private void exponentButton_Click(object sender, EventArgs e)
        {
            this.HandleOperatorButton(this.theCalculator.RaiseToPower, '^');
        }

        private void clearMemoryButton_Click(object sender, EventArgs e)
        {
            this.theCalculator.ClearMemory();
            this.displayTextBox.Clear();
        }

        private void expressionButton_Click(object sender, EventArgs e)
        {
            
            if (this.enteringExpressionToEvaluate)  // then ready to evaluate
            {
                this.enteringExpressionToEvaluate = false;
                this.expressionButton.Text = "Expression";
                this.enterButton.Enabled = true;
                this.spaceButton.Enabled = false;
                this.expressionLabel.Visible = false;

                this.theExpressionController.Evaluate(displayTextBox.Text);
                this.DisplayResult(); 
            }
            else // set up to enter expression
            {
                this.enteringExpressionToEvaluate = true;
                this.expressionButton.Text = "Evaluate";
                this.enterButton.Enabled = false;
                this.spaceButton.Enabled = true;
                this.displayTextBox.Text = "";
                this.theCalculator.ClearMemory();
                this.expressionLabel.Visible = true;
            }
        }

        #endregion


        #region Helper methods

        private void UpdateNumberEnteredAndTextBox(char charToAdd)
        {
            this.numberBeingEntered += charToAdd;
            this.displayTextBox.Text = this.numberBeingEntered;
        }

        private void DisplayResult()
        {
            this.numberBeingEntered = "";
            this.displayTextBox.Text = this.theCalculator.Result + "";
        }

        private void HandleOperatorButton(OperatorDelegate theOperator,
                                  char operatorSymbol)
        {
            if (!this.enteringExpressionToEvaluate)  // then calculate result
            {
                this.theArithmeticController.Execute(theOperator);
                this.DisplayResult();
            }
            else    // add operator's symbol to the expression
            {
                this.numberBeingEntered += operatorSymbol;
                this.displayTextBox.Text = this.numberBeingEntered;
            }
        }

        #endregion
    }
}