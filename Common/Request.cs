using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int type { get; set; }

        [DataMember]
        public object value { get; set; }

        public Request()
        { }

        public Request(string name, object value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
