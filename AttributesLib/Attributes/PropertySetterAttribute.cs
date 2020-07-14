using System;

namespace AttributesLib.Attributes {
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class PropertySetterAttribute : Attribute { }
}