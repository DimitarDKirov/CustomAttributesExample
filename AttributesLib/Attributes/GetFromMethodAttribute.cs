namespace AttributesLib.Attributes {
    public class GetFromMethodAttribute : PropertySetterAttribute {
        public string Method { get; }

        public GetFromMethodAttribute(string method) {
            Method = method;
        }
        
    }
}