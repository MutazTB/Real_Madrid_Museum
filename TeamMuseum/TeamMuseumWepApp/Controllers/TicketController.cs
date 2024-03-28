using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using TeamMuseum.Services.Dtos;

namespace TeamMuseumWepApp.Controllers
{
    public class TicketController : Controller
    {
        private readonly IConfiguration _configuration;

        public TicketController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var token = Request.Cookies["access_token"];
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer ", token);
                }
                HttpResponseMessage response = await client.GetAsync(_configuration.GetValue<string>("ApiUrl:apiUrl" + "Ticket/GetAll"));
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var ticketResponse = JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    return View(ticketResponse);
                }
            }
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            List<TicketDto> returnResult = new List<TicketDto>();
            var token = Request.Cookies["access_token"];
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( token);
                }
                HttpResponseMessage response = await client.GetAsync("https://localhost:7295/api/Ticket/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    returnResult = JsonConvert.DeserializeObject<List<TicketDto>>(data);
                    return Ok(returnResult);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {
            var token = Request.Cookies["access_token"];
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer ", token);
                }
                HttpResponseMessage response = await client.GetAsync(_configuration.GetValue<string>("ApiUrl:apiUrl") + "Ticket/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var ticketResponse = JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    return View(ticketResponse);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketDto ticketDto)
        {
            var token = Request.Cookies["access_token"];
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer ", token);
                }
                //client.BaseAddress = new Uri(_configuration.GetValue<string>("ApiUrl:apiUrl") + "");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string jsonTicket = JsonConvert.SerializeObject(ticketDto);
                var content = new StringContent(jsonTicket, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(_configuration.GetValue<string>("ApiUrl:apiUrl") + "Ticket", content);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var createTicketResponse = JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    return RedirectToAction(nameof(Index));
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketDto ticketDto)
        {
            var token = Request.Cookies["access_token"];
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer ", token);
                }
                string jsonTicket = JsonConvert.SerializeObject(ticketDto);
                var content = new StringContent(jsonTicket, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(_configuration.GetValue<string>("ApiUrl:BaseUrl") + "Ticket", content);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var createTicketResponse = JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    return Ok(createTicketResponse);
                }
            }
            return BadRequest();
        }
    }
}
