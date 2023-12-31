using System.Xml.Serialization;

namespace TransactEase.Core.ValueObjects;

public enum AccountType
{
    
    [XmlEnum("")]
    Undefined,
    [XmlEnum("GIRO")]
    Giro,
    [XmlEnum("IBAN")]
    Iban
}