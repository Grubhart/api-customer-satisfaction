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
        public int Id { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Qualification { get; set; }
        [DataMember]
        public DateTime EvaluationDate { get; set; }
    }
}