using System;

namespace AttributesLib.Attributes {
    public class RandomValueAttribute : Attribute {
        public object[] Values { get; }

        public RandomValueAttribute(params object[] values) {
            Values = values;
        }
        
    }
}