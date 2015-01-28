using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicPaper
{
    public class Metadata : Dictionary<string, string>
    {
        public Metadata()
        {
        }

        public Metadata(Dictionary<string, string> dictionary)
            : base(dictionary)
        {
        }

        public void AddRange(Dictionary<string, string> dictionary)
        {
            foreach (KeyValuePair<string, string> each in dictionary)
                Add(each.Key, each.Value);
        }
    }
}
