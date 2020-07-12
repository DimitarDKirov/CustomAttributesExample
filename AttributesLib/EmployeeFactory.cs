using System.Threading.Tasks;
using AttributesLib.Model;

namespace AttributesLib {
    public class EmployeeFactory {
        public async Task<Employee> CreateEmployee(int id) {
            var employee = new Employee(id);
            
            await AttributesHandler.HandleCustomAttributes(employee);
            
            return employee;
        }
    }
}