using System;
using System.IO;
using System.Text.Encodings.Web;

namespace NiuX.LogPanel.Views
{
    public class HtmlString
    {
        private readonly string _value;

        public HtmlString(string value)
        {
            _value = value;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
            if (encoder == null)
                throw new ArgumentNullException(nameof(encoder));
            writer.Write(this._value);
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
