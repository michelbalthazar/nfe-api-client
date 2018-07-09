# nfe-api-client
It is nfe.io’s nfs-e API implementation example
# Getting Started
* access https://app.nfe.io/login.
*	Click in sign up and create you account to test API.
*	After login, click in COMPANIES and create your company to test. How it is only to test, can fill fake data, with exception Federal Tax Number (CNPJ) it should valid. To Generate a valid Federal Tax Number, access https://consulta.guru/gerador-cnpj-gratis-online/1 and click save.
*	Next, click in WAITING tab and click on button EDIT, after ACCESS KEY. Take your companyId and ApiKey (Nota fiscal). 
*	Now, dowload the project and set your companyId and ApiKey at IntegrationTest’s solution InvoiceClientIntegrationTests class, this class have function to issuer an invoice of test. 
* In another moment we will go create a company through api, but it is necessary company's client implementation yet ***
# Prerequisites
It is necessary visual studio or visual studio code and .NET core SDK 2.1
# Running the tests
Open Test Explorer on IDE. It is recommended Group by Tests using Traits option.
Run all unit Tests to check if all logical tests there are passing.
Run All Integration tests to verify “acceptance” API test, it is recommended run one by one and debug to understand flow. This tests issuer, cancel or get an invoice etc.
# Built With
*	[Visual Stuadio IDE](https://visualstudio.microsoft.com/downloads/) - The web framework used
*	[Nuget](https://www.nuget.org/) - Dependency Management
*	[SDK](https://www.microsoft.com/net/download/windows) - Used .Net core 2.1
# Authors
*	[Michel Balthazar](https://github.com/michelbalthazar) - Initial work
