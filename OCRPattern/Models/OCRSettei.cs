using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OCRPattern.Models
{
    [XmlType("OCRSettei")]
    public class OCRSettei
    {
        private Bitmap _Picture = null;

        [XmlIgnore()]
        public Bitmap Picture
        {
            get { return _Picture; }
            set
            {
                if (_Picture != value)
                {
                    _Picture = value;
                    OnPictureChanged();
                }
            }
        }

        [XmlElement("PictureBinary")]
        public byte[] PictureBinary
        {
            get
            {
                if (_Picture != null)
                {
                    TypeConverter cvt = TypeDescriptor.GetConverter(typeof(Bitmap));
                    return (byte[])cvt.ConvertTo(_Picture, typeof(byte[]));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    Picture = new Bitmap(new MemoryStream(value));
                }
                else
                {
                    Picture = null;
                }
            }
        }

        [XmlElement("DCR")]
        public DCR DCR = new DCR();

        public event EventHandler PictureChanged;

        internal void OnPictureChanged()
        {
            PictureChanged?.Invoke(this, new EventArgs());
        }

        private string _PWay = "";

        [XmlAttribute("PWay")]
        public string PWay { get { return _PWay; } set { _PWay = value; } }
    }
}
