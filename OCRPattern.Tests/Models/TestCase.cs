using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OCRPattern.Tests.Models
{
    public class TestCase
    {
        [XmlAttribute] public string File { get; set; }
        [XmlAttribute] public string Expected { get; set; }
        [XmlAttribute] public string Engine { get; set; }
    }
}
