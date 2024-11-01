using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonPractice
{
    internal class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber {  get; set; }
        public static string PathString = Path.GetFullPath(Path.Combine("..", "..", "..", "Files", "Data", "customers.json"));
        public Customer(int id, string firstname, string lastname, string phonenumber)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = phonenumber;
        }
        private List<Customer> GetJson(string path)
        {
            string newresult;
            using (StreamReader sr = new StreamReader(path))
            {
                newresult = sr.ReadToEnd();
            }
            var customers = JsonConvert.DeserializeObject<List<Customer>>(newresult);
            if (customers == null)
            {
                customers = new List<Customer>();
            }
            return customers;

            }
        void SetJson(string path, List<Customer> customers)
        {
            string result = JsonConvert.SerializeObject(customers);
            using StreamWriter sw = new(path);
            sw.WriteLine(result);
        }
        public void Add(Customer customer)
        {
            var customers = GetJson(PathString);
            customers.Add(customer);
            SetJson(PathString, customers);
        }
        public Customer Search(int id)
        {
            var customers = GetJson(PathString);
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var customers = GetJson(PathString);
            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer != null)
            {
                customers.Remove(customer);
                SetJson(PathString, customers);
                Console.WriteLine($"\n{customer.FirstName} silindi");
            }
            else
            {
                Console.WriteLine("Tapilmadi");
            }
        }

    }
}
