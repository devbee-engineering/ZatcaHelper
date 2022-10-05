
# Zatca | Fatoora - Integeration Helper

This project helps in integertation of systems to Zatca systems.
Currently tested using their sandbox APIs.

## 🔗 NuGet Package
[![Nuget](https://img.shields.io/nuget/dt/Bee.ZatcaHelper?color=Blue&label=Nuget&logo=Nuget&style=flat-square)](https://www.nuget.org/packages/Bee.ZatcaHelper/)


## Follow below shell commands to generate CSR 

we need a csr token to initiate compliance API request , more about what is CSR here -> https://en.wikipedia.org/wiki/Certificate_signing_request

```bash
#generate private key using below command
openssl ecparam -name secp256k1 -genkey -noout -out privatekey.pem

#generate csr using below command
openssl req -new -sha256 -key privatekey.pem -extensions v3_req -config cert.cnf -out generatedCSR.csr

#convert to base64
echo -n `cat generatedCSR.csr` | openssl enc -base64 -a -A >> csr_Output.txt
```
    
## API Reference

**Note:** Global variables is a dependecy for all the classes , its parameters are described below

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `BaseUrl`      | `string` | **Required**. Base url of zatca [Eg: https://gw-apic-gov.gazt.gov.sa] |
| `ComplianceCsidEndpoint`      | `string` | **Required**. Compliance Csid endpoint [Eg: /e-invoicing/developer-portal/compliance] |
| `ProdCsidEndpoint`      | `string` | **Required**. Prod csid endpoint [Eg : /e-invoicing/developer-portal/production/csids] |
| `InvoiceClearanceEndPoint`      | `string` | **Required**. clearance endpoint [Eg: /e-invoicing/developer-portal/invoices/clearance/single] |

#### Get Compliance CSR token

```http
 ComplianceCsrApiClient(GlobalVariables).GetToken(ComplianceCsrRequest)
```

| ComplianceCsrRequest Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Otp` | `string` | **Required**. OTP obatined from tax portal |
| `Csr` | `string` | **Required**. CSR token generated using above mentioned step  |

#### Get Prod CSID

```http
  ProdCsidApiClient(GlobalVariables).GetToken(ProdCsidOnboardingRequest)
```

| ProdCsidOnboardingRequest Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `ComplianceRequestId`      | `string` | **Required**. RequestId from the response of above endpoint |
| `CsrBinaryToken`      | `string` | **Required**. Binary token from the response of above endpoint |
| `CsrSecret`      | `string` | **Required**. Secret from the response of above endpoint |

#### Generate xml

```http
  StandardInvoiceXmlGenerator.Generate(StandardInvoice)
```

For parameters refer ->  https://github.com/fasilmarshooq/Zatca_Integration_Helper/blob/main/Zatca-Standard-Invoice-Integration-Client/Model/StandardInvoice.cs

#### Clear Invoice

```http
  StandardInvoiceClearanceApiClient(GlobalVariables).ClearInvoice(InvoiceClearanceRequest)
```

| InvoiceClearanceRequest Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Body`      | `string` | **Required**. response of above endpoint |
| `BinaryToken`      | `string` | **Required**. Binary token from the response of Get Prod CSID endpoint |
| `Secret`      | `string` | **Required**. Secret from the response of Get Prod CSID endpoint |



## Roadmap

- implement Allowance charge / Discount 

- implement reporting api for simplified tax invoices



## 🔗 Contact
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/fasilmarshooq)

Write to me at **fasil@dev-bee.com**

## License

[MIT](https://choosealicense.com/licenses/mit/)

