using CustomerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.Text;

namespace CustomerApp.Controllers
{
    public class CustomerController : Controller
    {
        public string errorMessage = "";
        public string successMessage = "";

        HttpClient client = new HttpClient();
        
        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            client.BaseAddress = new Uri("https://getinvoices.azurewebsites.net/api/Customers");
            var response = client.GetAsync("Customers");
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                string display = test.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(display);
            }
            return View(customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                client.BaseAddress = new Uri("https://getinvoices.azurewebsites.net/api/Customer");
                var response = client.PostAsJsonAsync<Customer>("Customer", customer);
                response.Wait();

                var testresult = response.Result;
                if (testresult.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Customer Added Successfuly !";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Customer customers = new Customer();
            try
            {
                client.BaseAddress = new Uri("https://getinvoices.azurewebsites.net/api/");
                var response = client.GetAsync("Customer/" + Id);
                response.Wait();
                var test = response.Result;

                if (test.IsSuccessStatusCode)
                {
                    string display = test.Content.ReadAsStringAsync().Result;
                    customers = JsonConvert.DeserializeObject<Customer>(display);
                }
                return View(customers);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            try
            {
                string data = JsonConvert.SerializeObject(customer);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("https://getinvoices.azurewebsites.net/api/");
                var response = client.PutAsync("Customer/", stringContent);
                response.Wait();

                var testresult = response.Result;
                if (testresult.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Customer Edited Successfuly !";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                Customer customers = new Customer();
                client.BaseAddress = new Uri("https://getinvoices.azurewebsites.net/api/");
                var response = client.GetAsync("Customers/" + Id);
                response.Wait();
                var test = response.Result;

                if (test.IsSuccessStatusCode)
                {
                    string display = test.Content.ReadAsStringAsync().Result;
                    customers = JsonConvert.DeserializeObject<Customer>(display);
                }
                return View(customers);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(Id);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("https://getinvoices.azurewebsites.net/api/");
                var response = client.DeleteAsync("Customer/"+ Id);
                response.Wait();

                var testresult = response.Result;
                if (testresult.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Customer Deleted !";
                    return RedirectToAction("Index");
                }
               
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
