using MMT_Client.Entity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
namespace MMT_Client.Utility.ProductResult
{
    public class ShowAllProductByCategory : IDisplayResult
    {

        public string Uri { get; set; }

        public ShowAllProductByCategory(int categoryId )
        {
            Uri = $"api/category/{categoryId}/product";
        }

        public async Task<HttpResponseMessage> GetResponse(HttpClient client)
        {
            return await client.GetAsync(Uri);
        }

        public async void Display(HttpResponseMessage response)
        {
            try
            {
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var products = await response.Content.ReadAsAsync<List<Product>>();

                        if (products == null || products.Count == 0)
                        {
                            Console.WriteLine("No products found for this category Id");
                        }
                        else
                        {
                            foreach (Product product in products)
                            {
                                Console.WriteLine("{0}\t{1}\t{2}\t{3} GBP", product.Name, product.Category.Name, product.Description, product.Price);
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode);
                    }
                }
                else
                {
                    Console.WriteLine("Technical issue while fetching products");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while fetching all products", ex.Message);
            }

        }
    }
}
