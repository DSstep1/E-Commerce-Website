using E_commerce_Web_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce_Web_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7024/api/users";

        public UserController()
        {

            _httpClient = new HttpClient();
        }
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            try
            {
                var json = await _httpClient.GetStringAsync(_baseUrl);
                var userList = JsonConvert.DeserializeObject<List<UserDTO>>(json);
                ViewData["Title"] = "UserPage";
                return View(userList);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, "Error fetching user data: " + ex.Message);
            }
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var json = await _httpClient.GetStringAsync(_baseUrl + "/" + id);
            var user = JsonConvert.DeserializeObject<UserDTO>(json);
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserDTO collection)
        {
            try
            {
                await _httpClient.PostAsJsonAsync(_baseUrl, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var json = await _httpClient.GetStringAsync(_baseUrl + "/" + id);
            var user = JsonConvert.DeserializeObject<UserDTO>(json);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UserDTO collection)
        {
            try
            {
                await _httpClient.PutAsJsonAsync(_baseUrl + "/" + id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var json = await _httpClient.GetStringAsync(_baseUrl + "/" + id);
            var user = JsonConvert.DeserializeObject<UserDTO>(json);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, UserDTO collection)
        {
            try
            {
                await _httpClient.DeleteAsync(_baseUrl + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
