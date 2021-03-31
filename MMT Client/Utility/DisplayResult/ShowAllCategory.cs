using MMT_Client.Entity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMT_Client.Utility.CategoryResult
{
    public class ShowAllCategory : IDisplayResult
    {
        public string Uri { get; set; }

        public ShowAllCategory()

        {
            Uri = "api/category";
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
                        var categories = await response.Content.ReadAsAsync<List<Category>>();

                        if (categories == null || categories.Count == 0)
                        {
                            Console.WriteLine("No categories found");
                        }
                        else
                        {
                            foreach (Category category in categories)
                            {
                                Console.WriteLine("{0}", category.Name);
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
                    Console.WriteLine("Technical issue while fetching categories");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while fetching all categories", ex.Message);
            }

        }

       
    }
}
