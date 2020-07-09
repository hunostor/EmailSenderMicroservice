# EmailSenderMicroservice

### Request example:

url: ../Sender  
method: POST  
header: Content-Type: application/json  
body:

```json
{
  "fromAddress": "new.york.times@america.com",
  "fromDisplay": "Hello",
  "toAddress": "mezga.geza@gmail.com",
  "toDisplay": "lorem ipsum",
  "subject": "this is an subject",
  "htmlMessage": "this is an html message"
}
```

Enter the smtp information, appsettings.json
```json
  "EmailSender": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "EnableSSL": true,
    "UserName": "*********@gmail.com",
    "Password": "***********"
  },
```