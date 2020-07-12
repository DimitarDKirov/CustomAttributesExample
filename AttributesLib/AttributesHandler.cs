using System;
using System.Linq;
using System.Threading.Tasks;
using AttributesLib.Attributes;

namespace AttributesLib {
    public static class AttributesHandler {
        // This would typically happen in OnModelCreating or in an AutoMapperProfile
        public static async Task HandleCustomAttributes(object obj) {
            var type = obj.GetType();

            foreach(var property in type.GetProperties()) {
                var attributes = property.GetCustomAttributes(true);

                var getFromRestApiAttribute =
                    attributes.FirstOrDefault(a => a.GetType() == typeof(GetFromRestAPIAttribute)) as
                        GetFromRestAPIAttribute;
                var getFromCsvAttribute =
                    attributes.FirstOrDefault(a => a.GetType() == typeof(GetFromCSVAttribute)) as GetFromCSVAttribute;
                var randomValueAttribute =
                    attributes.FirstOrDefault(a => a.GetType() == typeof(RandomValueAttribute)) as RandomValueAttribute;

                if(getFromRestApiAttribute != null) {
                    // TODO getFromRestApi for a single item too
                    var restClient = new RESTClient(getFromRestApiAttribute.Url);

                    var getAllMethod = typeof(RESTClient).GetMethod(nameof(RESTClient.GetAll))
                        .MakeGenericMethod(property.PropertyType.GetGenericArguments().First());

                    var itemsTask = getAllMethod.Invoke(restClient, new[] {getFromRestApiAttribute.Collection}) as Task;

                    await itemsTask.ConfigureAwait(false);

                    var resultProperty = itemsTask.GetType().GetProperty("Result");

                    property.SetValue(obj, resultProperty.GetValue(itemsTask));
                }

                if(getFromCsvAttribute != null) {
                    var csvParser = new CSVParser(getFromCsvAttribute.CsvLocation);
                    var idProperty = type.GetProperty(getFromCsvAttribute.IDProperty);
                    var id = (int) idProperty.GetValue(obj);

                    property.SetValue(obj, csvParser.GetData(id, getFromCsvAttribute.Index));
                }

                if(randomValueAttribute != null) {
                    var random = new Random();
                    var randomIndex = random.Next(randomValueAttribute.Values.Length);

                    property.SetValue(obj, randomValueAttribute.Values[randomIndex]);
                }
            }

            foreach(var property in type.GetProperties()) {
                var attributes = property.GetCustomAttributes(true);

                var getFromMethodAttribute =
                    attributes.FirstOrDefault(a => a.GetType() == typeof(GetFromMethodAttribute)) as
                        GetFromMethodAttribute;

                if(getFromMethodAttribute != null) {
                    var methodInfo = type.GetMethod(getFromMethodAttribute.Method);

                    property.SetValue(obj, methodInfo.Invoke(obj, null));
                }
            }
        }
    }
}