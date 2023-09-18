
# Zatca | Fatoora - Integeration Helper

This project helps in integertation of systems to Zatca systems.
Currently tested using their sandbox APIs.

---
<div align="center">
 <img src="https://media.giphy.com/media/XdOpq8KtWgfoGEwJjK/giphy.gif" width="60" height="60" />
 <h3>CSR generation</h3>
 <h3>B2C Simplified Invoice Generation is available Now</h3>
 <h3>Compliance API</h3>
 <h3>Reporting API</h3>
</div>

---

## Follow [This guide](CSR_Generation.md) to generate csr token. 

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

#### Generate xml for Debit Note

```http
  StandardInvoiceXmlGenerator.GenerateForDebitNote(StandardInvoiceAdjustment)
```

For parameters refer ->  https://github.com/fasilmarshooq/Zatca_Integration_Helper/blob/main/Zatca-Standard-Invoice-Integration-Client/Model/StandardInvoiceAdjustment.cs

> **_NOTE:_** use above clear Invoice endpoint to clear Debit Note

#### Generate xml for Credit Note

```http
  StandardInvoiceXmlGenerator.GenerateForCreditNote(StandardInvoiceAdjustment)
```

For parameters refer ->  https://github.com/fasilmarshooq/Zatca_Integration_Helper/blob/main/Zatca-Standard-Invoice-Integration-Client/Model/StandardInvoiceAdjustment.cs

> **_NOTE:_** use above clear Invoice endpoint to clear Credit Note

#### Generate xml for Simplified Invoice

```http
  StandardInvoiceXmlGenerator.GenerateForSimplifiedInvoice(StandardInvoiceAdjustment,Certificate,PrivateKey)
```

For parameters refer ->  https://github.com/fasilmarshooq/Zatca_Integration_Helper/blob/main/Zatca-Standard-Invoice-Integration-Client/Model/StandardInvoice.cs

- Certificate : Binary token received using Get Prod CSID API
- PrivateKey : your private key generated using above openSsl commands
- feel free to use certifcate and private key from test project for testing purpose 
  - [Certificate for test](Bee.ZatcaHelper.UnitTests/TestXmls/SimpleInvoice_Cert.pem)
  - [Private Key for test](Bee.ZatcaHelper.UnitTests/TestXmls/SimpleInvoice_privateKey.pem)

> **_NOTE:_** reporting api is still under developement it has a bug in zatca sandbox till then feel free to use compliance API


---
<div align="center">
 <img src="https://media.giphy.com/media/6uHMqz86ArfkcbTC3N/giphy.gif" width="60" height="60" />
 <h3> Rest API supprt for non .net apps</h3>
 <h3> Zatca Reporting API bug fixes</h3>
</div>

---
## License

[MIT](https://choosealicense.com/licenses/mit/)

## Trouble Shooting

- If you facing Schema validation execption without any error message please refer -> https://stackoverflow.com/questions/73388407/schema-validation-failed-xml-does-not-comply-with-ubl-2-1-standards-in-line-wit

- UBL Schema repo -> http://www.datypic.com/sc/ubl21/e-ns39_Invoice.html

