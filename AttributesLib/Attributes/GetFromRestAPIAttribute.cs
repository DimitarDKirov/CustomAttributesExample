using System;

namespace AttributesLib.Attributes {
    public class GetFromRestAPIAttribute : PropertySetterAttribute {
        public string Url { get; }
        public string Collection { get; }
        public int ID { get; }
        
        public bool HasId { get; }

        public GetFromRestAPIAttribute(string url, string collection) {
            Url = url;
            Collection = collection;
            HasId = false;
        }
        
        public GetFromRestAPIAttribute(string url, string collection, int id) {
            Url = url;
            Collection = collection;
            ID = id;
            HasId = true;
        }
    }
}