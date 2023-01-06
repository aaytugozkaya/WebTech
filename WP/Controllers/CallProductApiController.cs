using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WP.Models;

namespace WP.Controllers
{
    public class CallProductApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Product> allProducts = new List<Product>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7295/api/ProductApi");
            string resString = await response.Content.ReadAsStringAsync();
            allProducts = JsonConvert.DeserializeObject<List<Product>>(resString);
            return View(allProducts);
        }

        public async Task<IActionResult> ChoosenProduct (int id)
        {
            //List<Product> choosen = new List<Product>();
            Product choosen = new Product();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7295/api/ProductApi/"+id);
            string resString = await response.Content.ReadAsStringAsync();
            choosen = JsonConvert.DeserializeObject<Product>(resString);
            return View(choosen);
        }
    }
}
