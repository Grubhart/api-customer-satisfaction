using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace api_customer_satisfaction.ServiceSoap.DataContract
{
    [DataContract]
    public class EvaluationModel
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public int qualification { get; set; }
        [DataMember]
        public DateTime evaluationDate { get; set; }
    }
}