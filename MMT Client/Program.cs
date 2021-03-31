using MMT_Client.Utility;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MMT_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            try
            {
                IDisplayResult displayResult = null;
                FactoryDisplay factoryDisplay = new FactoryDisplay();
                HttpResponseMessage response = new HttpResponseMessage();
                string userChoice = "";

                do
                {
                    Console.WriteLine("1.All Products ");
                    Console.WriteLine("2.Products By CategoryId ");
                    Console.WriteLine("3.All Category ");
                    Console.WriteLine("\n");
                    Console.WriteLine("Please enter your choice either 1,2 or 3 ");

                    var userOption = Convert.ToInt32(Console.ReadLine());

                    ResultType resultType = (ResultType)Enum.ToObject(typeof(ResultType), userOption);

                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("https://localhost:44384/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        //Get DisplayResult(i.e.ShowAllProducts) object from factory class.
                        displayResult = factoryDisplay.GetDisplayResultType(resultType);

                        if (displayResult != null)
                        {
                            //Get response from api.
                            response = await displayResult.GetResponse(client);

                            //Display in console.
                            displayResult.Display(response);

                        }
                    }

                    do
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Do you want to continue - yes or no?");
                        userChoice = Console.ReadLine();

                        if (userChoice != "yes" && userChoice != "no")
                        {
                            Console.WriteLine("Invalid choice, please say yes or no");
                        }

                    } while (userChoice != "yes" && userChoice != "no");

                } while (userChoice == "yes");
            }
            catch (UriFormatException ex)
            {
                Console.WriteLine("Your Web Api Url is incorrect:: {0}", ex.Message);
                Console.ReadLine();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Check whether your Web Api is running or not:: {0}", ex.Message);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is some error/exception:: {0}", ex.Message);
                Console.ReadLine();
            }
        }
    }
}
