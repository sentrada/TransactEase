using System.Xml.Serialization;

namespace TransactEase.Core.ValueObjects;

public enum ProcessingMode
{
    [XmlEnum("")]
    Undefined,
    [XmlEnum("VIBER")]
    Viber,
}