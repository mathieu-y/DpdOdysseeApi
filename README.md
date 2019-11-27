# DpdOdyssee.Api (C#.Net)
New DPD Odyssee Shipping API (should be in production in march 2020)

Covered by this Library: 

- Unitary shipment label creation
- Shipment registering for future label generation
- Confirmation and label generation
- Reprint a label
- Print a “Return on demand” label

- Program a pickup order
- Cancel a pickup order 

- Program a Collection Request
- Cancel a Collection Request

This library is not fully tested yet, only labels creation and generation is tested and working. 

How to use ?

Simply put a "credentials.json" file in the same path as the .exe and fill it with your credential like so :

```
{
	"login": "***",
	"password": "***",
	"departureUnitId": "***",
	"payerId": "***",
	"payerAddressId": "***",
	"senderId": "***",
	"senderAddressId": "***",
	"senderZipCode": "***",
	"senderCountryCode": "FR"
}

```
Then run the test project.

If you need those credentials, please ask DPD. 
For other questions you can write me: mathieu.yard at gmail.com
