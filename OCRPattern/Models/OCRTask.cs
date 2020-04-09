using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OCRPattern.Models
{
    [XmlType("OCRTask")]
    public class OCRTask
    {

        [XmlElement("Task")]
        public Task Task = new Task();
    }
}
