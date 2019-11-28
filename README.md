# DpdOdyssee.Api (C#.NET)
New DPD Odyssee Shipping API (should be in production in march 2020)

Covered by this Library: 

A Unitary shipment label creation
B Shipment registering for future label generation
C Confirmation and label generation
D Reprint a label
E Print a “Return on demand” label

F Program a pickup order
G Cancel a pickup order 

H Program a Collection Request
I Cancel a Collection Request

This library is not fully tested yet, only A,B,C,D,E,F,G are tested and working. 

How to use ?

Simply put a "credentials.json" file in the same path as the .exe and fill it with your credentials like so :

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
