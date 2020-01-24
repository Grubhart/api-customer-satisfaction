using api_customer_satisfaction.ServiceSoap.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace api_customer_satisfaction.ServiceSoap.ServiceContract
{
    [ServiceContract]
    public interface IEvaluationService
    {
        [OperationContract]
        IEnumerable<EvaluationModel> GetAllSoap();
        [OperationContract]
        EvaluationModel GetByIdSoap(int id);
    }
}