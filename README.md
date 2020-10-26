# UniAtHome.API

## Authorization API

General response:

- When success, returns status code 200 OK

- When failed, an array of error messages in the body

### How to authorize

Set HTTP header Authorization to 'Bearer TOKEN' where TOKEN is 
the JWT token received in api/users/login

### api/users/register

Must be authorized as an Admin!

Request body:
```JSON
{
    "FirstName": "Ivan",
    "LastName": "Vasiliev",
    "Email": "ivan.vasilie@gmail.com",
    "Password": "passwordWithCapsAndDigits",
    "Role": "Admin"
}
```

### api/users/login

Request body:
```JSON
{
    "Email": "ivan.vasilie@gmail.com",
    "Password": "passwordWithCapsAndDigits"
}
```

Response body:
```JSON
{
    "token": "JWT-TOKEN-WILL-BE-HERE",
    "email": "USER-EMAIL-AKA-USER-NAME"
}
```
Response cookie: httpOnly cookie 'refreshToken'.

### api/users/refresh

Request: send JWT token in Authorization 
header & cookie 'refreshToken'

Response:
```JSON
{
    "token": "JWT-TOKEN-WILL-BE-HERE"
}
```
Response cookie: httpOnly cookie 'refreshToken'.

### api/users/revoke

Request: send JWT token in Authorization 
header & cookie 'refreshToken'