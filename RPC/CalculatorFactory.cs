using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace RPC
{
    public class CalculatorFactory
    {
        public enum CalculatorChoice
        {
            fast,
            dynamic
        }

        /// <summary>
        /// Creates an object whose class implements the
        /// IStackCalculator interface, using application configuration
        /// settings to determine which class to instantiate.
        /// </summary>
        /// <returns></returns>
        public IStackCalculator Create()
        {
            string calculatorType =
              ConfigurationManager.AppSettings["CalculatorType"].ToLower();

            if (calculatorType.Equals(CalculatorChoice.dynamic.ToString()))
            {
                return new StackCalculator();
            }
            else
            {
                return new ArrayCalculator();
            }
        }
    }
}
