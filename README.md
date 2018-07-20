# nfe-api-client
It is nfe.io’s nfs-e API implementation example
# Getting Started
* access https://app.nfe.io/login.
*	Click in sign up and create you account to test API.
* After login, click in ACCOUNT, then click in ACCESS KEY and copy you API KEY.
* Can you test invoice issuer, but before is necessary create a company. For create a company you can run integration test about Company, the test class is CompanyClientIntegrationTests. It is necessary set your api key on there. In the path nfe-api-client\UnitTests\FileToTest have json's example to create a company or invoice. 
* After create a company running the integration test, do you should to take the companyId to use on invoice issuer.
*	Now, set your companyId and ApiKey at IntegrationTest’s solution InvoiceClientIntegrationTests class, this class have function to issuer an invoice of test.
# Prerequisites
* It is necessary visual studio or visual studio code and .NET core SDK 2.1
# Running the tests
* First of all, you should to create an appsettings.development.json to configure environment variables. This file should be equal the appsettings.json, use it as example. Set your companyId, ApiKey etc there.
* Open Test Explorer on IDE. It is recommended Group by Tests using Traits option.
* Run all unit Tests to check if all logical tests there are passing.
* Run All Integration tests to verify “acceptance” API test, it is recommended run one by one and debug to understand flow. This tests issuer, cancel or get an invoice etc.
# Built With
*	[Visual Stuadio IDE](https://visualstudio.microsoft.com/downloads/) - The web framework used
*	[Nuget](https://www.nuget.org/) - Dependency Management
*	[SDK](https://www.microsoft.com/net/download/windows) - Used .Net core 2.1
# Authors
*	[Michel Balthazar](https://github.com/michelbalthazar) - Initial work
