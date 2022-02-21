using BookMVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookMVC.Controllers
{
    public class GenrController : Controller
    {
        public async Task< IActionResult> Index()
        {
            GenrListDto listDto;

            using (HttpClient client = new HttpClient())
            {
               // string token = Request.Cookies["AuthToken"];

               // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var response = await client.GetAsync("https://localhost:44397/admin/api/book");

                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    listDto = JsonConvert.DeserializeObject<GenrListDto>(responseStr);
                    return View(listDto);
                }
            }

            return RedirectToAction("index", "home");
        }
    }
}
