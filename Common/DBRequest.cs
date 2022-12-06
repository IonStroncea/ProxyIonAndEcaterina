using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Text;

namespace Common
{
    [DataContract]
    public class DBRequest : IComparable
    {
        [DataMember]
        public string Procedure { get; set;}

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public List<Request> parameters { get; set; }

        public DBRequest()
        {
            parameters = new List<Request>();
        }

        public int CompareTo(object obj)
        {
            DBRequest compareTo = obj as DBRequest;

            return DateTime.Compare(this.date, compareTo.date);
        }
    }
}
