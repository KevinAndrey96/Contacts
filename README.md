# Backend!

Para ejecutar el backend es necesario preparar la base de datos con el comando 

> Update-Database

por defecto se creará una base de datos local en SQLServer con el nombre DirectoryBD

Importante ejecutar el proyecto en el entorno API, el servicio estará expuesto en los siguientes endpoints http://localhost:5000/api y https://localhost:5001/api

Es necesario ejecutar un servidor mongo con la base de datos creada para poder guardar los logs de registro.

en una terminal ejecutar
> mongod

y en otra 
>mongo
>use DirectoryLogs

Los registros estarán almacenados en la colección Logs

# Frontend!

Para ejecutar el frontend es necesario ejecutar el comando 

> ng serve

El servidor se ejecutará en la ruta https://localhost:4200