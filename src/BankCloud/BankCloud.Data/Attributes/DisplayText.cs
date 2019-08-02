using System;

namespace BankCloud.Data.Attributes
{
    public class DisplayText : Attribute
    {
        private string text;

        public DisplayText(string Text)
        {
            this.text = Text;
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}
