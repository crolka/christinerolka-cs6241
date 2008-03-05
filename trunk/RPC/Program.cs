using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RPC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            IStackCalculator theCalculator = 
                                    new CalculatorFactory().Create();
            IOperatorController theArithmeticController = 
                                    new OperatorController(theCalculator);
            IExpressionController theExpressionController = 
                                    new ExpressionController(
                                            theArithmeticController,
                                            theCalculator);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RpcForm(theCalculator, 
                                        theArithmeticController,
                                        theExpressionController));
        }
    }
}