# api-customer-satisfaction

# alcance

--> .NET Core 3.1

--> WebAPI que implementa servicios REST y Soap

--> Utiliza Entity Framework - Code First

--> Se implementó el patrón repositorio

--> Para la base de datos se debería configurar el servidor donde se creará en el archivo appsettings.json

--> se deberán ejecutar los comandos para agregar la migración y luego para la creación de la base de datos
--> add-migration nombreDeMigracion
--> update-database

--> Para la Web API se ha implementado swagger para poder probar los servicios

--> se congiguró CORS para poder exponer los servicios REST y Soap

--> para el context de datos de ha implementado en la clase Context.cs una carga inicial con 2 registros

--> Ejemplo método GET en REST

--> https://localhost:44326/api/Evaluation (devuelve todas las evaluaciones) 

--> Response 
[
    {
        "id": 1,
        "email": "ryesquen@gmail.com",
        "firstName": "Renzo",
        "lastName": "Yesquén Herrera",
        "qualification": 7,
        "evaluationDate": "2019-03-21T00:00:00"
    },
    {
        "id": 2,
        "email": "nayeska.gonzales@gmail.com",
        "firstName": "Nayeska",
        "lastName": "Gonzales Mauricio",
        "qualification": 5,
        "evaluationDate": "2019-06-18T00:00:00"
    }
]

--> Ejemplo para Soap POST

--> https://localhost:44326/EvaluationService.asmx

--> body 

<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GetAllSoap xmlns="http://tempuri.org/">
    </GetAllSoap>
  </soap:Body>
</soap:Envelope>

--> Response

<?xml version="1.0" encoding="utf-8"?>
<s:Envelope xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
    <s:Body>
        <GetAllSoapResponse xmlns="http://tempuri.org/">
            <GetAllSoapResult xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
                <EvaluationModel>
                    <Id>1</Id>
                    <Email>ryesquen@gmail.com</Email>
                    <FirstName>Renzo</FirstName>
                    <LastName>Yesquén Herrera</LastName>
                    <Qualification>7</Qualification>
                    <EvaluationDate>2019-03-21T00:00:00</EvaluationDate>
                </EvaluationModel>
                <EvaluationModel>
                    <Id>2</Id>
                    <Email>nayeska.gonzales@gmail.com</Email>
                    <FirstName>Nayeska</FirstName>
                    <LastName>Gonzales Mauricio</LastName>
                    <Qualification>5</Qualification>
                    <EvaluationDate>2019-06-18T00:00:00</EvaluationDate>
                </EvaluationModel>
            </GetAllSoapResult>
        </GetAllSoapResponse>
    </s:Body>
</s:Envelope>

# fin alcance	