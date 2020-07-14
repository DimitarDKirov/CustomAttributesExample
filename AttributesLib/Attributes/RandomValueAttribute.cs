using System;

namespace AttributesLib.Attributes {
    public class RandomValueAttribute : PropertySetterAttribute {
        public object[] Values { get; }

        public RandomValueAttribute(params object[] values) {
            Values = values;
        }
        
    }
}