using MMT_Client.Utility.CategoryResult;
using MMT_Client.Utility.ProductResult;
using System;

namespace MMT_Client.Utility
{
    public class FactoryDisplay
    {
        public IDisplayResult GetDisplayResultType(ResultType resultType)
        {
            IDisplayResult displayResult = null;

            switch (resultType)
            {
                case ResultType.AllProduct:
                    displayResult = new ShowAllProduct();

                    break;
                case ResultType.ProductByCategory:
                    Console.WriteLine("Please Enter your CategoryId");
                    var categoryId = Convert.ToInt32(Console.ReadLine());
                    displayResult = new ShowAllProductByCategory(categoryId);

                    break;
                case ResultType.AllCategory:
                    displayResult = new ShowAllCategory();
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            return displayResult;

        }

    }
}
