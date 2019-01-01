# ArKorespV1
2018 12 30
Office registration utility using Arango
</br>
2019-01-01 use dev2019 brach
</br>
Requires local Arango database (version 3.4.1)</br>
Inside database "obieg"</br>
User "tomasz" with same password bounded to this database.</br>
In Arango shell (login as root): </br>
var users = require("@arangodb/users");</br>
users.grantDatabase("tomasz","obieg");</br>
This user is used to connect to DB - security for objects is generated in db objects</br>
<hr>
<b>
<div>
Inside create collection ATUZYTK and populate it with document in maneer: </br>
{"UserName":"TJ","Password":"alamakota","Status":0,"Role":2} </br>
This will be first - admin user
</div>
</p>
