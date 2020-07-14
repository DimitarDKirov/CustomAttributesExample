using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AttributesLib.Tests {
    public class EmployeeFactoryTests
    {
        [Test]
        public async Task CreateEmployee_ReturnsNewEmployee() {
            var employeeFactory = new EmployeeFactory();
            var employee = await employeeFactory.Create(1);
            
            Assert.NotNull(employee);
        }
        
        [Test]
        public async Task CreateEmployee_ReturnsNewEmployee_WithBlogPosts() {
            var employeeFactory = new EmployeeFactory();
            var employee = await employeeFactory.Create(1);
            
            Assert.NotNull(employee.BlogPosts);
            Assert.Greater(employee.BlogPosts.Count, 80);
        }
        
        [Test]
        public async Task CreateEmployee_ReturnsNewEmployee_WithStateCity() {
            var employeeFactory = new EmployeeFactory();
            var employee = await employeeFactory.Create(1);
            
            Assert.NotNull(employee.State);
            Assert.AreEqual(employee.State, "PA");
            Assert.AreEqual(employee.City, "Yankton");
        }
        
        [Test]
        public async Task CreateEmployee_ReturnsNewEmployee_WithRandomValues() {
            var employeeFactory = new EmployeeFactory();
            var employee = await employeeFactory.Create(1);

            var numbers = new[] {2, 3, 5, 12};
            var strings = new[] {"Hello", "World", "Ninja"};
            
            Assert.IsTrue(numbers.Contains(employee.RandomNumber));
            Assert.IsTrue(strings.Contains(employee.RandomString));
        }
        
        [Test]
        public async Task CreateEmployee_ReturnsNewEmployee_WithCalculatedVariable() {
            var employeeFactory = new EmployeeFactory();
            var employee = await employeeFactory.Create(1);

            Assert.AreEqual(employee.GenerateEmployeeString(), employee.EmployeeString);
        }
    }
}