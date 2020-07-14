using System.Threading.Tasks;
using AttributesLib.Model;

namespace AttributesLib {
    public abstract class EntityFactory<T> where T : IEntity, new() {
        public virtual async Task<T> Create(int id) {
            var objectInstance = new T {ID = id};

            await AttributesHandler.HandleCustomAttributes(objectInstance);
            
            return objectInstance;
        }
        
    }
}