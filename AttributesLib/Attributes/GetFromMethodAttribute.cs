using System;

namespace AttributesLib.Attributes {
    public class GetFromMethodAttribute : Attribute {
        public string Method { get; }

        public GetFromMethodAttribute(string method) {
            Method = method;
        }
        
    }
}