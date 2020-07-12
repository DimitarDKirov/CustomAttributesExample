using System.Collections.Generic;
using AttributesLib.Attributes;

namespace AttributesLib.Model {
    public class Employee {
        public int ID { get; }
        
        [RandomValue(2, 3, 5, 12)]
        public int RandomNumber { get; internal set; }
        
        [RandomValue("Hello", "World", "Ninja")]
        public string RandomString { get; internal set; }
        
        [GetFromCSV("CSVs/Addresses.csv", 4)]
        public string State { get; internal set; }
                
        [GetFromCSV("CSVs/Cities.csv", 8)]
        public string City { get; internal set; }
        
        [GetFromRestAPI("https://jsonplaceholder.typicode.com", "posts")]
        public List<BlogPost> BlogPosts { get; internal set; }
        
        [GetFromMethod(nameof(Employee.GenerateEmployeeString))]
        public string EmployeeString { get; internal set; }

        internal Employee(int id) {
            ID = id;
        }

        public string GenerateEmployeeString() {
            return $"{ID}, {RandomNumber}, {RandomString}, {State}, {BlogPosts.Count} Posts";
        }
        
    }
}