using System;

namespace AttributesLib.Attributes {
    public class GetFromCSVAttribute : PropertySetterAttribute {
        public string CsvLocation { get; }
        public int Index { get; }
        public string IDProperty { get; }

        public GetFromCSVAttribute(string csvLocation, int index, string idProperty = "ID") {
            CsvLocation = csvLocation;
            Index = index;
            IDProperty = idProperty;
        }
    }
}