using Newtonsoft.Json;

namespace JsonPractice
{
    internal class Program
    {
        public static string PathString;

        List<Customer> customers = new List<Customer>();
          static void Main(string[] args)
        {
            
            Directory.CreateDirectory(@"C:\Users\User\OneDrive\Desktop\Documents\SecondProject\JsonPractice\JsonPractice\Data");
            File.Create(@"C:\Users\User\OneDrive\Desktop\Documents\SecondProject\JsonPractice\JsonPractice\Data\customers.json");

            Customer customer = new Customer(1, "Sam", "Gilbert", "666");
            Customer.Add(customer, customer);
        }
        

    }
}
